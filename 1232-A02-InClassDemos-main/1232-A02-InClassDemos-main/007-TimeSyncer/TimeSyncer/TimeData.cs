using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace TimeSyncer
{
    internal class TimeData
    {
        struct DateTimeStruct
        {
            public UInt16 Year;
            public UInt16 Month;
            public UInt16 MonthDay;
            public UInt16 Day;
            public byte Hours;
            public byte Minutes;
            public byte Seconds;
            public byte HuSeconds; //hundreths of seconds (10ms ticks)
        };


        private byte[] PackTime(DateTime time)
        {
            DateTimeStruct dateTimeStruct = new DateTimeStruct();
            byte[] timePacket;

            dateTimeStruct = new DateTimeStruct();
            dateTimeStruct.Year = (UInt16)time.Year;
            dateTimeStruct.Month = (UInt16)time.Month;
            dateTimeStruct.MonthDay = (byte)time.Day;
            dateTimeStruct.Day = (UInt16)(time.DayOfWeek + 1);
            dateTimeStruct.Hours = (byte)time.Hour;
            dateTimeStruct.Minutes = (byte)time.Minute;
            dateTimeStruct.Seconds = (byte)time.Second;
            dateTimeStruct.HuSeconds = (byte)(time.Millisecond / 10);
            timePacket = SerialData.Serialize<DateTimeStruct>(dateTimeStruct);
            /*This is to make it compatible with Little Endian for the 16-bit variables*/
            Array.Reverse(timePacket, 0, 2);
            Array.Reverse(timePacket, 2, 2);
            Array.Reverse(timePacket, 4, 2);
            Array.Reverse(timePacket, 6, 2);

            return timePacket;
        }

        public void SendTime(SerialPort port, DateTime time)
        {
            try
            {
                byte[] data = PackTime(time);
                port.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
        }
    }
}
