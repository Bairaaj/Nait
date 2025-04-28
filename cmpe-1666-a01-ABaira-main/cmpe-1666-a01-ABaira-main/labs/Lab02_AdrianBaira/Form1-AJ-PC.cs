using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_AdrianBaira
{
    public partial class Form1 : Form
    {
        private Bitmap originalbm;
        private Bitmap modifiedbm;
        public Form1()
        {
            InitializeComponent();
 
            UI_BTN_Transform.Enabled = false;
           
        }
        

        private void UI_BTN_LoadPicture_Click(object sender, EventArgs e)
        {
            UI_OpenFileDialog.RestoreDirectory = true;
            UI_OpenFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            UI_OpenFileDialog.FilterIndex = 1;
            if (UI_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    UI_PictureBox.Image = new Bitmap(UI_OpenFileDialog.FileName);
                    originalbm = new Bitmap(UI_PictureBox.Image);
                    modifiedbm = new Bitmap(originalbm);
                    UI_BTN_Transform.Enabled = true;
                    if ((UI_PictureBox.Image = new Bitmap(UI_OpenFileDialog.FileName)) == null)
                    {
                        UI_BTN_Transform.Enabled = false;
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Picture, please try again");
                }
            }
            
            
        }

        private void UI_BTN_Transform_Click(object sender, EventArgs e)
        {
            
            if (UI_RADIO_Contrast.Checked)
            {
                UI_LABEL_Left.Text = "Less";
                UI_LABEL_Middle.Text = $"{UI_Trackbar.Value}";
                UI_LABEL_Right.Text = "More";
                Contrast(originalbm, UI_Trackbar.Value);
            }
            if (UI_RADIO_BlackWhite.Checked)
            {
                UI_LABEL_Left.Text = "Less";
                UI_LABEL_Middle.Text = $"{UI_Trackbar.Value}";
                UI_LABEL_Right.Text = "More";
                BlackAndWhite(originalbm, UI_Trackbar.Value);
            }
            if (UI_RADIO_Tint.Checked)
            {
                UI_LABEL_Left.Text = "Red";
                UI_LABEL_Middle.Text = $"{UI_Trackbar.Value}";
                UI_LABEL_Right.Text = "Green";
                Tint(originalbm, UI_Trackbar.Value);
            }
            if (UI_RADIO_Noise.Checked)
            {

            }
            
        }
        private void UI_BTN_Revert_Click(object sender, EventArgs e)
        { 
            UI_PictureBox.Image = originalbm;
        }
        private void UI_Trackbar_Scroll(object sender, EventArgs e)
        {
            UI_LABEL_Middle.Text = UI_Trackbar.Value.ToString();
        }

        private void BlackAndWhite(Bitmap bm, int trackbarvalue)
        {
            for (int i = 0; i <= 20; i += 2)
            {
               UI_LoadBar.Value = i;
                for (int x = 0; x < bm.Width; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        Color currentimg = bm.GetPixel(x, y);
             
                        int average = ((currentimg.R + currentimg.G + currentimg.B) / 3);

                        int red = currentimg.R  + ((average - currentimg.R) * trackbarvalue / 100);
                        int green = currentimg.G + ((average - currentimg.G) * trackbarvalue / 100 );
                        int blue = currentimg.B + ((average - currentimg.B) * trackbarvalue / 100);

                        MinMax(ref red, ref green, ref blue);

                    modifiedbm.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }
            }
            UI_LoadBar.Value = 0;

            UI_PictureBox.Image = modifiedbm;
        }

        private void Contrast(Bitmap bm, int trackbarvalue)
        {
            for (int i = 0; i <= 20; i += 2)
            {
                UI_LoadBar.Value = i;
                for (int x = 0; x < bm.Width; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        Color currentimg = bm.GetPixel(x, y);
                        int red = currentimg.R;
                        int green = currentimg.G;
                        int blue = currentimg.B;
                        if (red > 128)
                        {
                            red += (trackbarvalue / 5);
                        }                       
                        red -= (trackbarvalue / 5);                       
                        if (green > 128)
                        {
                            green += (trackbarvalue / 5);
                        }                     
                        green -= (trackbarvalue / 5);                    
                        if (blue > 128)
                        {
                            blue += (trackbarvalue / 5);
                        }                  
                        blue -= (trackbarvalue / 5);                  
                        MinMax(ref red, ref green, ref blue);
                        modifiedbm.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }   
            }
            UI_LoadBar.Value = 0;
            UI_PictureBox.Image = modifiedbm;
        }
        private void Tint(Bitmap bm, int trackbarvalue)
        {
            for (int i = 0; i <= 20; i += 2)
            {
                UI_LoadBar.Value = i;
                for (int x = 0; x < bm.Width; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        Color currentimg = bm.GetPixel(x, y);
                        int red = currentimg.R;
                        int green = currentimg.G;
                        int blue = currentimg.B;
                        if (trackbarvalue < 50)
                        {
                            red = red + (50 - trackbarvalue);
                        }
                        if (trackbarvalue > 50)
                        {
                            green = green + (trackbarvalue - 50);
                        }
                        

                        MinMax(ref red, ref green, ref blue);

                        modifiedbm.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }
            }
            UI_LoadBar.Value = 0;

            UI_PictureBox.Image = modifiedbm;
        }

        private void MinMax(ref int red, ref int green, ref int blue)
        {
            red = (red < 255) ? red : 255;
            red = (red > 0) ? red : 0;

            green = (green < 255) ? green : 255;
            green = (green > 0) ? green : 0;

            blue = (blue < 255) ? blue : 255;
            blue = (blue > 0) ? blue : 0;

        }
    }
}
