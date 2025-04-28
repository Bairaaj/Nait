using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace WpfTemplate
{
    /// <summary>
    /// Interaction logic for TimeControl.xaml
    /// </summary>
    public partial class TimeControl : UserControl
    {
        /// <summary>
        /// FIELDS
        /// </summary>
        DateTime dateTime;
        DateTime customDateTime;
        DateTime epochUnix;
        Timer ticker;
        TimeData timeData;
        


        public TimeControl()
        {
            InitializeComponent();
            dateTime = new DateTime();
            epochUnix = new DateTime(1970, 1, 1, 0, 0, 0);
            timeData = new TimeData();
            BytesGridXAML.Items.Add(timeData);
            ticker = new Timer(1000);
            ticker.Elapsed += TimerSecTick;
            ticker.AutoReset = true;
            ticker.Start();
            UnixTimeXAML.DataContext = timeData;
            
        }

        private void TimerSecTick(object sender, ElapsedEventArgs e)
        {
            dateTime = DateTime.Now;


            this.Dispatcher.Invoke(() =>
            {
                timeData.DateTime = dateTime;
                timeData.UnixTime = TimeData.ToUnixTime(dateTime.ToUniversalTime());
                //UnixTimeXAML.Text = timeData.UnixTime.ToString();
                DateXAML.Text = dateTime.ToString("dddd, dd MMMM yyyy");
                TimeXAML.Text = dateTime.ToString("hh:mm:ss tt");               
            });
            
        }

        private void SyncTime(object sender, RoutedEventArgs e)
        {
            switch (TimeSelectXAML.SelectedIndex)
            {
                case 0:
                    timeData.SendTime(ComPortData.Port, SerialData.Header.UnixTime, DateTime.Now);
                    break;

                case 1:
                    timeData.SendTime(ComPortData.Port, SerialData.Header.LocalTime, DateTime.Now);
                    break;

                default:
                    break;
            }


            
        }

        private void CustomDateSelected(object sender, SelectionChangedEventArgs e)
        {
            DatePicker datepicked = sender as DatePicker;
            customDateTime = (DateTime)datepicked.SelectedDate;

            if(TimePickedXAML.Visibility == Visibility.Visible)
            {//Time was already selected
                customDateTime = customDateTime.AddHours(TimePickedXAML.Value.Value.Hour);
                customDateTime = customDateTime.AddMinutes(TimePickedXAML.Value.Value.Minute);
                customDateTime = customDateTime.AddSeconds(0);
                PickedTimeXAML.Text = customDateTime.ToString();
                PickedTimeXAML.Visibility = Visibility.Visible;
            }
            else
            {//Time has to be pciked the first time
                TimePickedXAML.Visibility = Visibility.Visible;
            }
        }

        private void CustomTimeSelected(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TimePicker pickedTime = sender as TimePicker;
            CustomTimeSyncButtonXAML.Visibility=Visibility.Visible;
            customDateTime = (DateTime)DatePickedXAML.SelectedDate;
            customDateTime = customDateTime.AddHours(pickedTime.Value.Value.Hour);
            customDateTime = customDateTime.AddMinutes(pickedTime.Value.Value.Minute);
            customDateTime = customDateTime.AddSeconds(0);
            PickedTimeXAML.Text = customDateTime.ToString();
            PickedTimeXAML.Visibility = Visibility.Visible;
        }

        private void SyncCustomTime(object sender, RoutedEventArgs e)
        {
            timeData.SendTime(ComPortData.Port, SerialData.Header.LocalTime, customDateTime);
        }
    }
}
