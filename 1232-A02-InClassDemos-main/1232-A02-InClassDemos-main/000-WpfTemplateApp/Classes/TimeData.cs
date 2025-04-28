using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTemplate
{
    internal class TimeData : INotifyPropertyChanged
    {
        uint _epochUnixTime;
        byte[] _epochUnixTimeBytes;

        byte[] _timePacket;
        DateTime _dateTime;
        static DateTime _unixTimeStart = new DateTime(1970, 1, 1, 0, 0, 0);

        public event PropertyChangedEventHandler PropertyChanged;

        DateTimeStruct dateTimeStruct;

        

        struct DateTimeStruct
        {
            public UInt16 Year;
            public UInt16 Month;
            public UInt16 MonthDay;
            public UInt16 Day;
            public byte Hours;
            public byte Minutes;
            public byte Seconds;
            public byte HuSeconds; //hundreths of seconds (ms/10)
        };


        /// <summary>
        /// AUTO IMPLEMENTED PROPERTIES
        /// </summary>
        public DateTime DateTime 
        {            
            get { return _dateTime; }
            set
            {
                try
                {
                    _dateTime = value;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        public uint UnixTime
        {
            get { return _epochUnixTime; }
            set 
            {
                _epochUnixTime = value;
                UnixBytes = SerialData.Serialize(_epochUnixTime);
                this.OnPropertyChanged("UnixTime");
            }
        }

        public byte[] UnixBytes
        {
            get
            {
                return _epochUnixTimeBytes;
            }
            set
            {
                _epochUnixTimeBytes = value;
                this.OnPropertyChanged("UnixBytes");
            }
        }



        public TimeData()
        {
            dateTimeStruct = new DateTimeStruct();
        }

        protected void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public static uint ToUnixTime(DateTime time)
        {
            TimeSpan tSpan = time - _unixTimeStart;

            return (uint)tSpan.TotalSeconds;
        }

        public void SendTime(SerialPort port, SerialData.Header header, DateTime dateTime)
        {
            PackTime(dateTime);
            if (port != null)
            {
                byte[] data;
                switch (header)
                { 
                    case SerialData.Header.UnixTime:
                        data = new byte[5];
                        data[0] = (byte)SerialData.Header.UnixTime;
                        Array.Copy(UnixBytes.Reverse().ToArray(), 0, data, 1, 4);
                        port.Write(data, 0, data.Length);
                        break;
                    case SerialData.Header.LocalTime:
                        data = new byte[13];
                        data[0] = (byte)SerialData.Header.LocalTime;
                        Array.Copy(_timePacket, 0, data, 1, _timePacket.Length);
                        port.Write(data, 0, data.Length);
                        break;
                    default:
                        break;
                }        
            }
        }

        private void PackTime(DateTime time)
        {
            dateTimeStruct = new DateTimeStruct();
            dateTimeStruct.Year = (UInt16)time.Year;
            dateTimeStruct.Month = (UInt16)time.Month;
            dateTimeStruct.MonthDay = (byte)time.Day;
            dateTimeStruct.Day = (UInt16)(time.DayOfWeek + 1);
            dateTimeStruct.Hours = (byte)time.Hour;
            dateTimeStruct.Minutes = (byte)time.Minute;
            dateTimeStruct.Seconds = (byte)time.Second;
            dateTimeStruct.HuSeconds = (byte)(time.Millisecond / 10);
            _timePacket = SerialData.Serialize<DateTimeStruct>(dateTimeStruct);
            /*This is to make it compatible with Little Endian for the 16-bit variables*/
            Array.Reverse(_timePacket, 0, 2);
            Array.Reverse(_timePacket, 2, 2);
            Array.Reverse(_timePacket, 4, 2);
            Array.Reverse(_timePacket, 6, 2);
        }
    }
}
