/*
   HiLow - Server Dialog
   By Adrian Baira, Adam Mwanza
   March, 24, 2025
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server
{
    public partial class Form1 : Form
    {
        Socket _listener = null;                //Listener Client
        Socket _client = null;                  //Client connected to
        static Random _random = new Random();   //Random number to guess
        int _guessNumber = 0;                   //Number to guess

        /// <summary>
        /// Load server and start listening for new clients
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        /// <summary>
        /// Connecting to 
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
        {
            //always runnning loop for server
            while (true)
            {
                // IF the listener is connected return
                if (_listener != null)
                    return;

                //Listener for the client
                _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //Try to bind the listener to the port
                try
                {
                    //Bind the listener to the port
                    _listener.Bind(new IPEndPoint(IPAddress.Any, 1666));
                    //Start listening for clients trying to connect
                    _listener.Listen(0);
                    Log("Listening... about to accept");
                }
                catch (SocketException ex) //If there is an error in the socket then restart the listener to null and return
                {
                    Trace.Write(ex);
                    _listener = null;
                    return;
                }

                //once listener is listening for incoming clients initalize a client socket
                Socket client = null;
                try
                {
                    //wait until _listener accepts a client
                    client = await _listener.AcceptAsync();
                }
                catch (SocketException ex) //If there is an error in the socket then restart the listener to null and return
                {
                    Trace.Write(ex);
                    _listener = null;
                    return;
                }
                //Once client has gotten a connection, set the client to the new client
                _client = client;

                //Close the listener and set it to null to prevent multiple clients from connecting
                _listener.Close();
                _listener = null;
                Log("Accepted!");

                //Generate a random number for the client to guess
                _guessNumber = _random.Next(1, 1001);
                UI_LBL_Number.Text = $"{_guessNumber}";

                // Buffer to store the response bytes.
                byte[] buffer = new byte[1024];
                while (_client != null && _client.Connected)
                {
                    int bytes = 0;
                    try
                    {
                        //receive the bytes from the client
                        bytes = await _client.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                    }
                    catch (SocketException ex)
                    {
                        Trace.Write(ex);
                        _client = null;
                        return;
                    }

                    if (bytes == 0)
                    {
                        _client = null;
                        break;
                    }

                    var data = JsonSerializer.Deserialize<Send>(Encoding.UTF8.GetString(buffer, 0, bytes));
                    Log($"{bytes} bytes received Guess: {data.guess}");

                    // Check the guess and return the result
                    int result = CheckGuess(data.guess);

                    // make a response object into a string
                    string sendbackString = JsonSerializer.Serialize(new Send { response = result, guess = data.guess });

                    //Make the string into bytes
                    byte[] sendbytes = Encoding.UTF8.GetBytes(sendbackString);

                    //Send the bytes back to the client
                    ArraySegment<byte> bytes1 = new ArraySegment<byte>(sendbytes);
                    Log($"Sent Back Response {result}");
                    await _client.SendAsync(bytes1, SocketFlags.None);


                    // If the result is 0 then the guess is correct
                    if (result == 0)
                    {
                        Log("Correct Guess!");
                        //If the host wants to disconnect when the person won then disconnect
                        if (UI_CHK_Disconnect.Checked)
                        {
                            UI_LBL_Number.Text = "0";
                            break;
                        }
                        else
                        {
                            //Continue the game by generating a new number
                            _guessNumber = _random.Next(1, 1001);
                            UI_LBL_Number.Text = $"{_guessNumber}";
                        }
                    }
                    
                    
                }

                //disconnects then close the client
                try
                {
                    _client?.Shutdown(SocketShutdown.Both);
                }
                catch { }
                finally
                {
                    //close client and set it to null
                    _client?.Close();
                    _client = null;
                    Log("Client disconnected - soft close");
                }

            }

        }
        /// <summary>
        /// Check the guess from the client 
        /// and return the result
        /// </summary>
        /// <param name="guess">Guess number</param>
        /// <returns>Response code</returns>
        private int CheckGuess(int guess)
        {
            if (guess == _guessNumber)
                return 0;
            else if (guess < _guessNumber)
                return -1;
            else
                return 1;
        }
        /// <summary>
        /// Showing what is happening in the server into a listbox
        /// </summary>
        /// <param name="s">Input string</param>
        private void Log(string s)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => { Log(s); }));
                return;
            }
            UI_ListBox.Items.Add(s);
            UI_ListBox.SelectedIndex = UI_ListBox.Items.Count - 1;
            UI_ListBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Closing the server and the listener for hard disconnect
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_client == null)
                return;

            _client?.Close();
            _listener?.Close();
            _client = null;
            _listener = null;
            this.Close();
        }
    }
}
