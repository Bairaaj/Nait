//****************************************************************************************************************************
//Program:          ICA 03 
//Description:      Static Balls of Fun
//Date:             Sept, 20, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
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
using System.Numerics;
using GDIDrawer;
using System.Threading;

namespace ICA_03_AdrianB
{
    public partial class Form1 : Form
    {
        #region Members

        List<Ball> balls = null;    //First create a balls list and initalize it to null
        double oVal = 5.0;          //radius value for the balls

        #endregion

        #region CTOR
        /// <summary>
        /// Initalization of a thread and new ball list
        /// </summary>
        public Form1()
        {
            InitializeComponent();                                  //initalizing the form
            this.MouseWheel += Mouse_Wheel_Event;                   //subscribing to the mousewheel event
            balls = new List<Ball>();                               //creating a new list of ball
            Thread thread = new Thread(() => { ThreadLoop(); });    //making a thread for the thread loop 
            thread.IsBackground = true;                             //making it a background thread
            thread.Start();                                         //start the thread as soon as the form is loaded
           
        }
        #endregion

        #region Methods
        /// <summary>
        /// Using a tenth of the e.delta value to change all the balls radius
        /// </summary>
        private void Mouse_Wheel_Event(object sender, MouseEventArgs e)
        {    
            if (e.Delta < 0.0)
            {
                oVal += (-1.0 * e.Delta) / 10.0;
            }
            if (e.Delta > 0.0)
            {
                oVal -= e.Delta / 10.0;
            }
            if (balls.Count <= 0)
            {
                return;
            }
            Ball.rad = (int)oVal;
        }
        /// <summary>
        /// KeyDown handler
        /// Add -to add 5 balls to the list
        /// Subtract -to clear the list
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                for(int i = 0; i < 5; i++)
                {
                    balls.Add(new Ball());
                }
            }
            if (e.KeyCode == Keys.Subtract)
            {
                balls.Clear();     
            }
        }
        /// <summary>
        /// Infinite loop until user closes form
        /// </summary>
        private void ThreadLoop()
        {
            while (true)
            {
                //only doesthis if there is balls in the list otherwise it would crash
                if (balls.Count > 0)
                {   
                    Ball.Loading = true;        //displaying the balls to the drawer
                    foreach(Ball b in balls)
                    {
                        b.MoveBall();           //moving the balls on the drawer
                        b.ShowBall();           //drawing the ball on the drawer
                    }
                    Ball.Loading = false;       //clearing the drawer to show movement
                    Thread.Sleep(25);           //sleep thread

                }
            }
        }
        #endregion
    }
}
