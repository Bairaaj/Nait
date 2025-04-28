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
    //delegate to be called in main
    public delegate void delscore();
    public partial class Score : Form
    {
        //setting the score as public 
        public int score;
        public int scores 
        {
            get 
            {
                //gets the score as a text and parses it as a int to return in main form
                int.TryParse(UI_LBL_Points.Text, out score);
                return score;  
                //it will set the value as a string when given an int
            } set { UI_LBL_Points.Text = value.ToString(); } 
        }

        public delscore _dFormClosing = null;   
        public Score()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void Score_FormClosing(object sender, FormClosingEventArgs e)                        
        //Purpose:          will close the dialog when user press x at the top
        //Returns:          hidden dialog
        //*********************************************************************************************
        private void Score_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                if (null != _dFormClosing) 
                {
                    _dFormClosing();
                }
                e.Cancel = true;
                Hide();
            }
        }
    }
}
