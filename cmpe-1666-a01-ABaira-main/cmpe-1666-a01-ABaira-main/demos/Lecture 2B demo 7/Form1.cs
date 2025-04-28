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
using System.Net.Http.Headers;

namespace Lecture_2B_demo_7
{
    public partial class Form1 : Form
    {
        int count;
        Stopwatch sw = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            count = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            this.Text = $"Counting {count} - Elapsed time {sw.ElapsedMilliseconds} msec";

            if (count %20 == 0)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sw.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sw.Stop();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sw = new Stopwatch();
            sw.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sw.Start();
        }
    }
}
