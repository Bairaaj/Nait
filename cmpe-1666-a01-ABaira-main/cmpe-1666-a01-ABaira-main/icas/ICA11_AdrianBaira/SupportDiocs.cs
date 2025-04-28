//*************************************************************************************************
//Program: ICA11 Adrian
//Description: Fontify
//Date: OCT, 31, 2023
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

namespace ICA11_AdrianBaira
{
    public partial class SupportDiocs : Form
    {
        public SupportDiocs()
        {
            InitializeComponent();
        }
        //Get set For color Dialog
        public Color GetColor 
        {
            get { return UI_ColorDIO.Color;  } //gets the Color from ColorDIO and passes it to the form1
            set 
            { 
                UI_ColorDIO.Color = value; //gets the value from form1 in where it is called in
                UI_TXT_Colour.Text = UI_ColorDIO.Color.ToString(); //sets the value from form1 to the color text
            }
        }
        //Get set For Font Dialog
        public Font GetFont
        {
            get { return UI_FontDIO.Font; } //gets the font from FontDIO and passees it to the form1
            set 
            {
                UI_FontDIO.Font = value;    //gets the font from form1 in where it is called in
                UI_TXT_Font.Text = UI_FontDIO.Font.ToString(); //set the value from form1 to the font text
            }
         
        }
        //**********************************************************************************************
        //Method:           private void SupportDiocs_Load(object sender, EventArgs e)
        //Purpose:          To keep the same value before
        //Returns:          same color and font
        //**********************************************************************************************
        private void SupportDiocs_Load(object sender, EventArgs e)
        {
            UI_TXT_Colour.Text = Form1.CurrentColor;
            UI_TXT_Font.Text = Form1.CurrentFont;
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Font_Click(object sender, EventArgs e)
        //Purpose:          to show Font dialog window
        //Returns:          string to put into text box
        //**********************************************************************************************
        private void UI_BTN_Font_Click(object sender, EventArgs e)
        {
            UI_FontDIO.ShowDialog();
            UI_TXT_Font.Text = UI_FontDIO.Font.ToString();

        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Colour_Click(object sender, EventArgs e)
        //Purpose:          To show Color dialog window
        //**********************************************************************************************
        private void UI_BTN_Colour_Click(object sender, EventArgs e)
        {
            UI_ColorDIO.ShowDialog();
            UI_TXT_Colour.Text = UI_ColorDIO.Color.ToString();
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Ok_Click(object sender, EventArgs e)
        //Purpose:          To make sure the the results are going though
        //**********************************************************************************************
        private void UI_BTN_Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
