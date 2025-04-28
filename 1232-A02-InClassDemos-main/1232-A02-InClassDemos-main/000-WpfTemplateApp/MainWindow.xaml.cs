using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
using WpfTemplate.Controls;

namespace WpfTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// FIEDLS
        /// </summary>

        Panel[] panels;
        Button[] buttonPannels;
        Panel currentPanel = null;
        Button currentButton = null;

        SolidColorBrush defaultButtonColor, clickedButtonColor;

        //Support Objects(userControl, Pages, etc)
        SerialConsole console;
        TimeControl dateTime;
        ColorPickerControl colorPicker;
        ServoControl servoControl;

        public MainWindow()
        {
            InitializeComponent();
            console = new SerialConsole();
            dateTime = new TimeControl();
            colorPicker = new ColorPickerControl();
            servoControl = new ServoControl();
            panels = MainBodyXAML.Children.OfType<Panel>().ToArray();
            buttonPannels = HeaderButtonsXAML.Children.OfType<Button>().ToArray();
            foreach (var item in panels)
            {
                item.Visibility = Visibility.Collapsed;
            }
            defaultButtonColor = (SolidColorBrush)MainWindow.GetWindow(this).Resources["ButtonBackDefault"];
            clickedButtonColor = (SolidColorBrush)MainWindow.GetWindow(this).Resources["ButtonBackClicked"];
            
            panels[0].Children.Add(console);
            panels[1].Children.Add(colorPicker);
            panels[2].Children.Add(dateTime);
            panels[3].Children.Add(servoControl);
        }

        private void Button_PanelSelect(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.Background = clickedButtonColor;
            int index = Array.FindIndex(buttonPannels, x => x.Equals(button));
            if(currentPanel != null)
            {
                currentPanel.Visibility = Visibility.Collapsed;
                currentButton.Background = defaultButtonColor;
            }
            currentButton = button;
            currentPanel = panels[index];
            currentPanel.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// Help and Bugs Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendEmail(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NewConnection(object sender, RoutedEventArgs e)
        {
            //To be coded later
        }

        private void Disconnect(object sender, RoutedEventArgs e)
        {
            //To be coded later
        }

        private void MSTeamsMessage(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
    }
}
