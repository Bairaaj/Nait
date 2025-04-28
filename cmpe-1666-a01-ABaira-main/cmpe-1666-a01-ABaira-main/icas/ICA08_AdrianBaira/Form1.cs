//****************************************************************************
//Program: ICA08 Adrian Baira
//Description: GDI Line Drawer
//Date: Oct, 18, 2023
//Author: Adrian Baira
//Course: CMPE1666
//Class: CNTA01
//****************************************************************************
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
        //Initalizing global variables
        Color[,] color = new Color[80, 60];
        CDrawer canvas = new CDrawer(800, 600);
        int numberofblocks = 100;
        bool check = false;
        public Form1()
        {
            InitializeComponent();
            canvas.Scale = 10;
            Color newcolor = UI_ColorDialog.Color;
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_FillColor_Click(object sender, EventArgs e)
        //Purpose:          To ask user for color to put into fill
        //Returns:          Color
        //**********************************************************************************************
        private void UI_Button_FillColor_Click(object sender, EventArgs e)
        {
            if (UI_ColorDialog.ShowDialog() == DialogResult.OK)
            {
                UI_TextBox_FillColor.BackColor = UI_ColorDialog.Color;
            }
        }
        //**********************************************************************************************
        //Method:           private void FillCanvas()
        //Purpose:          To Fill the Canvas with the red border and random amount of boxes equal to the slider
        //Returns:          Color and GDIDrawer window
        //**********************************************************************************************
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
         
            for (int i = 0; i < numberofblocks; i++)
            {
                color[random.Next(1, 79), random.Next(1, 59)] = Color.Red;
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_Generate_Click(object sender, EventArgs e)
        //Purpose:          When user clicks then will generate the blocks
        //Returns:          Draw on GDI
        //**********************************************************************************************
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
        //**********************************************************************************************
        //Method:           private void UI_TrackBar_Scroll(object sender, EventArgs e)
        //Purpose:          To give amount of Blocks
        //Returns:          Int value of blocks
        //**********************************************************************************************
        private void UI_TrackBar_Scroll(object sender, EventArgs e)
        {
            numberofblocks = UI_TrackBar.Value;
        }
        //**********************************************************************************************
        //Method:           private void floodfill(int x, int y, Color oldColor, Color newColor)
        //Peramaters:       int x, y - Point position
        //                  Color oldColor, newColor - Color of new and old pixel
        //Purpose:          To draw and fill in the sqaures that are black
        //Returns:          Pixels to be drawn
        //**********************************************************************************************
        private void floodfill(int x, int y, Color oldColor, Color newColor)
        {
            if (color[x, y] != oldColor)
            {
                return;
            }
            color[x, y] = newColor;
            //This can make it slow or fast
            Render();
            floodfill(x + 1, y, oldColor, newColor);
            floodfill(x - 1, y, oldColor, newColor);
            floodfill(x, y + 1, oldColor, newColor);
            floodfill(x, y - 1, oldColor, newColor);
        }
        //**********************************************************************************************
        //Method:           private void UI_Button_Fill_Click(object sender, EventArgs e)
        //Purpose:          To allow user to put values into 
        //Returns:          Bool true or false
        //**********************************************************************************************
        private void UI_Button_Fill_Click(object sender, EventArgs e)
        {
            check = true;
        }
        //**********************************************************************************************
        //Method:           private void UI_Timer_Tick(object sender, EventArgs e)
        //Purpose:          To draw on the canvas
        //Returns:          Canvas drawn
        //**********************************************************************************************
        private void UI_Timer_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                Color newcolor = UI_ColorDialog.Color;
                Point point = new Point();
                if (canvas.GetLastMouseLeftClickScaled(out point) && newcolor != Color.Red && newcolor != Color.Black)
                {
                    floodfill(point.X, point.Y, Color.Black, newcolor);
                    Render();
                }
                check = false;
            }
        }
        //**********************************************************************************************
        //Method:           private void Render()
        //Purpose:          To render the Color array
        //Returns:          each point in color array
        //**********************************************************************************************
        private void Render()
        {
            canvas.Clear();
            
            for (int x = 0; x < color.GetLength(0); x++)
            {
                for (int y = 0; y < color.GetLength(1); y++)
                {
                    canvas.SetBBScaledPixel(x, y, color[x, y]);
                }
            }

        }
    }

}
