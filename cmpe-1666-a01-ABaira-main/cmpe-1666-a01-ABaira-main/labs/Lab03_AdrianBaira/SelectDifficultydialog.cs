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
    public partial class SelectDifficultydialog : Form
    {
        //set the inital level to 3
        public int level = 3;
        public int difficulty
        {
            //return the value for the enum
            get { return level; }
        }
        public SelectDifficultydialog()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Cancel_Click(object sender, EventArgs e)                       
        //Purpose:          close the dialog
        //Returns:          nothing
        //*********************************************************************************************
        private void UI_BTN_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //**********************************************************************************************
        //Method:           private void UI_RADIO_Easy_CheckedChanged(object sender, EventArgs e)                       
        //Purpose:          to allow user to choose a level
        //Returns:          enum
        //*********************************************************************************************
        private void UI_RADIO_Easy_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_RADIO_Easy.Checked)
            {
                level = 3;
            }
            else if (UI_RADIO_Medium.Checked)
            {
                level = 4;
            }
            else if (UI_RADIO_Hard.Checked)
            {
                level = 5;
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_OK_Click(object sender, EventArgs e)                        
        //Purpose:          If dialog result is ok then close form
        //Returns:          closed form with values pass to main
        //*********************************************************************************************
        private void UI_BTN_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
