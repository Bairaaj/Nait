using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA08_AdrianBaira
{
    public partial class Form1 : Form
    {
        Color[,] color = new Color[80, 60];
        CDrawer canvas = new CDrawer(800, 600);
        int numberofblocks = 100;

        public Form1()
        {
            InitializeComponent();
            canvas.Scale = 10;
        }
        private void UI_Button_FillColor_Click(object sender, EventArgs e)
        {
            if (UI_ColorDialog.ShowDialog() == DialogResult.OK)
            {
                UI_TextBox_FillColor.BackColor = UI_ColorDialog.Color;
                Color colorfill = UI_ColorDialog.Color;

            }
        }
        private void FillCanvas()
        {
            Random random = new Random();
            for (int i = 0; i < color.GetLength(0); i++)
            {
                for (int j = 0; j < color.GetLength(1); j++)
                {
                    color[i, j] = Color.Black;
                    if (i == 0 || i == 79 || j == 0 || j == 59)
                    {
                        color[i, j] = Color.Red;
                    }
                }
            }
            for (int i = 0; i < color.GetLength(0); i++)
            {
                for (int j = 0; j < color.GetLength(1); j++)
                {

                }
            }
            for (int i = 0; i < numberofblocks; i++)
            {
                color[random.Next(1, 79), random.Next(1, 59)] = Color.Red;
            }
        }

        private void UI_Button_Generate_Click(object sender, EventArgs e)
        {
            FillCanvas();
            for (int i = 0; i < color.GetLength(0); i++)
            {
                for (int j = 0; j < color.GetLength(1); j++)
                {
                    canvas.SetBBScaledPixel(i, j, color[i, j]);
                    canvas.Render();
                }
            }

        }
        private void UI_TrackBar_Scroll(object sender, EventArgs e)
        {
            numberofblocks = UI_TrackBar.Value;
        }

        private void floodfill(int x, int y, Color oldColor, Color newColor)
        {
            if (color[x, y] != oldColor)
            {
                return;
            }
            color[x, y] = newColor;
            floodfill(x + 1, y, oldColor, newColor); 
            floodfill(x - 1, y, oldColor, newColor); 
            floodfill(x, y + 1, oldColor, newColor);
            floodfill(x, y - 1, oldColor, newColor);
        }

        private void UI_Button_Fill_Click(object sender, EventArgs e)
        {

        }
    }

}
