using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTemplate.Controls
{
    /// <summary>
    /// Interaction logic for ServoControl.xaml
    /// </summary>
    public partial class ServoControl : UserControl
    {
        public ServoControl()
        {
            InitializeComponent();
        }

        private void AngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ScrollBar bar = sender as ScrollBar;
            if (DutyXAML != null)
            {
                DutyXAML.Text = bar.Value.ToString("0");
            }
            
        }

        private void AngleSet(object sender, MouseEventArgs e)
        {
            ScrollBar bar = sender as ScrollBar;
            try
            {
                byte[] servoDuty = new byte[2];
                servoDuty[0] = (byte)SerialData.Header.Servo;
                servoDuty[1] = (byte)(bar.Value);

                if (ComPortData.Port != null)
                {
                    ComPortData.Port.Write(servoDuty, 0, servoDuty.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
