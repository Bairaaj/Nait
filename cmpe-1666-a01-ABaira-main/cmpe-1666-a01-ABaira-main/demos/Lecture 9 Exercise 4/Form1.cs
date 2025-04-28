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
    public partial class Form1 : Form
    {
        ModelessDialog mdlg = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void UI_BTN_Show_Click(object sender, EventArgs e)
        {
            this.BackColor = (Color.Red);
            if (mdlg == null) 
            { 
                mdlg = new ModelessDialog();
                mdlg._dchangeColor = callbackchangecolor;
                
            }
            mdlg.Show();
        }

        private void UI_BTN_btn_Click(object sender, EventArgs e)
        {
            if (mdlg != null)
            {
                mdlg.Hide();
            }
        }
        private void callbackchangecolor(Color c)
        {
            this.BackColor = c;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
