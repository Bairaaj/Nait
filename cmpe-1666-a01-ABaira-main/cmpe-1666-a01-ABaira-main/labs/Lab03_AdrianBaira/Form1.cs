//****************************************************************************************************************************
//Program:          LAB3_AdrianB
//Description:      BallZ
//Date:             Nov, 24, 2023
//Author:           Adrian Baira
//Course:           CMPE1666
//Class:            CNTA01
//****************************************************************************************************************************
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
using System.Threading;
using System.IO;

namespace Lab03_AdrianBaira
{
    public enum Difficulty { Easy = 3, Medium = 4, Hard = 5 } // public enum
    public partial class MainForm : Form
    {
        //enum for ball state
        public enum BallState { Dead = 0, Alive = 1 };
        static int width = 800; //width of the window
        static int height = 600; //height of the window
        int score;  //currrent score of the play
        static int size = 50; //size of the ball
        static int rowCount = width / size; //row count 
        static int colCount = height / size; // col coount
        int highscore = 0; //high score is set to zero first
        //stuct
        public struct Ball
        {
            public Color colorOfBall;
            public BallState state;
            //obeject method to call
            public Ball(Color ColorofBall, BallState stateOfBall)
            {
                colorOfBall = ColorofBall;
                state = stateOfBall;
            }

        }
        //array for my struct that is as big as my row count
        Ball[,] Ballsvar = new Ball[rowCount, colCount];

        //show dialog   
        SelectDifficultydialog selectDifficultydialog = new SelectDifficultydialog();
        AnimationSpeed animationspeeddlg = null;
        Score scoredlg = new Score();
        HighScore highscoredlg = null;
        CDrawer canvas;
        //animation speed is set to 10
        public int animationspeed = 10;
        //default difficuly to easy first
        Difficulty difficulty = Difficulty.Easy;
        public MainForm()
        {
            InitializeComponent();
            
        }
        //**********************************************************************************************
        //Method:           private void MainForm_Load(object sender, EventArgs e)                             
        //Purpose:          when the main load if loaded it will show the 
        //Returns:          CD drawer canvas
        //*********************************************************************************************
        private void MainForm_Load(object sender, EventArgs e)
        {
            canvas = new CDrawer(width, height); // set the width and height of the canvas
            score = 0; // set the score to 0
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Play_Click(object sender, EventArgs e)                            
        //Purpose:          To display the model dialog
        //Returns:          the display for balls
        //*********************************************************************************************
        private void UI_BTN_Play_Click(object sender, EventArgs e)
        {

            if (selectDifficultydialog.ShowDialog() == DialogResult.OK)
            {
                difficulty = (Difficulty)selectDifficultydialog.difficulty; // set the difficulty with enum
                UI_BTN_Play.Enabled = false; // disable the play button
                UI_Timer.Enabled = true; //enable the timer for game to start
                Randomize(); // randomize the colors and set the state of the balls in the struct array
                Display(); //display the newly created struct
            }
        }
        //**********************************************************************************************
        //Method:           private void Randomize()                           
        //Purpose:          will randomize the alls in the strcut array with a random number and difficulty
        //Returns:          stuct array fillied with random number and state to be alive
        //*********************************************************************************************
        private void Randomize()
        {
            int numofcolors = (int)selectDifficultydialog.difficulty; // get the difficulty
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Purple }; //set an array of colors to use
            Random random = new Random(); // random variable

            for (int x = 0; x < Ballsvar.GetLength(0); x++) //struct row length
            {
                for (int y = 0; y < Ballsvar.GetLength(1); y++) //struct col length
                {
                    Ballsvar[x, y] = new Ball(colors[random.Next(0, (int)difficulty)], BallState.Alive);
                    //to put into my struct array of balls and have the state be alive in the same position 
                }
            }

        }

