using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture_2B_Demo3
{
    public partial class Form1 : Form
    {
        string user = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void UI_Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = user;
            MessageBox.Show($"The Name given was: {user}");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
