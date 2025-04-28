//*************************************************************************************************               
//Program:          LAB01_ImagePress
//Description:      Reducing an image 
//Date:             Feb. 24, 2025
//Author:           Adrian Baira
//Course:           CMPE2800
//Class:            CNTA03
//**************************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Lab01_AdrianBaira
{
    public partial class ImagePress : Form
    {
        //ThreashHold Value for what image reduces
        int threshHoldValue = 1;

        #region CTOR
        /// <summary>
        /// Form Constructor
        /// Allow drop into the picture box
        /// Subscribe to the mouse wheel event to change threshold value
        /// </summary>
        public ImagePress()
        {
            InitializeComponent();
            UI_PictureBox.AllowDrop = true;
            UI_TXT_ThreshHoldValue.MouseWheel += UI_TXT_ThreshHoldValue_MouseWheel;
        }
        #endregion
        #region Methods
        /// <summary>
        /// When user scrolls it changes the value of the threshold value
        /// and adds it to the text box
        /// </summary>
        /// <param name="e"> Mouse event</param>
        private void UI_TXT_ThreshHoldValue_MouseWheel(object sender, MouseEventArgs e)
        {
            //when they scroll up then change value by one but stop when value reaches 256
            if(e.Delta > 0)
            {
                if(threshHoldValue++ >= 256)
                    threshHoldValue = 256;
            }
            //scroll down stop when value is less than 1 and keep it at 1
            else if (e.Delta < 0)
            {
                if(threshHoldValue-- <= 1)
                    threshHoldValue = 1;
            }
            UI_TXT_ThreshHoldValue.Text = threshHoldValue.ToString();
        }
        /// <summary>
        /// Drag drop feature to allow user to drop a image into the picture box
        /// </summary>
        /// <param name="e">Drag event</param>
        private void UI_PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] filepath = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (filepath != null && filepath.Length > 0)
                {
                    Bitmap bitmap = new Bitmap(filepath[0]);
                    //set the picture box to the image
                    UI_PictureBox.Image = bitmap;
                    BaseBitmapManip image = new Reduce(bitmap, x => MessageBox.Show(x));
                    UI_LBL_DragDropImagein.Text = $"There are {image.BuildColourTable().Count()} colours in this image!";
                }
                else
                    UI_LBL_DragDropImagein.Text = "Invalid";
            }
            catch (Exception ex)
            {
                UI_LBL_DragDropImagein.Text = ex.Message;
            }
        }
        /// <summary>
        /// When user enters the picture box to allow drag and drop to work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        /// <summary>
        /// Reduce image accoring to the threshold value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_BTN_Reduce_Click(object sender, EventArgs e)
        {
            //IF the image in the picture ovx is empty then return no need to process
            if (UI_PictureBox.Image == null)
                return;
            //Prevent user clicking reduce button if clicked twice to prevent errors
            UI_BTN_Reduce.Enabled = false;

            //making a new thread and reducing the image
            Thread thread = new Thread(() =>
            {
                Bitmap bitmap = new Bitmap(UI_PictureBox.Image);
                Reduce reducedimg = new Reduce(bitmap, Error);
                UI_PictureBox.Image = reducedimg.ReduceImage(threshHoldValue);
                //allowing to update the UI within the thread
                Action updateUI = () =>
                {
                    UI_LBL_DragDropImagein.Text = $"Reduced : {reducedimg.ColRemoved} colors in {reducedimg.timer.ElapsedMilliseconds} ms";
                    UI_BTN_Reduce.Enabled = true;
                };

                // Invoke the Action on the UI thread
                this.Invoke(updateUI);
            });
            //start the thread and set it as a background thread
            thread.IsBackground = true;
            thread.Start();

        }
        /// <summary>
        /// Error Message if the Reduce method doesnt work
        /// </summary>
        /// <param name="error"></param>
        public void Error(string error)
        {
            MessageBox.Show(error);
        }
        #endregion
    }
}
