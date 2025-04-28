//****************************************************************************************************************************
//Program:          ICA 06 
//Description:      Equals Balls
//Date:             Sept, 30, 2024
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
using System.Threading;
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
            UI_BTN_Add.Text = $"Add Balls: Size {RAD}";
            UI_RAD_Radius.CheckedChanged += UI_RADIO_CheckChange;
            UI_RAD_Distance.CheckedChanged += UI_RADIO_CheckChange;
            UI_RAD_Color.CheckedChanged+= UI_RADIO_CheckChange;
        }

        

        private void UI_Form_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta < 0)
                RAD--;

            if (e.Delta > 0)
                RAD++;

            if(RAD == 0)
                RAD = 1;

            UI_BTN_Add.Text = $"Add Balls : Size {RAD}";
        }
        #endregion

        #region Methods

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

                    //Leave condition to leave the loop if 25 balls were added
                    if(addedBalls > 25)
                        break;

                }           
            }

            this.Text = $"Loaded {addedBalls} distinct balls with {discardBalls} discards";
            foreach (Ball b in balls)
                b.AddBall();

            Ball.Loading = false;
        }

        /// <summary>
        /// Using ReferenceEquals to check which radio button was pressed and sort accordingly using static methods within the Ball Class
        /// </summary>
        /// <param name="sender">Object of Radio Button being clicked</param>
        private void UI_RADIO_CheckChange(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                Ball.Loading = true;

                if (ReferenceEquals(sender, UI_RAD_Radius))
                    balls.Sort();


                else if (ReferenceEquals(sender, UI_RAD_Distance))
                    balls.Sort(Ball.CompareDistance);


                else if (ReferenceEquals(sender, UI_RAD_Color))
                    balls.Sort(Ball.CompareColor);


                //To Render each Ball into the drawer and sleep to make it 'look' like its being sorted in real time
                foreach (Ball b in balls)
                {
                    b.AddBall();
                    Thread.Sleep(20);
                    Ball.Loading = false;
                }
            }
            
        }

        /// <summary>
        /// Press escape and it will remove the balls in the list and show on the drawer
        /// </summary>
        private void UI_GroupBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Ball.Loading = true;
                balls.RemoveRange(0,balls.Count / 2);

                foreach (Ball b in balls)
                    b.AddBall();

                Ball.Loading = false;

            }
        }

        #endregion

    }
}
