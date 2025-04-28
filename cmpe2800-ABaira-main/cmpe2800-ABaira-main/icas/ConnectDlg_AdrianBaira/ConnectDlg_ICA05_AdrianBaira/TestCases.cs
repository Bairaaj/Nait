/*
 *  ICA 05 Generic Connection Dialog - Test Cases
 *  CMPE2800 - A03
 *  Adrian Baira
 *  March 13, 2025
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDlg_AdrianBaira;
using System.Net;
namespace ConnectDlg_ICA05_AdrianBaira
{
    public partial class TestCases : Form
    {
        //Connection Dialog
        CDlg_AdrianB Connect = new CDlg_AdrianB();
        /// <summary>
        /// Initalize both forms applicaiton
        /// </summary>
        public TestCases()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close and Open a new Dialog to show for diifferent test cases
        /// </summary>
        private void UI_BTN_GABP_Click(object sender, EventArgs e)
        {
            UI_TXT_Results.Text = "";
            UI_TXT_Socketinfo.Text = "";
            if (Connect == null)
            {
                Connect = new CDlg_AdrianB(port: 12345, EnableAddress: true, EnablePort: false);
            }
            else
            {
                Connect.Close();
                Connect = new CDlg_AdrianB(port: 12345, EnableAddress: true, EnablePort: false);
            }
            if (Connect.ShowDialog() == DialogResult.No)
            {
                UI_TXT_Results.Text = $"Unsuccessful Connection";
                UI_TXT_Socketinfo.Text = $"{Connect.socket}";
            }
        }
        /// <summary>
        /// Close and Open a new Dialog to show for diifferent test cases
        /// </summary>
        private void UI_BTN_BA_Click(object sender, EventArgs e)
        {
            UI_TXT_Results.Text = "";
            UI_TXT_Socketinfo.Text = "";
            if (Connect == null)
            {
                Connect = new CDlg_AdrianB(address: "Testing", EnableAddress: false, EnablePort: true);
            }
            else
            {
                Connect.Close();
                Connect = new CDlg_AdrianB(address: "Testing", EnableAddress: false, EnablePort: true);
            }
            if (Connect.ShowDialog() == DialogResult.No)
            {
                UI_TXT_Results.Text = $"Unsuccessful Connection";
                UI_TXT_Socketinfo.Text = $"{Connect.socket}";
            }
        }
        /// <summary>
        /// Close and Open a new Dialog to show for diifferent test cases
        /// </summary>
        private void UI_BTN_GAGP_Click(object sender, EventArgs e)
        {
            UI_TXT_Results.Text = "";
            UI_TXT_Socketinfo.Text = "";
            if (Connect == null)
            {
                Connect = new CDlg_AdrianB();
            }
            else
            {
                Connect.Close();
                Connect = new CDlg_AdrianB();
            }
            DialogResult result = Connect.ShowDialog();
            if (result == DialogResult.OK)
            {
                UI_TXT_Results.Text = $"Connection Successful";
                UI_TXT_Socketinfo.Text = $"Remote: {Connect.socket.RemoteEndPoint} Local: {Connect.socket.LocalEndPoint}";
            }
            else if(result == DialogResult.No)
            {
                UI_TXT_Results.Text = $"Unsuccessful Connection";
                UI_TXT_Socketinfo.Text = $"{Connect.socket}";
            }
            
        }

    }
}
