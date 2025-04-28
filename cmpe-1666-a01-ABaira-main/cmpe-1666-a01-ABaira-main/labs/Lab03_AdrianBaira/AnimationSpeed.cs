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

namespace Lab03_AdrianBaira
{
    //initalizing delegates to use in the main form
    public delegate void delAnimationclose();
    public delegate void delAnimationSpeed(int speed);
    public partial class AnimationSpeed : Form
    {
        //setting the delegates to null 
        public delAnimationclose _dFormClosing = null;
        public delAnimationSpeed _dSpeed = null;
        public AnimationSpeed()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void AnimationSpeed_FormClosing(object sender, FormClosingEventArgs e)                            
        //Purpose:          delegate to close the form if they press the x at the top 
        //Returns:          dialog close
        //*********************************************************************************************
        private void AnimationSpeed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (null != _dFormClosing)
                {
                    _dFormClosing();
                }
                e.Cancel = true;
                Hide();
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_TrackBar_Scroll(object sender, EventArgs e)                           
        //Purpose:          to set the delegate to the value of the track bar
        //Returns:          value 
        //*********************************************************************************************
        private void UI_TrackBar_Scroll(object sender, EventArgs e)
        {
            _dSpeed(UI_TrackBar.Value);
        }
    }
}
