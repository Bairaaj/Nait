using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeLabExam
{
    public partial class Form1 : Form
    {
        MyTimer timer = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new MyTimer(100);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Text = $"{timer.Ticks}";
        }
    }

    public class MyTimer : Timer
    {
        public UInt32 Ticks { get; private set; } = 0;

        public MyTimer(int iInterval)
        {
            Interval = iInterval;
            Tick += MyTimer_Tick;
            Enabled = true;
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            Ticks++;    
        }
    }
}
