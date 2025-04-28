/*
    UDP TAPChat
    By Adrian Baira, Damien
    March, 04, 2025
    Messenger
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_TAPChar
{
    public partial class Form1 : Form
    {
        #region Members
        // UDP client for sending messages
        UdpClient clientSocket = new UdpClient();
        // UDP client for listening on port 1666
        UdpClient listeningSocket = new UdpClient(1666);
        // Dictionary to store known hosts and their nicknames
        Dictionary<string, string> knownHosts = new Dictionary<string, string>();
        // Local IP address
        string localIP = null;
        #endregion

        #region CTOR
        /// <summary>
        /// Initializes the form, sets up UI components, retrieves local IP, and starts listening for messages.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            // Setting up UI table columns
            UI_Datagridview.Columns.Add("Time", "Timestamp");
            UI_Datagridview.Columns.Add("Name", "Nickname");
            UI_Datagridview.Columns.Add("Message", "Message");

            // Retrieve the local machine's IP address
            string hostname = Dns.GetHostName();
            IPAddress[] iPAddresses = Dns.GetHostAddresses(hostname);
            foreach (IPAddress ip in iPAddresses)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }

            // Start listening for incoming messages asynchronously
            Task.Run(async () =>
            {
                while (true)
                {
                    await ReceiveMessageAsync();
                }
            });
        }
        #endregion

        #region Sending
        /// <summary>
        /// Handles the send button click event. Sends a UDP message to the specified target.
        /// </summary>
        /// <param name="sender">Event source</param>
        /// <param name="e">Event arguments</param>
        async private void UI_BTN_Send_Click(object sender, EventArgs e)
        {
            // Get user input from text fields
            string userinput = UI_TXT_CharText.Text;
            string sendingToIP = UI_TXT_TargetAddress.Text;
            string name = UI_TXT_Nickname.Text;

            // If there is no message, exit function
            if (string.IsNullOrEmpty(userinput))
            {
                AddToLog("Chat Text can't be empty.");
                return;
            }

            // If no IP is provided, default to local IP
            if (string.IsNullOrEmpty(sendingToIP))
                sendingToIP = localIP;

            //Checking if it is a valid ip adress that is being put into the text box
            if (!IsValidIpAddress(sendingToIP))
            {
                AddToLog("Invalid IP address. Please enter a valid IPv4 address.");
                return;
            }

            //add to dictionary and keep the name and ipadress of the person
            if (!knownHosts.ContainsKey(sendingToIP))
            {
                // Add unknown host to list
                knownHosts[sendingToIP] = "Unknown";
                UpdateKnownHostsUI();
            }

            // Create a message object and serialize it into JSON
            object sending = new Send { Nickname = name, Message = userinput };
            string jsonMessage = JsonSerializer.Serialize(sending);
            byte[] message = Encoding.ASCII.GetBytes(jsonMessage);

            // Send message to self
            await SendMessageAsync(localIP, message);

        

            // Send to selected known hosts or all known hosts
            if (UI_ListBox_KnownHosts.SelectedItems.Count > 0)
            {
                //only send to selected ip addresses from the known listbox
                foreach (string selectedIp in UI_ListBox_KnownHosts.SelectedItems)
                {
                    string targetIp = selectedIp.Split(' ')[0];
                    if (targetIp != localIP) // Prevent sending to self
                        await SendMessageAsync(targetIp, message);
                }
            }
            // if the target address is selected then sent to adress
            else if (UI_TXT_TargetAddress.Text.Count() > 0 )
            {
                await SendMessageAsync(sendingToIP, message);
            }
            else
            {
                //if nothing is selected then do for all known adresses
                foreach (var knownIP in knownHosts)
                {
                    if (knownIP.Key != localIP) // Prevent sending to self
                        await SendMessageAsync(knownIP.Key, message);

                }
            }
        }

        /// <summary>
        /// Sends a UDP message to a target IP asynchronously.
        /// </summary>
        /// <param name="targetIp">The target IP address</param>
        /// <param name="message">The message in byte array format</param>
        async Task SendMessageAsync(string targetIp, byte[] message)
        {
            try
            {
                //getting returned bytes from other client
                int returnedBytes = await clientSocket.SendAsync(message, message.Length, targetIp, 1666);
                AddToLog($"Sent {returnedBytes} bytes to {targetIp}");
            }
            catch (Exception ex)
            {
                AddToLog($"Error sending to {targetIp}: {ex.Message}");
            }
        }
        #endregion

        #region Recevicing Messages
        /// <summary>
        /// Receives incoming UDP messages asynchronously and updates UI.
        /// </summary>
        async Task ReceiveMessageAsync()
        {
            //Try error checking for listening socket
            try
            {
                //Waiting for responce
                UdpReceiveResult receiveResult = await listeningSocket.ReceiveAsync();
                
                //Ip adress from sender
                string receiveIP = receiveResult.RemoteEndPoint.Address.ToString();

                //getting current time received message
                DateTime timestamp = DateTime.Now;
                
                Send message = null;
                try
                {
                    //Validate if the expected json objects are in the sent json object
                    //root element is the entire json object
                    //trygetproperty get the property specified and match it to wanted name property
                    var json = JsonDocument.Parse(Encoding.UTF8.GetString(receiveResult.Buffer));
                    if (!json.RootElement.TryGetProperty("Nickname", out JsonElement nicknameElement) || !json.RootElement.TryGetProperty("Message", out JsonElement messageElement))
                    {
                        AddToLog($"Invalid JSON fields from {receiveIP} missing 'Nickname' or 'Message'");
                        return;
                    }

                    //Deserialize the json object into a string
                    message = JsonSerializer.Deserialize<Send>(Encoding.UTF8.GetString(receiveResult.Buffer));
                    if (message.Message.Length <= 0)
                    {
                        AddToLog($"No message sent from {receiveIP}");
                        return;
                    }
                }
                catch (Exception except)
                {
                    AddToLog($"Something went wrong with JSON Object from {receiveIP} : {except.Message}");
                    return;
                }

                //Display message with timestamp and source IP/nickname
                string chatLog = $"[{timestamp.ToString("hh:mm:ss tt")}] {message.Nickname}: {message.Message} sent from {receiveIP}";
                Console.WriteLine(chatLog);

     

                // Add sender to known hosts if not already present
                if (!knownHosts.ContainsKey(receiveIP) || knownHosts[receiveIP] != message.Nickname)
                {
                    knownHosts[receiveIP] = message.Nickname;
                    this.Invoke((Action)UpdateKnownHostsUI);
                }

                // Update the chat display with the received message
                this.Invoke((Action)(() =>
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(UI_Datagridview);
                    row.Cells[0].Value = timestamp.ToString("hh:mm:ss tt");
                    row.Cells[1].Value = $"{receiveIP} <{message.Nickname}>";
                    row.Cells[2].Value = message.Message;
                    UI_Datagridview.Rows.Add(row);
                    UI_Datagridview.FirstDisplayedScrollingRowIndex = UI_Datagridview.Rows.Count - 1;
                }));
            }
            catch (Exception ex)
            {
                AddToLog($"Error receiving message: {ex.Message}");
            }
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Updates the UI list of known hosts.
        /// </summary>
        void UpdateKnownHostsUI()
        {
            UI_ListBox_KnownHosts.Items.Clear();
            foreach (var knownIP in knownHosts)
            {
                if(knownIP.Key != localIP)
                    UI_ListBox_KnownHosts.Items.Add($"{knownIP.Key} / <{knownIP.Value}>");
            }
        }
        /// <summary>
        /// Add to list box for logging what user did
        /// </summary>
        /// <param name="s">string</param>
        private void AddToLog(string s)
        {
            this.Invoke((Action)(() => { UI_ListBox.Items.Add(s); }));
        }
        /// <summary>
        /// Validates if the given string is a valid IPv4 address.
        /// </summary>
        /// <param name="input">IP address string to validate</param>
        /// <returns>True if valid, otherwise false</returns>
        private bool IsValidIpAddress(string input)
        {
            return IPAddress.TryParse(input, out IPAddress ip) && ip.AddressFamily == AddressFamily.InterNetwork && ip.ToString() == input;
        }
        /// <summary>
        /// Clear button for log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_BTN_Clear_Click(object sender, EventArgs e)
        {
            UI_ListBox.Items.Clear();
        }
        #endregion



    }
}
