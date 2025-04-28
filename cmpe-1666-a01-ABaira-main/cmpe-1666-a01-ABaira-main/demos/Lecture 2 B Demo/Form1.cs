using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture_2_B_Demo
{
    public partial class Form1 : Form
    {
        string x = "";
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UI_Change_Btn_Click(object sender, EventArgs e)
        {
            UI_Display_lbl.Text = x;
            
            UI_Name_Tbx.Clear();

        }
        
        private void UI_Display_lbl_Click(object sender, EventArgs e)
        {
           
        }

        private void UI_Name_Tbx_TextChanged(object sender, EventArgs e)
        {
            x = UI_Name_Tbx.Text;
            
        }
    }
}