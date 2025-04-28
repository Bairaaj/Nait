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
    //Delegates for the Color Change 
    public delegate void delChangeColor(Color color);
    //Delegate for the Opacity
    public delegate void delOpacity(int opacity);
    public partial class ColorOpacity : Form
    {
        //to set the inital value from the main form to the color
        public Color Inital 
        { 
            set 
            {
                //Grabs the main form inital values
                UI_TrackBar_red.Value = value.R;
                UI_TrackBar_Green.Value = value.G;
                UI_TrackBar_Blue.Value = value.B;
                
            } 
        }
        public int Opacityy
        {
            set
            {
                UI_TrackBar_Opacity.Value = value;
            }
        }
        //first inital delegate to null;
        public delChangeColor delChangeColor = null;
        public delOpacity delOpacity = null;
        public ColorOpacity()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void UI_TrackBar_red_Scroll(object sender, EventArgs e)
        //Purpose:          to set the color values from 0 to 255
        //Returns:          color values and opacity values
        //**********************************************************************************************
        private void UI_TrackBar_red_Scroll(object sender, EventArgs e)
        {
            Color UIColor = Color.FromArgb(UI_TrackBar_red.Value, UI_TrackBar_Green.Value, UI_TrackBar_Blue.Value);
            //passing the variable into the delegate
            delChangeColor(UIColor);
            //passing the value for opacity for the delegate
            delOpacity(UI_TrackBar_Opacity.Value);
        }
    }
}
