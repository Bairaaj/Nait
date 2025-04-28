using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture_9_demo_3
{
    public partial class Form1 : Form
    {
        //to grab the other form and be able to use it
        ModelessDialogForm dlg = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        private void UI_ShowDialog_Cbx_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_ShowDialog_Cbx.Checked)
            {
                if (dlg == null)
                {
                    dlg = new ModelessDialogForm();
                    dlg._dTextChanged = CallBackTextChanged;
                    dlg._dFormClosing = callBackFormclosing;
                }
                dlg.Show();

            }
            else
            {
                dlg.Hide();
            }

        }
        private void CallBackTextChanged(string s)
        {
            UI_DialogText_Lbl.Text = s;
        }
        private void callBackFormclosing()
        {
            UI_ShowDialog_Cbx.Checked = false;
        }
    }
    
}
