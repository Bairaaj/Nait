using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question1Practice
{
    public partial class Form1 : Form
    {
        DerivedTimer timer = null;
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            Click += Form1_Click;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Text = $"{timer._ticks}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new DerivedTimer(100);
            timer.Start();
        }
    }
    public class DerivedTimer : Timer
    {
        public int _ticks { get; private set; } = 0;

        public DerivedTimer(int ticks)
        {
            base.Interval = ticks;
            base.Tick += DerivedTimer_Tick;
            base.Enabled = true;
        }

        private void DerivedTimer_Tick(object sender, EventArgs e)
        {
            _ticks++;
        }
    }

}