        //**********************************************************************************************
        //Method:           private void Display()                      
        //Purpose:          Display the stuct array to the canvas
        //Returns:          bitmap
        //*********************************************************************************************
        private void Display()
        {
            canvas.Clear();
            for (int x = 0; x < Ballsvar.GetLength(0); x++) // row 
            {
                for (int y = 0; y < Ballsvar.GetLength(1); y++) // col
                {
                    if (Ballsvar[x, y].state == BallState.Alive) // if the ball is alive then print the ball else do not print anything helps with dead or alive state
                    {
                        canvas.AddEllipse(x * size, y * size, size, size, Ballsvar[x, y].colorOfBall);
                    }
                }
            }
        }
        //**********************************************************************************************
        //Method:           private int BallsAlive()                           
        //Purpose:          To grab a file from files
        //Returns:          bitmap
        //*********************************************************************************************
        private int BallsAlive()
        {
            int countalive = 0; // count for the balls alive on screen 
            for (int x = 0; x < Ballsvar.GetLength(0); x++)
            {
                for (int y = 0; y < Ballsvar.GetLength(1); y++)
                {
                    if (Ballsvar[x, y].state == BallState.Alive) // if it is alive then add to counter
                    {
                        countalive++;
                    }
                }
            }
            return countalive; //return the amount of balls alive 
        }
        //**********************************************************************************************
        //Method:           private int CheckBalls(int x, int y, Color color)                            
        //Purpose:          To check how many balls there are next to eachother and return how mayn ar edead
        //Returns:          int counter for dead balls
        //*********************************************************************************************
        private int CheckBalls(int x, int y, Color color)
        {
            int counterforball; // counter for how many balls are together
            if (x < 0 || x >= rowCount || y < 0 || y >= colCount || Ballsvar[x, y].state == BallState.Dead || Ballsvar[x, y].colorOfBall != color) // conditions for it to return if the ball is alive
            {
                return 0; // doesnt return anything if the ball is not dead the ball is alive
            }
            counterforball = 1; 
            Ballsvar[x, y].state = BallState.Dead; //sets the ball to dead
            counterforball += CheckBalls(x + 1, y, color); // it will the ball on the right side 
            counterforball += CheckBalls(x - 1, y, color); // it will check the ball on the left side
            counterforball += CheckBalls(x, y + 1, color); // check above
            counterforball += CheckBalls(x, y - 1, color); // check below
            return counterforball; //returns the count for the balls that are dead
        }
        //**********************************************************************************************
        //Method:           private int StepDown())                             
        //Purpose:          To move the ball down and set the state of the ball
        //Returns:          int of how many to stepdown 
        //*********************************************************************************************
        private int StepDown()
        {
            int stepdownballnum = 0;
            for (int y = Ballsvar.GetLength(1) - 1; y > 0; y--)
            {
                for (int x = 0; x < Ballsvar.GetLength(0); x++)
                {
                    if (Ballsvar[x, y].state == BallState.Dead)
                    {
                        if (Ballsvar[x, y - 1].state == BallState.Alive)
                        {
                            Ballsvar[x, y] = Ballsvar[x, y - 1]; // set the one below it to the new x and y stuct val
                            Ballsvar[x, y].state = BallState.Alive; // then make the state of the ball alive
                            Ballsvar[x, y - 1].state = BallState.Dead; // then set the ball above it to dead 

                            stepdownballnum++; 
                        }
                    }
                }

            } 
            Thread.Sleep(animationspeed); 
            return stepdownballnum;
        }
        //**********************************************************************************************
        //Method:           private int FallDown()                          
        //Purpose:          To have the balls droppped and redisplay for animation 
        //Returns:          int how many dropped
        //*********************************************************************************************
        private int FallDown()
        {
            int totaldropped = 0; 
            int balldropped = StepDown();
            // will keep calling the method of step down
            while (balldropped > 0)
            {
                //it will count the balls being dropped and add it to the total overall balls that dropped thoughout the game
                totaldropped += balldropped;
                balldropped = StepDown(); // keep checking
                Display(); // and display
            }
            return totaldropped;
        }
        //**********************************************************************************************
        //Method:           private int Pick()                          
        //Purpose:          method for user to pick a ball to either reutn a 0 or one
        //Returns:          bitmap
        //*********************************************************************************************
        private int Pick()
        {
            Point point = new Point(); // gets the mouse click and maks a variable
            if (canvas.GetLastMouseLeftClick(out point))
            {
                if (Ballsvar[point.X / size, point.Y / size].state == BallState.Dead) // if user presses non existant ball then return nothing
                {
                    Console.Beep();
                    return 0;
                }
                //check how many balls there are from the point they selected
                int ballscount = CheckBalls(point.X / size, point.Y / size, Ballsvar[point.X / size, point.Y / size].colorOfBall);
                //score counter if they do more than 2 then do * 2
                if (ballscount > 1)
                {
                    score += 50 * (ballscount * 2);
                }
                else
                {
                    score += 50;
                }
                // to set the score in the modeless dialog
                scoredlg.scores = score;
                //to dropp the balls
                int droppedballs = FallDown();
                canvas.Clear();
                Display();

                return score;
            }
            return 0;
        }
        //**********************************************************************************************
        //Method:           private void UI_CHKBOX_ShowScore_CheckedChanged(object sender, EventArgs e)                           
        //Purpose:          to show dialog
        //Returns:          dialog show score
        //*********************************************************************************************
        private void UI_CHKBOX_ShowScore_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_CHKBOX_ShowScore.Checked)
            {
                scoredlg._dFormClosing = CallbackFormClosingScore;
                scoredlg.Show();
            }
            else
            {
                scoredlg.Hide();
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_CHKBOX_ShowAnimationSpeed_CheckedChanged(object sender, EventArgs e)                       
        //Purpose:          to show the animation dialog
        //Returns:          the desired animation speed
        //*********************************************************************************************
        private void UI_CHKBOX_ShowAnimationSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_CHKBOX_ShowAnimationSpeed.Checked)
            {
                if (animationspeeddlg == null)
                {
                    animationspeeddlg = new AnimationSpeed();
                    animationspeeddlg._dFormClosing = CallbackFormClosingAnimation;
                    animationspeeddlg._dSpeed = getAniSpeed;
                }
                animationspeeddlg.Show();
            }
            else
            {
                animationspeeddlg.Hide();
            }
        }
        //**********************************************************************************************
        //Method:           private void getAniSpeed(int speed)                        
        //Purpose:          to get animation speed from dialog
        //Returns:          Animation speed
        //*********************************************************************************************
        private void getAniSpeed(int speed)
        {
            animationspeed = speed;
        }
        //**********************************************************************************************
        //Method:           private void CallbackFormClosingScore()                            
        //Purpose:          CLoses dialog
        //*********************************************************************************************
        private void CallbackFormClosingScore()
        {
            UI_CHKBOX_ShowScore.Checked = false;
        }
        //**********************************************************************************************
        //Method:           private void CallbackFormClosingAnimation()                           
        //Purpose:          CLoses dialog
        //*********************************************************************************************
        private void CallbackFormClosingAnimation()
        {
            UI_CHKBOX_ShowAnimationSpeed.Checked = false;
        }
        //**********************************************************************************************
        //Method:           private void UI_Timer_Tick(object sender, EventArgs e)                             
        //Purpose:          to always check how many balls are on the screen
        //Returns:          score and stream writer
        //*********************************************************************************************
        private void UI_Timer_Tick(object sender, EventArgs e)
        {
            if (BallsAlive() > 0) // if the balls are still alive then keep running
            {
                Pick(); //select the ball on the screen
            }
            else
            {
                
                string fileName = $@"{difficulty}.txt"; // the file name of the mode they are in 
                StreamWriter name; //stringwriter variable for writing the file
                highscoredlg = new HighScore(); //showing the high score dialog
                UI_Timer.Enabled = false; // stop the program from checking all the time and constanly looping
                UI_BTN_Play.Enabled = true; //reenable the play button to play again
                canvas.Clear();   
                try
                {
                    string[] textfile = File.ReadAllLines(fileName); // to save the string into an array

                    foreach (string n in textfile) // it will read each line in the text file
                    {
                        string[] split = n.Split(':'); // it will split the value at the :
                        string value = split[1]; // it will take the left side of the value 0 : 1 it will take the one value
                        if (int.Parse(value) > highscore) // will check the value if it is higher than the set highscore of 0
                        {
                            //makes highscore into an int
                            highscore = int.Parse(value); // if it is then replace the highscore value with the new one
                        }

                    }
                    // to add the text to the canvas of the highest score of the difficulty
                    canvas.AddText($"Highscore for {difficulty} : {highscore}", 15, 250, 100, 300, 100, Color.Violet);
                }
                catch {}
                canvas.AddText("Game Over", 50);    //game over text
                canvas.AddText($"Score: {score}", 15, 300, 400, 200, 200, Color.Violet); // shoing current game score
                if (highscoredlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    { 
                        //to write to the file
                        using (name = new StreamWriter(fileName, true))
                        {
                            //writes it into the format for the "name : score"
                            name.WriteLine($"{highscoredlg.name}: {score}");
                            name.Close(); //closes the text file when done writing to it
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
