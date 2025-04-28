//****************************************************************************************************************************
//Program:          ICA 02 
//Description:      Bouncy Properties
//Date:             Sept, 12, 2024
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

namespace ICA02_AdrianB
{
    public partial class Form1 : Form
    {
        #region Members
        CDrawer canvas = null;                          //Initalize the Canvas
        List<Ball> balls = new List<Ball>();            // Make a new list of Class Ball
        int opacity_;                                   //Opactity 
        int radius_;                                    //Radius
        #endregion

        #region CTOR
        /// <summary>
        /// Initalize the form and creating a new drawer
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            canvas = new CDrawer();                                     // initalizing theee drawer
            canvas.ContinuousUpdate = false;                            // setting Continuous update to false
            UI_TXT_Rad.MouseWheel += UI_TXT_Rad_MouseWheel;             // Radius Text mouse wheel event
            UI_TXT_Opacity.MouseWheel += UI_TXT_Opacity_MouseWheel;     // Opacity text Mouse wheel event
            radius_ = 50;
            opacity_ = 128;
            UI_TXT_Opacity.Text = $"{opacity_}";                        // setting the Opacity text
            UI_TXT_Rad.Text = $"{radius_}";                             // setting the radius text
            
        }
        #endregion

        #region Methods
        /// <summary>
        /// When user Clickes text box and uses scroll wheel it will change the opacity of the balls
        /// </summary>
        private void UI_TXT_Opacity_MouseWheel(object sender, MouseEventArgs e)
        {
            //changing the ball opacity
            if (e.Delta < 0)
            {
                opacity_ -= 10;                     //reducing the opacity by 10
                if (opacity_ < 64)
                {
                    opacity_ = 64;                  //if the opacity user is less than 64 then set it to 64
                }
            }
            else if (e.Delta > 0)
            {
                opacity_ += 10;                     //adding to the opacity by 10
                if (opacity_ > 255)
                {
                    opacity_ = 255;
                }
            }
            ChangeBall();
            UI_TXT_Opacity.Text = $"{opacity_}"; //Updating the UI
        }

        /// <summary>
        /// when user  clicks the textbox of the radius and uses scroll wheel it will chnage the radius of the balls
        /// </summary>
        private void UI_TXT_Rad_MouseWheel(object sender, MouseEventArgs e)
        {
            // Changing the radius of the ball
            if (e.Delta < 0)
            {
                radius_--;                      //decement the radius value
                if (radius_ <= 0)
                {
                    radius_ = 1;
                }
            }
            else if (e.Delta > 0)
            {
                if (radius_++ >= 100)           //increment and restrict the size of the radius
                {
                    radius_ = 100;
                }
            }
            ChangeBall();
            UI_TXT_Rad.Text = $"{radius_}";     //Update the UI
        }

        /// <summary>
        /// Every Tick it will render the ball onto the canvas and show that the ball is moving and if the check box is checked 
        /// then it will do all the balls or just the last one
        /// </summary>
        private void UI_TIMER_Tick(object sender, EventArgs e)
        {

            //Adds a new ball into the list
            if (canvas.GetLastMouseLeftClick(out Point leftClick))
            {
                balls.Add(new Ball(leftClick));
            }

            //To clear all balls from the list and reset the drawer
            else if(canvas.GetLastMouseRightClick(out Point rightClick))
            {
                balls.Clear();
                canvas.Render();
            }


            canvas.Clear();
            ///To render all the balls onto the Canvas and Moving them
            foreach (Ball b in balls)
            {
                b.MoveBall(canvas);
                b.ShowBall(canvas);
                canvas.Render();
            }
            if(balls.Count > 0)
            {
                UI_TXTBOX_Display.Text = $"{balls[balls.Count - 1]}";
            }
         


        }
        /// <summary>
        /// Helper Method to change thball when user hover mover the text box
        /// </summary>
        public void ChangeBall()
        {
            if(balls.Count <= 0)
            {
                return;
            }
            //If the Check Box is checked then it will change the opacity and radius of all the balls
            if (UI_CHKBOX_All.Checked)
            {
                //foreach ball on the drawer change its opacity and radius
                foreach (Ball b in balls)
                {
                    if(UI_TXT_Rad.Focused)
                    {
                        b.rad = radius_;
                    }
                    if(UI_TXT_Opacity.Focused)
                    {
                        b.opacity = opacity_;
                    }
                }
            }

            //Will only chnage the last ball that was put onto the drawer and change its radius and Opacity
            else
            {
                if (UI_TXT_Rad.Focused)
                {
                    balls[balls.Count - 1].rad = radius_;
                }
                if (UI_TXT_Opacity.Focused)
                {
                    balls[balls.Count - 1].opacity = opacity_;
                }
               

            }
        }
        #endregion
    }
}
