//****************************************************************************************************************************
//Program:          ICA 04 
//Description:      Equals Balls
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

namespace ICA_04AdrianBaira
{
    public partial class UI_Form : Form
    {
        #region Members

        List<Ball> balls = new List<Ball>();            //List of Balls
        int addedBalls = 0;                             //added balls onto the drawer
        int discardBalls = 0;                           //discared balls
        int RAD = 80;                                   //radius of the balls being put into the drawer

        #endregion

        #region CTOR

        /// <summary>
        /// Initalize the form
        /// subscribe to the mouse wheel event
        /// </summary>
        public UI_Form()
        {
            InitializeComponent();
            this.MouseWheel += UI_Form_MouseWheel;
            this.MouseClick += UI_Form_MouseClick;
            UI_BTN_Add.Text = $"Add Balls: Size {RAD}";
        }

        private void UI_Form_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Console.Write("test");
            }
            if(e.Button == MouseButtons.Right)
            {
                Console.Write("right");
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Mouse wheel event
        /// scrolling up increases the radius
        /// scrolling down decreases the radius
        /// </summary>
        private void UI_Form_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta < 0)
            {
                RAD--;
            }
            if(e.Delta > 0)
            {
                RAD++;
            }
            UI_BTN_Add.Text = $"Add Balls : Size {RAD}";
        }

        /// <summary>
        /// Button event
        /// Add balls into the list if exceed 25 then leave loop
        /// Discard balls if they overlap and exit loop when discard is 1000
        /// </summary>
        private void UI_BTN_Add_Click(object sender, EventArgs e)
        {
            Ball.Loading = true;
            discardBalls = 0;
            addedBalls = 0;
            while (addedBalls < 25 && discardBalls < 1000)
            {
                Ball ball = new Ball(RAD);
                if (balls.Contains(ball))
                {
                    discardBalls++;
                    UI_ProgressBar.Value = discardBalls;
                }
                else
                {
                    balls.Add(ball);
                    addedBalls++;
                    if(addedBalls > 25)
                    {
                        break;
                    }
                }           
            }
            this.Text = $"Loaded {addedBalls} distinct balls with {discardBalls} discards";
            foreach (Ball b in balls)
            {
                b.AddBall();
            }
            Ball.Loading = false;
        }

        /// <summary>
        /// Press escape and it will remove the balls in the list and show on the drawer
        /// </summary>
        private void UI_BTN_Add_KeyDown(object sender, KeyEventArgs e)
        {
            Ball.Loading = true;
            if (e.KeyCode == Keys.A)
            {
                balls.Clear();
                
               
            }
            Ball.Loading = false;
        }
        #endregion
    }
}
