using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Lecture_10_Demo_3
{
    public delegate void delVoidString(string str);
    public partial class Form1 : Form
    {
        private int count = 0;
        Thread thread = null;
        bool runThread = true;
        public Form1()
        {
            InitializeComponent();
        }

        

        public void UI_BTN_CountClicks_Click(object sender, EventArgs e)
        {
            UI_LBL_Text.Text = $"Button has been clicked {++count} times ";
        }
        private void UI_BTN_PerformComputation_Click(object sender, EventArgs e)
        {
            UI_Listbox.Items.Clear();
            thread = new Thread(FindSine);
            thread.Start();

        }
        public void FindSine()
        {
            delVoidString delWriteSine = AddToListBox;

            for (double x = 0; x < 180; x = x + 0.05)
            {
                if(runThread)
                {
                    double rad = Math.PI * x / 180;
                    double sineValue = Math.Sin(rad);
                    //UI_Listbox.Items.Add($"{x:F2} degrees = {rad:F4} radians. Cos={sineValue:F4}");
                    string str = $"{x:F2} degrees = {rad:F4} radians.Sine ={sineValue: F4}";
                    try
                    {
                        Invoke(delWriteSine, str);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Delegate could not be invoked");
                    }
                    Thread.Sleep(50);
                }

                
            }
        }
        private void AddToListBox(string str)
        {
            UI_Listbox.Items.Add(str);
        }
        private void UI_Lisbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

}
