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
    public delegate void delVoidString(string s);
    public delegate void delStringVoid();
    public partial class ModelessDialogForm : Form
    {
        public delVoidString _dTextChanged = null;
        public delStringVoid _dFormClosing = null;
        public ModelessDialogForm()
        {
            InitializeComponent();
        }

        private void UI_Textbox_TextChanged(object sender, EventArgs e)
        {
            if (_dTextChanged != null) 
            {
                _dTextChanged.Invoke(UI_Textbox.Text);
            }

        }

        private void ModelessDialogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (null != _dFormClosing)
                {
                    _dFormClosing();
                }
                e.Cancel = true;

                Hide();
            }
            
           
        }
    }
}
