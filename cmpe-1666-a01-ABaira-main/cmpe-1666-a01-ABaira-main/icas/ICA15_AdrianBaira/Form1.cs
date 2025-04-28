//****************************************************************************
//Program: ICA15 Adrian
//Description: Bit map color %
//Date: Nove, 21, 2023
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ICA15_AdrianBaira
{
    public delegate void delgetcolor(double red, double green, double blue, string filename);
    public partial class Form1 : Form
    {
        public List<Thread> threadlist = new List<Thread>();
        public Form1()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Go_Click(object sender, EventArgs e)       
        //Purpose:          to open file and create a new thread foreach file given
        //Returns:          adds items into the list<thread>
        //**********************************************************************************************
        private void UI_BTN_Go_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = true;
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                UI_ListBox.Items.Add($"Starting...");
                timer1.Start();
                foreach (string file in openfile.FileNames)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(getColor));
                    thread.IsBackground = true;
                    thread.Start(file);
                    threadlist.Add(thread);
                    
                }
            }
            
        }
        //**********************************************************************************************
        //Method:           private void getColor(object filename)         
        //Purpose:          to find the bitmap colors and be able for it to be passed to a list 
        //Returns:          uses delegate of the add to list box and allow it to show in textbox and passes paramaters
        //**********************************************************************************************
        private void getColor(object filename)
        {
            int red = 0;
            double redp = 0;
            int green = 0;
            double greenp = 0;
            int blue = 0;
            double bluep = 0;
            try
            {
                Bitmap bm = (Bitmap)Bitmap.FromFile((string)filename);
                for (int x = 0; x < bm.Width; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        Color pixel = bm.GetPixel(x, y);
                        red += pixel.R;
                        green += pixel.G;
                        blue += pixel.B;
                    }
                }
                double totalc = (red + green + blue);
                redp = (red / totalc) * 100.0;
                greenp = (green / totalc) * 100.0;
                bluep = (blue / totalc) * 100.0;
                delgetcolor color = addtolistbox;
                Invoke(color, redp, greenp, bluep, (string)filename);
            }
            catch
            {
                MessageBox.Show("Invalid File");
            }        
        }
        //**********************************************************************************************
        //Method:           private void addtolistbox(double red, double green, double blue, string filename)
        //Peramaters:       double red  --red value
        //                  double green    --green value
        //                  double blue --blue value
        //                  string filename --file name
        //Purpose:          To show the items in the listbox
        //Returns:          result of textbox
        //**********************************************************************************************
        private void addtolistbox(double red, double green, double blue, string filename)
        {
            UI_ListBox.Items.Add($"(R:{red:F1}%, G:{green:F1}%, B:{blue:F1}%) {filename}");        
        }
        //**********************************************************************************************
        //Method:           private bool checkstate()         
        //Purpose:          To constantly check the list when the timer is running
        //Returns:          True or false
        //**********************************************************************************************
        private bool checkstate()
        {
            foreach (Thread threads in threadlist)
            {
                if (threads.ThreadState != System.Threading.ThreadState.Stopped)
                {
                    return false;
                }
            }
            return true;
        }
        //**********************************************************************************************
        //Method:           private void timer1_Tick(object sender, EventArgs e)          
        //Purpose:          To only print when returns true
        //Returns:          Listbox item
        //**********************************************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(checkstate())
            {
                UI_ListBox.Items.Add("Done...");
                timer1.Stop();
            }
        }
    }
}
