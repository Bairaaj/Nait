/*
 *  ICA 05 Generic Connection Dialog - Connection Dialog
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
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDlg_AdrianBaira;
using System.Net.Sockets;
namespace ConnectDlg_AdrianBaira
{
    public partial class CDlg_AdrianB : Form
    {
        // Socket
        public Socket socket { get; private set; } = null;
        private Socket _Socket = null;
        bool EA = false;
        bool EP = false;
        /// <summary>
        /// Connection Dialog
        /// Setting the windows dialog to allow connection from another client
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="EnableAddress"></param>
        /// <param name="EnablePort"></param>
        /// <exception cref="ArgumentException"></exception>
        public CDlg_AdrianB(string address = "www.microsoft.com", int port = 80, bool EnableAddress = true, bool EnablePort = true)
        {
            InitializeComponent();
            EA = EnableAddress;
            EP = EnablePort;
            UI_TXT_IPAddress.Enabled = EnableAddress;
            UI_TXT_Port.Enabled = EnablePort;

            UI_TXT_IPAddress.Text = address;
            UI_TXT_Port.Text = port.ToString();


            if (address.Length <= 1 && EnableAddress)
            {
                UI_TXT_Log.Text = "Please enter a valid IP address";
            }
            if(address.Length <= 1 && !EnableAddress)
            {
                UI_TXT_Log.Text = "Please enter a valid IP address";
                throw new ArgumentException("Must have a valid IP Address");
            }
            if(port <= 0 && EnablePort)
            {
                UI_TXT_Log.Text = "Please enter a valid Port";
            }
            if(port <= 0 && !EnablePort)
            {
                UI_TXT_Log.Text = "Please enter a Port";
                throw new ArgumentException("Must have a valid Port");
            }


        }

        private void UI_BTN_Exit_Click(object sender, EventArgs e)
        {
            //if(_Socket == null)
            //{
            //    Log("You are not connected to anyone");
            //}
            //else
            //{
            //    _Socket.Close();
            //    _Socket = null;
            //    Log("Connection Stopped");
            //}
            //socket = null;
            DialogResult = DialogResult.No;
        }

        async private void UI_BTN_Connect_Click(object sender, EventArgs e)
        {
            if(UI_TXT_IPAddress.Text.Length <= 1)
            {
                UI_TXT_Log.Text = "Please enter a valid IP address";
                return;
            }
            if (UI_TXT_Port.Text.Length <= 0)
            {
                UI_TXT_Log.Text = "Please enter a valid Port";
                return;
            }

            try
            {
                UI_TXT_IPAddress.Enabled = false;
                UI_TXT_Port.Enabled = false;
                Log("Attempting to Connect...");
                _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                await _Socket.ConnectAsync(UI_TXT_IPAddress.Text, int.Parse(UI_TXT_Port.Text));
            }
            catch(SocketException ex)
            {
                Log($"Socket Exception: {ex.Message}");
                _Socket = null;
                UI_TXT_IPAddress.Enabled = EA;
                UI_TXT_Port.Enabled = EP;
                return;
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine($"{ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
                _Socket = null;
                UI_TXT_IPAddress.Enabled = EA;
                UI_TXT_Port.Enabled = EP;
                return;
            }
            socket = _Socket;
            DialogResult = DialogResult.OK;
        }
        private void Log(string message)
        {
            if(InvokeRequired)
            {
                Invoke((Action)(() => { Log(message); })); 
                return;
            }
            UI_TXT_Log.Text = message;
        }

        private void CDlg_AdrianB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(socket != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                socket = null;
                DialogResult = DialogResult.No;
            }
        }
    }
    
}
