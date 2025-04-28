//*************************************************************************************************               
//Program:          LAB01_ImagePress
//Description:      CLASS BaseBitmap 
//Date:             Feb. 24, 2025
//Author:           Adrian Baira
//Course:           CMPE2800
//Class:            CNTA03
//**************************************************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_AdrianBaira
{
    public abstract class BaseBitmapManip
    {
        #region Properties
        // a COPY of the original bitmap (assigned from the constructor)
        public Bitmap BitmapOriginal { get; private set; }
        #endregion

        #region CTOR
        // constructor requires a source Bitmap, and an error handler 
        // the error handler will be used for error notification
        //  when operating the provided bitmap (load, NULL, etc.)
        public BaseBitmapManip(Bitmap bm, Action<string> error)
        {
            try
            {
                // other error handling here?
                // save a copy of the image
                BitmapOriginal = new Bitmap(bm);
            }
            catch (Exception ex)
            {
                error?.Invoke(ex.Message);
            }
        }
        #endregion


        #region Methods
        // build of a dictionary of colors and their frequencies from
        //  the source image
        // this will tell us the total number of colours in the image
        //  and the results may be ordered to find the most popular
        // colour (something of value for the manipulation)
        /// <summary>
        /// Building a dictionary of the Color and frequency of how much that color shows up
        /// </summary>
        /// <returns></returns>
        public Dictionary<Color, int> BuildColourTable()
        {
            Dictionary<Color, int> result = new Dictionary<Color, int>();
            // details omitted – you need to implement this
            for(int x = 0; x < BitmapOriginal.Width; x++)
            {
                for (int y = 0; y < BitmapOriginal.Height; y++)
                {
                    Color color = BitmapOriginal.GetPixel(x, y);
                    if(!result.ContainsKey(color))
                        result.Add(color, 1);
                    else
                        result[color]++;
                }
            }
            return result;
        }

        // generate a 'difference' value from two colours
        // will be compared against a threshold value
        public static int GetColourDifference(Color A, Color B)
        {
            int iR = Math.Abs(A.R - B.R);
            int iG = Math.Abs(A.G - B.G);
            int iB = Math.Abs(A.B - B.B);

            return iR + iG + iB;
        }

        // abstract method to perform the image manipulation (reduction)
        //  returns a new image that is the reduced version (original unmodified)
        // your derived class will implement this behaviour
        public abstract Bitmap ReduceImage(int Threshold);
        #endregion
    }

}
