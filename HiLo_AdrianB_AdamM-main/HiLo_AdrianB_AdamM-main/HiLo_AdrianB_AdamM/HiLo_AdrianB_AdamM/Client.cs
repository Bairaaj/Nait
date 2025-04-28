/// Project: HiLo_AdrianB_AdamM
/// Authors: Adrian Baira, Adam Mwanza
/// Client side of the HiLo game
/// ////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDlg_AdamMwanza;
using ConnectDlg_AdrianBaira;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using System.Collections;
using Server;
namespace HiLo_AdrianB_AdamM
{
    public partial class Client : Form
    {
        private string _addr = null;    //holds server address
        private int _port = 0;  //holds server port
        bool _connected = false;   //holds connection status
        Socket _client = null; //holds client socket
        Form1 server = null;
        public int _guess { get; private set; } = -1;
        public Client()
        {
            InitializeComponent();
            server = new Form1();
            server.Show();
        }
        /// <summary>
        /// enabling ui and subscribing to events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_Load(object sender, EventArgs e)
        {
            UI_DisCo_Button.Enabled = false;
            UI_Connect_TM2_Button.Click += UI_Connect_TM2_Button_Click;
            UI_GuessButton.Click += UI_GuessButton_Click;
            UI_TrackBar.Value = UI_TrackBar.Maximum / 2;
            UI_Label_2.Text = $"{UI_TrackBar.Value}";
            UI_TrackBar.ValueChanged += UI_TrackBar_ValueChanged;
            UI_DisCo_Button.Click += UI_DisCo_Button_Click;
            Log("Not connected!");
        }
        /// <summary>
        /// Disconnects client from the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_DisCo_Button_Click(object sender, EventArgs e)
        {
            _client.Shutdown(SocketShutdown.Both);
            Log("You soft disconnected from server");
            UI_Connect_TM1_Button.Enabled = true;
            UI_Connect_TM2_Button.Enabled = true;
            UI_DisCo_Button.Enabled = false;
        }

