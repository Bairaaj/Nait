//****************************************************************************************************************************
//Program:          LAB02_AdrianB
//Description:      Picture bender
//Date:             Nov, 3, 2023
//Author:           Adrian Baira
//Course:           CMPE1666
//Class:            CNTA01
//****************************************************************************************************************************
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
        private Bitmap originalbm; //original bitmap
        private Bitmap modifiedbm; //modified bitmap
        
        public Form1()
        {
            InitializeComponent();
            UI_BTN_Transform.Enabled = false; //disables transform button so that user cannot press it 
            UI_LABEL_Right.Text = "More";
            UI_LABEL_Left.Text = "Less";
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_LoadPicture_Click(object sender, EventArgs e)                             
        //Purpose:          To grab a file from files
        //Returns:          bitmap
        //*********************************************************************************************
        private void UI_BTN_LoadPicture_Click(object sender, EventArgs e)
        {
            //To set thhe default value to bmp type and allow files that are .jpg / .png / .bmp;
            UI_OpenFileDialog.RestoreDirectory = true;
            UI_OpenFileDialog.Filter = "JPEG (*.jpg) |*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp| All Files (*.jpg; *.png; *.bmp)|*.jpg;*.png;*.bmp ";
            UI_OpenFileDialog.FilterIndex = 3; //sets the default to bmp
            if (UI_OpenFileDialog.ShowDialog() == DialogResult.OK) // checks if input is ok
            {
                try 
                {
                    UI_PictureBox.Load(UI_OpenFileDialog.FileName); // will load the file
                    originalbm = new Bitmap(UI_PictureBox.Image);   //makes the image a bitmap
                    modifiedbm = new Bitmap(UI_PictureBox.Image);            //makes a copy of orignial image   
                    UI_BTN_Transform.Enabled = true;                //allows user to press transform

                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Picture, please try again"); //invalid if user puts invalid input
                }
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Transform_Click(object sender, EventArgs e)                                
        //Purpose:          To see which button is checked and select appropriate method
        //Returns:          new image from method
        //*********************************************************************************************
        private void UI_BTN_Transform_Click(object sender, EventArgs e)
        {
            
            if (UI_RADIO_Contrast.Checked) // if radio button is checked 
            {
                Contrast(modifiedbm, UI_Trackbar.Value); //method for contrast
            }
            if (UI_RADIO_BlackWhite.Checked)
            {
                BlackAndWhite(modifiedbm, UI_Trackbar.Value); //method for black and white
            }
            if (UI_RADIO_Tint.Checked)
            {              
                Tint(modifiedbm, UI_Trackbar.Value);    //method for tint
            }
            if (UI_RADIO_Noise.Checked)
            {
                Noise(modifiedbm, UI_Trackbar.Value);   //method for noise
            }
            
            UI_LoadBar.Value = 0; //my load bar value to reset every time the transform button is pressed
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_Revert_Click(object sender, EventArgs e)                               
        //Purpose:          To change the image to the orginal and reset the modified image
        //*********************************************************************************************
        private void UI_BTN_Revert_Click(object sender, EventArgs e)
        {
            UI_PictureBox.Image = originalbm;  //reverts the image to the old image
            modifiedbm = new Bitmap(originalbm); //when presses revert it will reset the modified image
        }
        //**********************************************************************************************
        //Method:           private void UI_Trackbar_Scroll(object sender, EventArgs e)                              
        //Purpose:          To change the label to trackbar value
        //Returns:          Label value
        //*********************************************************************************************
        private void UI_Trackbar_Scroll(object sender, EventArgs e)
        {
            UI_LABEL_Middle.Text = UI_Trackbar.Value.ToString(); // to update the value constantly for the middle label
            if (UI_RADIO_Tint.Checked)  //only changes the condtion if user presses the radio button TINT
            {
                if(UI_Trackbar.Value < 0)
                {
                    int temp = UI_Trackbar.Value * -1;  //sets the value for radio button to positive
                    UI_LABEL_Middle.Text = $"To Red: {temp}";   //dispalys value
                }
                if (UI_Trackbar.Value > 0)
                {
                    UI_LABEL_Middle.Text = $"To Green: {UI_Trackbar.Value}";    //displays when track bar is greater than 0
                }
                if (UI_Trackbar.Value == 0) //if user puts value to 0 
                {
                    UI_LABEL_Middle.Text = "None"; //displays none text
                }
            }
        }
        //**********************************************************************************************
        //Method:           private void BlackAndWhite(Bitmap bm, int trackbarvalue)                            
        //Purpose:          To change image to black and white
        //Peramaters:       bitmap   - for the bitmap to be called
        //                  int trackbarvalue - to imcrement the change
        //Returns:          modified bitmap
        //*********************************************************************************************
        private void BlackAndWhite(Bitmap bm, int trackbarvalue)
        {
            for (int x = 0; x < bm.Width; x++) //row for bit map
            {
                for (int y = 0; y < bm.Height; y++) //col for bitmap
                {
                    Color currentimg = bm.GetPixel(x, y); //each pixel for bitmap and saves the color

                    int average = ((currentimg.R + currentimg.G + currentimg.B) / 3);   //finds the average GREY value

                    int red = currentimg.R + ((average - currentimg.R) * trackbarvalue / 100);      // changes the red color to grey value
                    int green = currentimg.G + ((average - currentimg.G) * trackbarvalue / 100);    // changes the green value to grey value
                    int blue = currentimg.B + ((average - currentimg.B) * trackbarvalue / 100);     // changes the blue value to grey value
                    modifiedbm.SetPixel(x, y, Color.FromArgb(red, green, blue)); //sets te pixelon the image
                }
                UI_LoadBar.Increment(1);// increment for eveyrow that has been completed
            }
            UI_PictureBox.Image = modifiedbm; //displays new bitmap image
        }
        //**********************************************************************************************
        //Method:           private void Contrast(Bitmap bm, int trackbarvalue)                            
        //Purpose:          To change the contrast
        //Peramaters:       bitmap   - for the bitmap to be called
        //                  int trackbarvalue - to imcrement the change
        //Returns:          modified bitmap
        //*********************************************************************************************
        private void Contrast(Bitmap bm, int trackbarvalue)
        {
            for (int x = 0; x < bm.Width; x++) //row for bit map
            {
                for (int y = 0; y < bm.Height; y++) //row for bit map
                {
                    Color currentimg = bm.GetPixel(x, y);   //gets current pixel of image
                    int red = currentimg.R;         //variables to manipulate
                    int green = currentimg.G;       //variables to manipulate (makes it easier to work with)
                    int blue = currentimg.B;        //variables to manipulate
                    if (red > 128)
                    {
                        red += (trackbarvalue / 5); // incrementing 1/5th of the track bar and adding it
                    }
                    red -= (trackbarvalue / 5);  // incrementing 1/5th of the track bar and - it
                    if (green > 128)
                    {
                        green += (trackbarvalue / 5); // incrementing 1/5th of the track bar and adding it
                    }
                    green -= (trackbarvalue / 5);    // incrementing 1/5th of the track bar and - it
                    if (blue > 128)
                    {
                        blue += (trackbarvalue / 5); // incrementing 1/5th of the track bar and adding it
                    }
                    blue -= (trackbarvalue / 5);    // // incrementing 1/5th of the track bar and - it
                    MinMax(ref red, ref green, ref blue); //makes sure the values do not go above 255 or below 0
                    modifiedbm.SetPixel(x, y, Color.FromArgb(red, green, blue)); //puts the new values for pixel color
                }
                UI_LoadBar.Increment(1); //increments for every row that has been done
            }
            UI_PictureBox.Image = modifiedbm; //shows modified image in picture box
        }
        //**********************************************************************************************
        //Method:           private void Tint(Bitmap bm, int trackbarvalue)                            
        //Purpose:          To change image Tint
        //Peramaters:       bitmap   - for the bitmap to be called
        //                  int trackbarvalue - to imcrement the change
        //Returns:          modified bitmap
        //*********************************************************************************************
        private void Tint(Bitmap bm, int trackbarvalue)
        {
            for (int x = 0; x < bm.Width; x++) // row bit map
            {
                for (int y = 0; y < bm.Height; y++) //col bitmap
                {
                    Color currentimg = bm.GetPixel(x, y);   //grabs the image pixel 
                    int red = currentimg.R;     //variables to manipulate
                    int green = currentimg.G;   //variables to manipulate
                    int blue = currentimg.B;     //variables to manipulate
                    if (trackbarvalue < 0)  
                    {
                        red = red + (50 - trackbarvalue); // if the track bar is less than 0 
                    }
                    if (trackbarvalue > 0)
                    {
                        green = green + (trackbarvalue + 50); //if track bar is more than 
                    }

                    MinMax(ref red, ref green, ref blue); //minimum and max check to 0 to 255

                    modifiedbm.SetPixel(x, y, Color.FromArgb(red, green, blue)); //sets new pixel for image
                }
                UI_LoadBar.Increment(1); //increments 
            }
            UI_PictureBox.Image = modifiedbm; //sets the picture box to new image
        }
        //**********************************************************************************************
        //Method:           private void Noise(Bitmap bm, int trackbarvalue)                            
        //Purpose:          To change the image to have noise
        //Peramaters:       bitmap   - for the bitmap to be called
        //                  int trackbarvalue - to imcrement the change
        //Returns:          modified bitmap
        //*********************************************************************************************
        private void Noise(Bitmap bm, int trackbarvalue)
        {
            Random random = new Random(); //gets a random number
            for (int x = 0; x < bm.Width; x++) //row image pixel
            {
                for (int y = 0; y < bm.Height; y++) //col image pixel
                {
                    Color currentimg = bm.GetPixel(x, y); //gets the pixel

                    int red = currentimg.R;     //variables to manipulate
                    int green = currentimg.G;   //variables to manipulate
                    int blue = currentimg.B;    //variables to manipulate

                    red = red + (random.Next(0, 256) % ((trackbarvalue + 1) * 2) - trackbarvalue); 
                    green = green + (random.Next(0, 256) % ((trackbarvalue + 1) * 2) - trackbarvalue);
                    blue = blue + (random.Next(0, 256) % ((trackbarvalue + 1) * 2) - trackbarvalue);

                    MinMax(ref red, ref green, ref blue); //checks if value is between 0 and 255

                    modifiedbm.SetPixel(x, y, Color.FromArgb(red, green, blue)); //sets the new pixel
                }
                UI_LoadBar.Increment(1); //increment every row completed
            }
            UI_PictureBox.Image = modifiedbm; //displays new image
        }
        //**********************************************************************************************
        //Method:           private void MinMax(ref int red, ref int green, ref int blue)                            
        //Purpose:          To check for a valid user input and give a proper value to be user
        //Peramaters:       ref int red
        //                  ref int green
        //                  ref int blue
        //Returns:          ref red, ref green, ref blue
        //*********************************************************************************************
        private void MinMax(ref int red, ref int green, ref int blue)
        {
            //limits between 0 and 255 for red
            red = (red < 255) ? red : 255;  
            red = (red > 0) ? red : 0;
            //limits between 0 and 255 for green
            green = (green < 255) ? green : 255;
            green = (green > 0) ? green : 0;
            //limits between 0 and 255 for blue
            blue = (blue < 255) ? blue : 255;
            blue = (blue > 0) ? blue : 0;
        }
        //**********************************************************************************************
        //Method:           private void UI_RADIO_Contrast_CheckedChanged(object sender, EventArgs e)                       
        //Purpose:          to change the label and track bar value
        //*********************************************************************************************
        private void UI_RADIO_Contrast_CheckedChanged(object sender, EventArgs e)
        {
            //sets the new labels and track bar value
            UI_Trackbar.Minimum = 0;
            UI_Trackbar.Maximum = 100;
            UI_LABEL_Left.Text = "Less";
            UI_LABEL_Middle.Text = $"{UI_Trackbar.Value}";
            UI_LABEL_Right.Text = "More";
        }
        //**********************************************************************************************
        //Method:           private void UI_RADIO_Contrast_CheckedChanged(object sender, EventArgs e)                       
        //Purpose:          to change the label and track bar value
        //*********************************************************************************************
        private void UI_RADIO_Tint_CheckedChanged(object sender, EventArgs e)
        {
            //sets the new labels and track bar value
            UI_Trackbar.Minimum = -50;
            UI_Trackbar.Maximum = 50;
            UI_Trackbar.Value = 0;
            UI_LABEL_Left.Text = "Red";
            UI_LABEL_Middle.Text = "None";
            UI_LABEL_Right.Text = "Green";
        }
        //**********************************************************************************************
        //Method:           private void UI_RADIO_BlackWhite_CheckedChanged(object sender, EventArgs e)                       
        //Purpose:          to change the label and track bar value
        //*********************************************************************************************
        private void UI_RADIO_BlackWhite_CheckedChanged(object sender, EventArgs e)
        {
            //sets the new labels and track bar value
            UI_Trackbar.Minimum = 0;
            UI_Trackbar.Maximum = 100;
            UI_LABEL_Left.Text = "Less";
            UI_LABEL_Middle.Text = $"{UI_Trackbar.Value}";
            UI_LABEL_Right.Text = "More";
        }
        //**********************************************************************************************
        //Method:           private void UI_RADIO_Noise_CheckedChanged(object sender, EventArgs e)                       
        //Purpose:          to change the label and track bar value
        //*********************************************************************************************
        private void UI_RADIO_Noise_CheckedChanged(object sender, EventArgs e)
        {
            //sets the new labels and track bar value
            UI_Trackbar.Minimum = 0;
            UI_Trackbar.Maximum = 100;
            UI_LABEL_Left.Text = "Less";
            UI_LABEL_Middle.Text = $"{UI_Trackbar.Value}";
            UI_LABEL_Right.Text = "More";
        }
    }
}
