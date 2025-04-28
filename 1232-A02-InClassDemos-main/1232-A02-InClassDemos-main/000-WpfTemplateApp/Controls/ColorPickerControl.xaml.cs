using System;
using System.Collections.Generic;
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

namespace WpfTemplate
{
    /// <summary>
    /// Interaction logic for ColorPickerControl.xaml
    /// </summary>
    public partial class ColorPickerControl : UserControl
    {
        public delegate void ColorPicked(Color sender);
        public event ColorPicked onColorPickedChanged;

        public ColorPickerControl()
        {
            InitializeComponent();
            onColorPickedChanged += ColorChanged;
        }

        private void ColorChanged(Color sender)
        {
            try
            {
                byte[] rgb = new byte[4];
                rgb[0] = (byte)SerialData.Header.RGB;
                rgb[1] = sender.R;
                rgb[2] = sender.G;
                rgb[3] = sender.B;
                if(ComPortData.Port != null)

                {
                    ComPortData.Port.Write(rgb, 0, rgb.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PickColor(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color newColor = Color.FromRgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                ColorXAML.Fill = new SolidColorBrush(newColor);
                onColorPickedChanged.Invoke(newColor);
            }
        }
    }
}
