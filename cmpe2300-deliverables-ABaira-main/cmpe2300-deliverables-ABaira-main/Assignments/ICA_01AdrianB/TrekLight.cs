//****************************************************************************************************************************
//Program:          ICA01_AdrianB
//Description:      TrekLight Class Treklight
//Date:             Sept, 13, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//TrekLight type - Class definition - Support class
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
namespace ICA_0AdrianB
{
    internal class TrekLight
    {
        #region Properties
        private Color _LightColor;      //Light of A single Light
        private byte _on;               //Turning on or off the Light the value is the threshhold in which it turns on 
        private byte _tick;             //Timer for when the light will turn on and off
        private int _bWidth;            //Border width of the Light
        #endregion

        #region CTOR

        /// <summary>
        /// Creating a TrekLight object with default border width at 2 and a random tick byte value
        /// </summary>
        /// <param name="LightColor"></param>
        /// <param name="on"></param>
        /// <param name="bWidth"></param>

        public TrekLight(Color LightColor, byte on, int bWidth = 2)
        {
            Random rng = new Random();
            _LightColor = LightColor;
            _on = on;
            _tick = (byte)rng.Next(256);
            _bWidth = bWidth;
        }

        /// <summary>
        /// Default Constructor that leverage the custom constructor initalizing a random color, on byte of 64 and a border of 6
        /// </summary>
        public TrekLight(): this(RandColor.GetColor(), 64, 6){ }
        #endregion

        #region Methods

        /// <summary>
        /// This will increment the current tick value of the TrekLight object
        /// </summary>
        public void Tick()
        {
            _tick += 3;
        }

        /// <summary>
        /// Position the Treklight at the x and y for a 1D array and render the TrekLight onto the Drawer
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="currentLamp"></param>
        public void RenderLight(CDrawer canvas, int currentLamp)
        {
            int y = (currentLamp / canvas.ScaledWidth); // ROW
            int x = currentLamp % canvas.ScaledWidth;   //COLUMN
            if (_tick >  _on)
            {
                canvas.AddRectangle(x, y, 1, 1, _LightColor, _bWidth, Color.Black);
            }    
        }

        /// <summary>
        /// Turns on the TrekLight no matter if it was in the on or off iteration
        /// </summary>
        public void RedAlert()
        {
            _tick = _on;
        }
        #endregion
    }
}
