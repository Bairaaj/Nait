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
    public partial class HighScore : Form
    {
        //to get a string name to be able to call it in main form
        public string name { get {  return UI_TXTBox_Name.Text; } }

        public HighScore()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_OK_Click(object sender, EventArgs e)                          
        //Purpose:          will save the values if user presses ok
        //Returns:          highscore name
        //*********************************************************************************************
        private void UI_BTN_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Cancel_Click(object sender, EventArgs e)                         
        //Purpose:          to close the dialog and not save a value
        //Returns:          nothing
        //*********************************************************************************************
        private void UI_BTN_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
