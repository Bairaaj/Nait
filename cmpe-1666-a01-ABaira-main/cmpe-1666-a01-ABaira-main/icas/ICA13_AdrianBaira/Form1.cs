//*************************************************************************************************
//Program: ICA13 Adrian
//Description: Color Opacity
//Date: Nov, 14, 2023
//Author: Adrian Baira
//Course: CMPE1666
//Class: CNTA01
//*************************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA13_AdrianB
{
    public partial class Form1 : Form
    {
        //ColorOpacity dialog initally be null
        ColorOpacity dlg = null;
        public Form1()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void Form1_MouseClick(object sender, MouseEventArgs e)
        //Purpose:          Event handler to grab the new dialog
        //Returns:          color values and opacity values
        //**********************************************************************************************
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dlg == null) //checks if the dlg is initally null
            {
                dlg = new ColorOpacity(); //makes a new dialog
                dlg.delChangeColor = UIColor;   //sets the method color
                dlg.delOpacity = UIOpacity;     //sets the method for opacity
                dlg.Inital = this.BackColor;    //initally grabs the color from the main form 1
                dlg.Opacityy = (int)(this.Opacity * 100); //initally set to 100
            }
            dlg.ShowDialog(); //shows the dialog
        }
        //**********************************************************************************************
        //Method:           private void UIColor(Color color)
        //Purpose:          To set the UI color value from delegate
        //Returns:          color values 
        //**********************************************************************************************
        private void UIColor(Color color)
        {
            this.BackColor = color;
        }
        //**********************************************************************************************
        //Method:           private void UIOpacity(int opacity)
        //Purpose:          sets the opacity of the main form
        //Returns:          Opacity
        //**********************************************************************************************
        private void UIOpacity(int opacity)
        {
            this.Opacity = opacity / 100.00;
        }
    }
}
