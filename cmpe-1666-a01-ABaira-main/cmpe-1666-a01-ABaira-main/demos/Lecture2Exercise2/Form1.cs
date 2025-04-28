using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture2Exercise2
{
    public partial class Form1 : Form
    {
        int toggle = 0;
        int numberTimes = 0;
        public Form1()
        {
            InitializeComponent();
            Text = "This is a nice form";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            numberTimes++;
            if (toggle == 0)
            {
                toggle = 1;
                Text = $"The mouse has be clicked {numberTimes} times";
            }
            else
            {
                toggle = 0;
                Text = "This is a nice form";
            }
        }
    }
}
