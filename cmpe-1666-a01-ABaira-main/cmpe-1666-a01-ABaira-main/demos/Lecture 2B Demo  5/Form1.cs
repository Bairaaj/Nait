using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture_2B_Demo__5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value1;
            int value2;

            bool check1;
            bool check2;

            check1 = int.TryParse(textBox1.Text, out value1);
            

            if (!check1)
            {
                MessageBox.Show("Invalid Number");
                textBox1.Clear();
            }
            check2 = int.TryParse(textBox1.Text, out value2);
            if (!check2)
            {
                MessageBox.Show("Invalid number");
                textBox2.Clear();
            }

            textBox3.Text = $"{value1 + value2}";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
