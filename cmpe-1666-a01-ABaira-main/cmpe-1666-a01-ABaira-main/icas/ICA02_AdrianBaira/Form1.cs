//****************************************************************************
//Program: ICA02 Adrian
//Description: shows windows form and event
//Date: Sept, 12, 2023
//Author: Adrian Baira
//Course: CMPE1666
//Class: CNTA01
//20 Sept 2023 - created and finished
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdrianBaira_ICA02
{
    public partial class Form1 : Form
    {
        //inizalize window and print the event
        public Form1()
        {
            InitializeComponent();
            //displays the text
            Console.WriteLine("From Constructor event");
        }
        //when it loads the window
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Form Load event");

        }
        //when the window closes it shows the "Form Closing event" processing to close the event
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Form Closing event");
        }
        //When the window is being pressed when minized
        private void Form1_Activated(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Form Activated event");
        }
        //when it changes the window of the application
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Form Paint event");
        }
        //when user closes the application the event 
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Form Closed event");
        }
        //when the window is minimized
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Form Deactivate event");
        }
        //it will show the window when it is inialized
        private void Form1_Shown(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Form Shown event");
        }
    }
}
