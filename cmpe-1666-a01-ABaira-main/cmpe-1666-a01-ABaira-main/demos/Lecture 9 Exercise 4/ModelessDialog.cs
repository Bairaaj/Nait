using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture_9_Exercise_4
{
    public delegate void delChangeColor(Color color);
    public partial class ModelessDialog : Form
    {
        public delChangeColor _dchangeColor = null;
        
        public ModelessDialog()
        {
            InitializeComponent();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void UI_Red_Radio_CheckedChanged(object sender, EventArgs e)
        {
            Color col = Color.Red;
            if (UI_Red_Radio.Checked)
            {
                col = Color.Red;
            }
            if (UI_Purple_Radio.Checked)
            {
                col = Color.Purple;
            }
            if (UI_Yellow_Radio.Checked)
            {
                col = Color.Yellow;
            }
            _dchangeColor(col);
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
