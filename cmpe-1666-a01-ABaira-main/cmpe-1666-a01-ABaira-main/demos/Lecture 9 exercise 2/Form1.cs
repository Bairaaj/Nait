using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture_9_exercise_2
{
    public partial class Form1 : Form
    {
        delegate int delBinaryop(int x, int y);
        public Form1()
        {
            InitializeComponent();
        }
        delBinaryop delop = null;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private int addition(int x, int y) 
        {
            return x + y;
        }
        private int multi(int x, int y)
        {
            return x * y;
        }
        private int div(int x, int y)
        {
            return x / y;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int num1;
            int num2;

            int.TryParse(textBox1.Text, out num1);
            int.TryParse(textBox2.Text, out num2);
            if(radioButton1.Checked)
            {
                delop = new delBinaryop(addition);
            }
            else if (radioButton2.Checked)
            {
                delop = new delBinaryop(multi);
            }
            else 
            {
                delop = new delBinaryop(div);

            }
            textBox3.Text = $"{delop(num1, num2)}";
        }
    }
}
