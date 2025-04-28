//*************************************************************************************************
//Program: ICA17 Adrian
//Description: Predicates & lamba expressions
//Date: Dec, 8, 2023
//Author: Adrian Baira
//Course: CMPE1666
//Class: CNTA01
//*************************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace CMPE1666_SimpleLambdas
{
    public partial class Form1 : Form
    {
        // structure that describes a ball
        public struct SBall
        {
            public Point pos;
            public Color col;
            public int rad;
            public SBall(Point Pos, Color Col, int Rad)
            {
                pos = Pos;
                col = Col;
                rad = Rad;
            }
        }

        // our collection of balls
        private List<SBall> _balls = new List<SBall>();

        // rendering surface
        private CDrawer _drawer = new CDrawer();

        // you know
        private Random _rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // subscribe to left click event
            _drawer.MouseLeftClick += _drawer_MouseLeftClick;
        }

        private void _drawer_MouseLeftClick(Point pos, CDrawer dr)
        {
            // this is in the drawer thread, so poke back into ours
            try
            {
                Invoke(new Action<Point>(AddBall), pos);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);                                
            }
        }

        // generic add a random ball to the collection method
        private void AddBall (Point p)
        {
            _balls.Add(new SBall
            {
                pos = p,
                col = RandColor.GetColor(),
                rad = _rnd.Next(5, 51)
            });

            Render();
        }

        // show them balls
        private void Render ()
        {
            _drawer.Clear(); //clears the drawer then renders it

            foreach (SBall ball in _balls)
                _drawer.AddCenteredEllipse(ball.pos, ball.rad * 2, ball.rad * 2, ball.col); // it will add the ball on to the list
        }
        //**********************************************************************************************
        //Method:           private void UI_B_RemoveSmall_Click(object sender, EventArgs e)
        //Purpose:          To remove all the balls that have a radius less than 10
        //Returns:          Balls that are removed and added to the listbox and remove from orginial list 
        //**********************************************************************************************
        private void UI_B_RemoveSmall_Click(object sender, EventArgs e)
        {
            int countremoved = 0;   
            countremoved = _balls.RemoveAll(a => a.rad < 10);    //it will check though the list if the ball is less than 10         
            UI_LB_Status.Items.Add($"Removed {countremoved} balls!"); //shows the count of the balls
            Render();//render the balls on the the screen
        }
        //**********************************************************************************************
        //Method:           private void UI_B_Add100_Click(object sender, EventArgs e)
        //Purpose:          To add 100 balls to the screen
        //Returns:          Adds the ball to the screen into the list and display it
        //**********************************************************************************************
        private void UI_B_Add100_Click(object sender, EventArgs e)
        {
            Point point = new Point();
           
            for (int i = 1 ; i <= 100; i++)
            {
                point.X = _rnd.Next(0,801); // gets a random value between 0 and 800
                point.Y = _rnd.Next(0,601); // get a random value between 0 and 600
                AddBall(point); //passes the point to be pass to the helper method

            }
            Render(); //renders the balls on to the canvas
        }
        //**********************************************************************************************
        //Method:           private void UI_B_RemoveBigBalls_Click(object sender, EventArgs e)
        //Purpose:          To remove balls that are greater than 40
        //Returns:          a new list with updated from removed
        //**********************************************************************************************
        private void UI_B_RemoveBigBalls_Click(object sender, EventArgs e)
        {
            int countremoved = 0;       
            countremoved = _balls.RemoveAll(a => a.rad > 40);  //it will check the list and that if the ball rad is greater than 40 then remove it
            UI_LB_Status.Items.Add($"Removed {countremoved} balls!"); //add to listbox
            Render();
        }
        //**********************************************************************************************
        //Method:           private void UI_B_NoGreen_Click(object sender, EventArgs e)
        //Purpose:          To count how many green balls there are on the screen
        //Returns:          count of green balls
        //**********************************************************************************************
        private void UI_B_NoGreen_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = _balls.Where(a => a.col.G > 192).Count(); //to count the balls where the green value is > 192
            UI_LB_Status.Items.Add($"There are {count} green balls!"); // add to the list box
            Render();
        }
        //**********************************************************************************************
        //Method:           private void UI_B_Left_Click(object sender, EventArgs e)
        //Purpose:          To only take half of the balls from the x position from the list
        //Returns:          half of the balls of the list
        //**********************************************************************************************
        private void UI_B_Left_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = _balls.RemoveAll(a => a.pos.X > (_drawer.m_ciWidth / 2)); // removes the balls that are on the first half of the screen
            UI_LB_Status.Items.Add($"Removed {count} balls!"); //add to the listbox
            Render();
        }
        //**********************************************************************************************
        //Method:           private void UI_B_AvgSize_Click(object sender, EventArgs e)
        //Purpose:          To get the average radius of the balls
        //Returns:          Show the values to user  
        //**********************************************************************************************
        private void UI_B_AvgSize_Click(object sender, EventArgs e)
        {
            double count = 0;
            try
            {
                count = _balls.Average(a => a.rad); // it will check the average size of the ball in the list
                UI_LB_Status.Items.Add($"Average ball radius is {count:F2}!"); // display the average
                Render();
            }
            catch 
            {
                UI_LB_Status.Items.Add($"There are no balls on the screen"); //error message if there are no balls that were printed
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_B_Clear_Click(object sender, EventArgs e)
        //Purpose:          When clicked it will remove the balls that was counted
        //Returns:          Cleared canvas
        //**********************************************************************************************
        private void UI_B_Clear_Click(object sender, EventArgs e)
        {
            UI_LB_Status.Items.Add($"Removed {_balls.Count()}!"); //shows that all the balls are removed
            _balls.Clear(); // Clears all the balls
            Render();
        }
        //**********************************************************************************************
        //Method:           private void UI_B_Hole_Click(object sender, EventArgs e)
        //Purpose:          To make a new list to remove the balls and then add to the original list to show the balls
        //Returns:          Renders the values on to the screen
        //**********************************************************************************************
        private void UI_B_Hole_Click(object sender, EventArgs e)
        {
            Point point = new Point(); // makes a point
            point.X = _drawer.m_ciWidth / 2;    //set the x position of the point
            point.Y = _drawer.m_ciHeight / 2;   //set the y position of the point
            List<SBall> list = _balls.Where(a => Distance(a, point) < 200).ToList(); //checks in the list where the distance is < 20 and add it to the new list with TOList();

            _balls.RemoveAll(a => list.Contains(a)); //Removes all the balls int the list in the list we just created into the original list

            List<SBall> dim = list.Select(a => new SBall(a.pos , Color.FromArgb(64, a.col), a.rad)).ToList(); // adds the new list shows and dims the value from where we removed it

            _balls = _balls.Concat(dim).ToList(); //adds the dimed list to the orginal list 
            Render(); //Render
        }

        // get the distance from a ball to to a specified point
        private double Distance (SBall A, Point P)
        {
            return Math.Sqrt(Math.Pow(A.pos.X - P.X, 2) + Math.Pow(A.pos.Y - P.Y, 2));
        }
    }
}
