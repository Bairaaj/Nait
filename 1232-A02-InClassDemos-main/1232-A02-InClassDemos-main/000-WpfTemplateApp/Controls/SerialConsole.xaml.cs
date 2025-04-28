using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Timer = System.Timers.Timer;

namespace WpfTemplate
{
    /// <summary>
    /// Interaction logic for SerialConsole.xaml
    /// </summary>
    public partial class SerialConsole : UserControl
    {
        /// <summary>
        /// CONSTANTS
        /// </summary>
        const int exCodeComPort = -532462766;


        /// <summary>
        /// FIELDS
        /// </summary>
        List<ComPortData> comPorts;     //List of comports to show
        SerialPort currentPort;         //Actual Serial Port
        ListView serialMsgList;        //messages to be displayed in the console

        List<byte> bytesReceived = new List<byte>();

        Timer rxTimeout = new Timer();
        bool dataReceiving = false;

        Task serialMonitor = new Task(MonitorSerial);

        private static void MonitorSerial()
        {
            while(true)
            {

            }
        }

        public SerialConsole()
        {
            InitializeComponent();
            RefreshPorts();
            serialMsgList = new ListView();
            COMMsgXAML.Content = serialMsgList;
        }

        private void ComportList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex > 0)
            {
                StatusLabelXAML.Content = "Port: " + comPorts[comboBox.SelectedIndex - 1].Name;
                BaudConnect.Visibility = Visibility.Visible;
                BaudRateListXAML.Items.Clear();
                foreach (int br in ComPortData.BaudRates)
                {
                    BaudRateListXAML.Items.Add(br);
                }
                BaudRateListXAML.SelectedIndex = 2;
            }
            else
            {
                StatusLabelXAML.Content = "Port: None";
                BaudConnect.Visibility = Visibility.Collapsed;
            }
        }

        void RefreshPorts()
        {
            ComportListXAML.Items.Clear();
            ComportListXAML.Items.Add("Select Port...");
            ComportListXAML.SelectedIndex = 0;

            comPorts = new List<ComPortData>();

            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection tempPorts = processClass.GetInstances();

            foreach (ManagementObject item in tempPorts)
            {
                if (item.GetPropertyValue("Name") != null)
                {
                    if (item.GetPropertyValue("Name").ToString().Contains("(COM"))
                    {
                        ComPortData portData = new ComPortData();
                        portData.Name = item.GetPropertyValue("Name").ToString();
                        portData.Description = item.GetPropertyValue("Description").ToString();
                        string[] values = portData.Name.Split(new char[] { '(', ')' });
                        portData.PortName = values[1];
                        portData.DeviceID = item.GetPropertyValue("DeviceID").ToString();
                        comPorts.Add(portData);

                        ComboBoxItem comboBoxItem = new ComboBoxItem();
                        comboBoxItem.Content = portData.PortName;
                        comboBoxItem.ToolTip = portData.Description;
                        ComportListXAML.Items.Add(comboBoxItem);
                    }
                }
            }
        }

        private void RefreshPortsButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshPorts();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            Button connectButton = sender as Button;
            Panel connectPanel = connectButton.Parent as Panel;
            ComboBox brBox = connectPanel.Children.OfType<ComboBox>().FirstOrDefault();
            try
            {
                if (ConnectButton.Content.ToString().Equals("Connect"))
                {
                    currentPort = new SerialPort(ComportListXAML.SelectionBoxItem.ToString(), int.Parse(brBox.SelectionBoxItem.ToString()));
                    currentPort.Open();
                    currentPort.BaseStream.ReadTimeout = 100;
                    ComPortData.Port = currentPort;
                    while (!currentPort.IsOpen) ;
                    currentPort.DataReceived += SerialDataReceived;
                    currentPort.Disposed += PortDisposed;
                    StatusLabelXAML.Content = "Port Connected at " + brBox.SelectionBoxItem.ToString();
                    StatusLabelXAML.Foreground = Brushes.Green;
                    ConnectionStatus.Content = "Status: Connected";
                    ConnectionCircle.Fill = Brushes.Green;
                    ConnectButton.Content = "Disconnect";
                }
                else if (ConnectButton.Content.ToString().Equals("Disconnect"))
                {
                    currentPort.BaseStream.Flush();
                    serialMsgList.Items.Clear();
                    currentPort.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PortDisposed(object sender, EventArgs e)
        {
            
            //MessageBox.Show("COM Port has been released");
            ConnectButton.Content = "Connect";
            StatusLabelXAML.Content = "Port Disconnected";
            StatusLabelXAML.Foreground = Brushes.DarkRed;
            ConnectionStatus.Content = "Status: Disconnected";
            ConnectionCircle.Fill = Brushes.DarkRed;
            currentPort.DataReceived -= SerialDataReceived;
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if(currentPort != null && currentPort.IsOpen)
            {
                try
                {
                    dataReceiving = true;


                    byte[] receivedBytes= new byte[currentPort.BytesToRead];
                    currentPort.Read(receivedBytes, 0, receivedBytes.Length);
                    SerialData.Header header = new SerialData.Header();
                    header = (SerialData.Header)receivedBytes[0];
                    string message = "";

                    switch (header)
                    {
                        case SerialData.Header.TextMsg:
                            message = Encoding.UTF8.GetString(receivedBytes, 1, receivedBytes.Length-1);
                            break;

                        case SerialData.Header.Counter:

                            break;

                        default:
                            break;
                    }
                    
                    this.Dispatcher.Invoke(() =>
                    {
                        //ParamGridXALM.Items.Refresh();
                        if (DataViewXAML.IsChecked.Value)
                        {
                            serialMsgList.Items.Add(message);
                            COMMsgXAML.ScrollToEnd();
                        }
                    });
                }
                catch (Exception ex)
                {
                    string exName = ex.GetType().Name;
                    if(!exName.Equals("IOException"))
                    {
                        MessageBox.Show(ex.Message);
                    }


                }
            }
        }

        private void ClearView_Click(object sender, RoutedEventArgs e)
        {
            serialMsgList.Items.Clear();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(currentPort == null)
                {
                    throw new Exception("Port not connected!");
                }
                else
                {
                    currentPort.Write(TransmitTextXAML.Text);
                    string log = "Sent: " + TransmitTextXAML.Text;
                    serialMsgList.Items.Add(log);
                    COMMsgXAML.ScrollToEnd();
                    if (AutoClear.IsChecked == true)
                    {
                        TransmitTextXAML.Text = "";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: ");
            }
        }
    }
}
