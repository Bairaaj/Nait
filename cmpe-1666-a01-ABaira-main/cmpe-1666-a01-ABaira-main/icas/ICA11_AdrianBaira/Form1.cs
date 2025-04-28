//*************************************************************************************************
//Program: ICA11 Adrian
//Description: Fontify
//Date: OCT, 31, 2023
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

namespace ICA11_AdrianBaira
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string CurrentColor;  //public string of current value
        public static string CurrentFont;   //Public string of current value
        //**********************************************************************************************
        //Method:           private void UI_LABEL_Click(object sender, EventArgs e)
        //Purpose:          to call other form
        //Returns:          values obtained from the forms
        //**********************************************************************************************
        private void UI_LABEL_Click(object sender, EventArgs e)
        {
            CurrentColor = UI_LABEL.ForeColor.ToString();
            CurrentFont = UI_LABEL.Font.ToString();

            SupportDiocs support = new SupportDiocs();

            support.GetFont = UI_LABEL.Font;
            support.GetColor = UI_LABEL.ForeColor;

            if (support.ShowDialog() == DialogResult.OK)
            {
                UI_LABEL.Font = support.GetFont;
                UI_LABEL.ForeColor = support.GetColor;
            }
        }
    }
}
