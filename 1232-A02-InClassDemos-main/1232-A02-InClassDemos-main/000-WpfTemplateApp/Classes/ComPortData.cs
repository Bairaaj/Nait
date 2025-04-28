using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTemplate
{
    internal class ComPortData
    {
        static SerialPort _port;

        public string Name { get; set; }
        public string Description { get; set; }
        public string DeviceID { get; set; }
        public string PortName { get; set; }


        public static SerialPort Port 
        { 
            get
            {
                try
                {
                    if(_port == null)
                    {
                        throw new Exception("Port not connected");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        public static int[] BaudRates =
        {
            9600,
            19200,
            115200,
            256000,
            500000,
        };
    }
}
