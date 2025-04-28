//****************************************************************************
//Program: ICA03 Adrian
//Description: Stopwatch
//Date: Sept, 20, 2023
//Author: Adrian Baira
//Course: CMPE1666
//Class: CNTA01
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ICA_03_AdrianBaira
{
    public partial class Form1 : Form
    {
        Stopwatch sw = new Stopwatch(); //initalize timer
        public Form1()
        {
            //initalize form window
            InitializeComponent();
        }

        private void UI_Start_Button_Click(object sender, EventArgs e)
        {
            //starts the timer
            sw.Start();
                     
        }
        private void UI_StopButton_Click(object sender, EventArgs e)
        {
            //stops the timer
            sw.Stop();        
        }
        private void UI_ResetButton_Click(object sender, EventArgs e)
        {
            //resets the timer
            sw.Reset();   
            //rtesets the items in the listbox
            UI_LabelBox.Items.Clear();
        }
        //**********************************************************************************************
        //Method:           static private void GetValue(string promt, int min, int max, out int value)
        //Peramaters:       String text - to return string
        //                  Timespan -  for time
        //Purpose:          To format string
        //Returns:          string- value accepted by the method  
        //*********************************************************************************************
        private void Formatting(TimeSpan time, out string text)
        {
            text = string.Format("({0}) {1:00}:{2:00}:{3:00}:{4:00}", time.Days, time.Hours, time.Minutes, time.Seconds, time.Milliseconds / 10);
        }
        //**********************************************************************************************
        //Method:           to continusly update label text
        //Peramaters:       String text - to return string
        //                  Timespan -  for time
        //Purpose:          to show time
        //Returns:          shows timer and siplays on label boxc
        //*********************************************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            //allows for it to be used in days easer
            string text = "";
            TimeSpan time = sw.Elapsed;
            Formatting(time, out text);
            UI_Label.Text = text;
       
        }

        private void UI_SplitButton_Click(object sender, EventArgs e)
        {
            //will show the stop watch how much time went by and display in listbox
            //and if there is duplicates it will only print once
            if (!UI_LabelBox.Items.Contains(UI_Label.Text))
            {
               UI_LabelBox.Items.Add(UI_Label.Text);
            }

            
           
        }
    }
}