        private void UI_TrackBar_ValueChanged(object sender, EventArgs e)
        {
            UI_Label_2.Text = $"{UI_TrackBar.Value}";
        }
        /// <summary>
        /// sends a guess to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UI_GuessButton_Click(object sender, EventArgs e)
        {
            if (_connected && _client != null)
            {
                _guess = UI_TrackBar.Value;
                Console.WriteLine($"Guess: {_guess}");
                object sent = new Send { guess = _guess };

                //Converts the object to a json string and sends it to the server
                string sframe = JsonConvert.SerializeObject(sent);
                byte[] sbuff = Encoding.UTF8.GetBytes(sframe);
                ArraySegment<byte> buffer = new ArraySegment<byte>(sbuff);
                _client.SendAsync(buffer, SocketFlags.None);
                Trace.WriteLine("Sent Guess");
                if(_client == null)
                {
                    Console.WriteLine("Inside");
                }
            }
            if (_client == null)
            {
                Console.WriteLine("outside");
            }
        }
        private void UI_Connect_TM2_Button_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("Connecting");
            ConnectDlg_AdamMwanza.ConnectionDialog dlg = null;
            //On the first connection, user mast manually enter server details. After a successful connection,
            //the last successful connection details are automatically entered
            if (_addr == null)
                dlg = new ConnectionDialog();
            else
                dlg = new ConnectionDialog(_addr, _port);
            _client = null;
            //Sets client properties on a successful connection and begins reading from server
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _client = dlg.Client;   
                _connected = true;
                _addr = dlg.Address;
                _port = dlg.Port;
                Trace.WriteLine($"Connected to {_addr} on {_port}");
                Log("Connected");
                UI_Connect_TM1_Button.Enabled = false;
                UI_Connect_TM2_Button.Enabled = false;
                UI_DisCo_Button.Enabled = true;
                RxMessage();
            }
            else
            {
                UI_Connect_TM1_Button.Enabled = true;
                UI_Connect_TM2_Button.Enabled = true;
                UI_DisCo_Button.Enabled = false;
                _connected = false;
            }
        }
        /// <summary>
        /// Opens the connection dialog so user can pick what server to connect to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_Connect_TM1_Button_Click(object sender, EventArgs e)
        {
            CDlg_AdrianB connect1 = null;
            Trace.WriteLine("Connecting");
            _client = null;
            if (_addr == null)
                connect1 = new CDlg_AdrianB("10.132.9.5", 1666);
            else
                connect1 = new CDlg_AdrianB(_addr, _port);

            //Sets client properties on a successful connection and begins reading from server
            if (connect1.ShowDialog() == DialogResult.OK)
            {
                _client = connect1.socket;
                _connected = true;
                IPEndPoint remoteEndPoint = connect1.socket.RemoteEndPoint as IPEndPoint;

                _addr = remoteEndPoint.Address.ToString();
                _port = remoteEndPoint.Port;

                UI_Connect_TM1_Button.Enabled = false;
                UI_Connect_TM2_Button.Enabled = false;
                UI_DisCo_Button.Enabled = true;
                Log("Connected");
                RxMessage();
            }
            else
            {
                UI_Connect_TM1_Button.Enabled = true;
                UI_Connect_TM2_Button.Enabled = true;
                UI_DisCo_Button.Enabled = false;
                _connected = false;
            }
            
        }
        private async void RxMessage()
        {
            //segment taken from sockets demo
            int RxBytes = -1; // Number of bytes received
            byte[] buff = new byte[2048]; // actual buffer to use
            ArraySegment<byte> buffSegment = new ArraySegment<byte>(buff); // Segment mapped to buff.

            while (_connected)
            {
                try
                {
                    // Attempt to receive data from the server
                    RxBytes = await _client.ReceiveAsync(buffSegment, SocketFlags.None);
                    // If no data was received, the server has disconnected
                    if (RxBytes == 0)
                    {
                        Log("Soft Disconnect");
                        _client = null;
                        _connected = false;
                        UI_TrackBar.Minimum = 1;
                        UI_TrackBar.Maximum = 1000;
                        UI_TrackBar.Value = 500;
                        break;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show($"Error: {err.Message}");
                    UI_Connect_TM1_Button.Enabled = true;
                    UI_Connect_TM2_Button.Enabled = true;
                    UI_TrackBar.Minimum = 1;
                    UI_TrackBar.Maximum = 1000;
                    UI_TrackBar.Value = 500;
                    Log("Hard Disconnect.");
                    return;
                }
                // Parse out the received data intoa json object
                string sData = Encoding.UTF8.GetString(buff);
                var data = System.Text.Json.JsonSerializer.Deserialize<Send>(Encoding.UTF8.GetString(buff, 0, RxBytes));
                Console.WriteLine($"Received: {data.response}");
                switch (data.response)
                {
                    // If the guess is too low then adjust the trackbar accordingly
                    case -1:
                        {
                            UI_TrackBar.Minimum = _guess;
                            Log($"TOO LOW You Guessed {data.guess}");
                            UI_Label_1.Text = $"{_guess}";
                            UI_TrackBar.Value = Trackbar();
                            break;
                        }
                    case 0:
                        {
                            Log($"CORRECT You Guessed {data.guess}");
                            UI_TrackBar.Minimum = 1;
                            UI_TrackBar.Maximum = 1000;
                            UI_TrackBar.Value = 500;
                            break;
                        }
                    // If the guess is too high then adjust the trackbar accordingly
                    case 1:
                        {
                            Log($"TOO HIGH You Guessed {data.guess}");
                            UI_TrackBar.Maximum = _guess;
                            UI_Label_1000.Text = $"{_guess}";
                            UI_TrackBar.Value = Trackbar();
                            break;
                        }
                }

            }
            //enable ui on disconnect
            UI_Connect_TM1_Button.Enabled = true;
            UI_Connect_TM2_Button.Enabled = true;
        }
        /// <summary>
        /// Gets the trackbar value
        /// </summary>
        /// <returns></returns>
        private int Trackbar()
        {
            return (int)(UI_TrackBar.Maximum - ((UI_TrackBar.Maximum - UI_TrackBar.Minimum) / 2));
        }
        /// <summary>
        /// Opens the server form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_Server_BTN_Click(object sender, EventArgs e)
        {
            if (server == null || server.IsDisposed)
            {
                server = new Form1();
                server.Show();
            }
        }
        /// <summary>
        /// Logs messages to the listbox
        /// </summary>
        /// <param name="s"></param>
        private void Log(string s)
        {
            // Uses invoke if in different thread, otherwise updates normally
            if (InvokeRequired)
            {
                Invoke((Action)(() => { Log(s); }));
                return;
            }
            UI_ListBox.Items.Add(s);
            UI_ListBox.SelectedIndex = UI_ListBox.Items.Count - 1;
            UI_ListBox.SelectedIndex = -1;
        }
    }
}
