//****************************************************************************************************************************
//Program:          Lab 01 Mazomatic
//Description:      Maze solver
//Date:             Sept, 16, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using System.Threading;
using System.Runtime.InteropServices;
using static System.Windows.Forms.AxHost;
using System.Reflection;
using System.Linq.Expressions;

namespace LAB01_AdrianBaira
{
    public partial class Form1 : Form
    {
        #region Members

        public enum states { open, wall, visited};          //states of open, wall, and visited
        public states[,] Maze;                              //2D array of the maze
        public Queue<Point> Que = new Queue<Point>();       //Queue to hold the point positions
        public CDrawer canvas = null;                       //CD drawer initalize
        public Point start;                                 //starting point
        public Point end;                                   //end point will also help to stop the solve method
        public Color colOfPath = Color.Blue;                //Color of path
        int steps;                                          //steps taken to the end
        int speed = 0;                                      //Speed of solving
        Thread thread = null;                               //Threaded Solve
        bool StopThread = false;

        #endregion

        #region CTOR
        /// <summary>
        /// Initalize Form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            UI_BTN_START.Enabled = false;
            this.MouseWheel += Form1_MouseWheel;
        }
        /// <summary>
        /// Detting the detla value and checking if it is + or - and add to the solve speed or decrease the solve speed
        /// </summary>
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta < 0)
            {
                if (speed <= 0)
                    speed = 0;                                  //lock speed so it can't be less than 0
                else
                    speed--;                                    //decrement the Solve speed (FASTER)
            }
            else if (e.Delta > 0)
            {
                speed++;                                        //Increase the solve speed (SLOWER)
            }
            UI_TXT_SleepNum.Text = $"{speed}";                  //Update User UI for speed
        }
        #endregion

        #region Methods
        /// <summary>
        /// When file is dropped into the Label it will grab the file name and check if it is a valid file type and will load the maze
        /// if invalid then show message on the Listbox
        /// </summary>
        private void UI_LBL_Mazes_DragDrop(object sender, DragEventArgs e)
        {
            string[] filepath = (string[])e.Data.GetData(DataFormats.FileDrop, false);      //getting the file path from drag and drop event
            if (Path.GetExtension(filepath[0]) == ".bmp")                                   //checking if file is a .bmp
            {
                UI_BTN_START.Enabled = true;                        
                LoadMaze(filepath[0]);
            }
            else
            {
                UI_LISTBOX.Items.Add("Invalid file type please drop in a .BMP file");
            }
        }
        /// <summary>
        /// Helper method to allow drag and drop functionality to work
        /// </summary>
        private void UI_LBL_Mazes_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Loading Maze using Bitmap and GDIDrawer to display a Maze and scaling it to fit the screen
        /// </summary>
        /// <param name="file"></param>
        private void LoadMaze(string file)
        {
            if (canvas != null)
            {
                canvas.Close();                                 // close the canvas if there is already a drawer open from previous solve
                Que.Clear();                                    // clears the que to restart drawing
                UI_BTN_START.Text = "Solve";               
            }
            Bitmap image = new Bitmap(file);
            if (image.Width > 190 || image.Height > 100)
            {
                UI_LISTBOX.Items.Add("Image dimensions must be within 190 x 100");                          //warning message for image width and height restrictions
                return;
            }

            //SCALE FACTOR TO ALLOW TO THE DRAWER TO FIT AS MUCH ON THE SCREEN
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;     
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int scale = 100;

            while(scale > 1)
            {
                if(image.Width * scale <= screenWidth && image.Height * scale <= screenHeight - 80)
                {
                    canvas = new CDrawer(image.Width * scale, image.Height * scale, false);                 // Creating the CDrawer and image
                    break;
                }
                scale--;                                                                                    //decreasing the scale until it would fit the screen
            }
            
            UI_LISTBOX.Items.Add($"Load: Maze loaded : {Path.GetFileName(file)} maze.");                    // Showing the file name
            canvas.Scale = scale;                                                                           // setting the scale to 10
            Maze = new states[image.Width, image.Height];                                                   // creating the 2D array by the dimensions 

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);                 //Grabs the pixel from the bitmap
                    Maze[x, y] = states.wall;                           //sets the x and y default as a wall
                    canvas.SetBBScaledPixel(x, y, pixel);               //draws the pixel as a wall

                    if (pixel == Color.FromArgb(255, 255, 255))         //If the pixel is white then its a path
                    {
                        canvas.SetBBScaledPixel(x, y, Color.White);
                        Maze[x, y] = states.open;
                    }

                    if (pixel == Color.FromArgb(255, 0, 0))             //If the Pixel is red then that is the end point
                    {
                        canvas.SetBBScaledPixel(x, y, Color.Red);       //colors on the drawer the end point
                        Maze[x, y] = states.open;                       //makes is a avaliable space
                        end = new Point(x, y);                          //sets the end point 
                    }

                    if (pixel == Color.FromArgb(0, 255, 0))             //if the pixel is green this is the starting point
                    {                       
                        canvas.SetBBScaledPixel(x, y, Color.Green);     //draw on canvas
                        start = new Point(x, y);                        //saves the starting point   
                        Maze[x, y] = states.open;                       //makes it a open space
                    }

                }
            }
            canvas.Render();                                            //renders the drawer

        }

        /// <summary>
        /// Start Button to start or stop maze solving
        /// </summary>
        private void UI_BTN_START_Click(object sender, EventArgs e)
        {
            if(thread != null)
            {
                StopThread = true;
                thread = null;                                      //resets the thread to null
                UI_BTN_START.Text = "Solve";                        //updates UI
                UI_LISTBOX.Items.Add("Exiting Thread");             //Tells user thread has been removed
            }
            else
            {
                if (Maze.LongLength > 4000 || speed > 4)
                {
                    thread = new Thread(() =>                       //creating another thread so UI doesnt block
                    {
                        Search();
                    });
                    thread.IsBackground = true;                     
                    thread.Start();                                 //starting the thread 
                }
                else
                    Search();                                       //instant solve if speed is 0
                
            }
        }

        /// <summary>
        /// Queue that will help with our Breadth-First-Search
        /// </summary>
        private void Search()
        {
            UI_BTN_START.Invoke(new Action(() =>                //Allowing to be thread safe
            {
                UI_BTN_START.Text = "Cancel Solve";
                UI_LISTBOX.Items.Add($"Attempting threaded solve of : {canvas.ScaledWidth}x{canvas.ScaledHeight} maze.");
            }));

            steps = 0;
            Que.Enqueue(start);                                     
            while (Que.Count > 0)
            {
                Point Pos = Que.Dequeue();                      //remove the Point from the queue
                Maze[Pos.X, Pos.Y] = states.visited;            //make the point Visited so we dont go back to it again

                if (Solve(Pos))                                 //Breadth-First-Search Method
                {
                    Que.Clear();                                //To stop the loop and clear the Que to stop solving
                    UI_BTN_START.Invoke(new Action(() =>        //if still in a thread then needed a delegate method to update UI
                    {
                        UI_BTN_START.Text = "Solve";
                        UI_BTN_START.Enabled = false;
                        UI_LISTBOX.Items.Add($"Solved in {steps} steps");

                    }));
                }

                //To Stop the thread and cancel the solve
                if(StopThread)
                {
                    StopThread = false;         
                    break;
                }
            }
            thread = null;

        }
        /// <summary>
        /// Breadth-First-Search Algorithm
        /// If the solve is sucessfull the it will allow the loop to end in the search method
        /// 
        /// Steps
        /// Get the next move from the queue
        /// If it is not Open, this step has been visited
        /// If it is the end, we are done, return true
        /// Next if the point is not the start or end, set the CDrawer pixel to our solve color and set our maze array to Visited
        /// check all directions, and if not Visited and in bounds, add these points to the queue
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private bool Solve(Point point)
        {   
            int x = point.X;             //
            int y = point.Y;            //position of the path
            if (point == end)
            {
                return true;            //Condition to leave the loop
            }
       
            //Search to the right
            if (x + 1 < Maze.GetLength(0) && Maze[x + 1, y] == states.open)         //To be within the bounds of the array 
            {
                Maze[x + 1, y] = states.visited;
                steps++;
                Que.Enqueue(new Point(x + 1, y));                                   //queue the point so it can also be searched
                Draw(new Point(x + 1, y));
            }
            
            //Search to the left
            if (x - 1 >= 0 && Maze[x - 1, y] == states.open)
            {
                Maze[x - 1, y] = states.visited;
                steps++;
                Que.Enqueue(new Point(x - 1, y));
                Draw(new Point(x -1, y));
            }

            //Search downwards
            if (y + 1 < Maze.GetLength(1) && Maze[x, y + 1] == states.open )
            {
                Maze[x, y + 1] = states.visited;
                steps++;
                Que.Enqueue(new Point(x, y + 1));
                Draw(new Point(x, y + 1));
            }

            //Search upwards
            if (y - 1 >= 0 && Maze[x, y - 1] == states.open)
            {
                Maze[x, y - 1] = states.visited;
                steps++;
                Que.Enqueue(new Point(x, y - 1));
                Draw(new Point(x, y - 1));
            }

            //Delegate method to update the MAIN UI to show how many steps are being taken
            UI_TXTBOX.Invoke(new Action(() => 
            {
                UI_TXTBOX.Text = $"{steps}";
            }));
            return false;                           //Condition to continue the loop
        }

        /// <summary>
        /// Draw the path onto the drawer HELPER METHOD
        /// </summary>
        /// <param name="path"></param>
        private void Draw(Point path)
        {
            //If user puts in speed the solving path will be slowed or instant
            if(speed > 0)
            {
                Thread.Sleep(speed);                                                    //Time on how much the Thread should sleep
                canvas.SetBBScaledPixel(path.X, path.Y, colOfPath);
            }
            else
            {
                canvas.SetBBScaledPixel(path.X, path.Y, colOfPath);
            }
            canvas.Render();                                                            //Render to the Drawer
        }
       
        /// <summary>
        /// Shows the Color Dialog and allow user to change the color of the solving path
        /// </summary>
        private void UI_LBL_Color_Click(object sender, EventArgs e)
        {
            if(ColorDialog.ShowDialog() == DialogResult.OK)     
            {
                colOfPath = ColorDialog.Color;                      
                UI_LBL_Color.BackColor = ColorDialog.Color;
            }
        }
        #endregion
    }
}
