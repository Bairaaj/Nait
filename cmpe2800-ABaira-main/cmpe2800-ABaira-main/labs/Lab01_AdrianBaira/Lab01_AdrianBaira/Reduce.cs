//*************************************************************************************************               
//Program:          LAB01_ImagePress
//Description:      Reduce CLASS 
//Date:             Feb. 24, 2025
//Author:           Adrian Baira
//Course:           CMPE2800
//Class:            CNTA03
//**************************************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_AdrianBaira
{
    public class Reduce : BaseBitmapManip
    {
        #region Properties
        public Stopwatch timer { get; set; }            //Timer to get the time for how long the thread took
        public int ColRemoved { get; private set; }     //Count of how many colors has it reduced to
        #endregion

        #region CTOR
        /// <summary>
        /// Constructor for Reducing 
        /// </summary>
        public Reduce(Bitmap bm, Action<string> error) : base(bm, error) {}
        #endregion

        #region Overrides
        /// <summary>
        /// Reduces image to colors that are equal or less than threshold value and removed them from the image
        /// </summary>
        /// <param name="threshold">Threshhold value to compare the frequency of a color in the color table</param>
        /// <returns>A Bitmap of the new Reduced Image</returns>
        public override Bitmap ReduceImage(int threshold)
        {   
            //Timer for ms 
            timer = new Stopwatch();
            timer.Start();
            //Copy of the bitmap to change 
            Bitmap copy = new Bitmap(BitmapOriginal);

            //Color table to get the Color and how many times it shows up in the picture
            Dictionary<Color, int> colorTable = BuildColourTable();

            //all the colors that are bellow or at the threshold value
            List<Color> matchingColors = new List<Color>();

            Dictionary<Color, Color> Test = new Dictionary<Color, Color>();
            
            //loop for each Color in the Color table
            while (colorTable.Count > 0)
            {
                //Always get the Color that has the biggest freq
                var mostPop = colorTable.OrderByDescending(x => x.Value).First().Key;

                //Check in the table if the color and the most popular 
                foreach (var col in colorTable.Keys)
                {
                    if (GetColourDifference(mostPop, col) <= threshold)
                    {
                        matchingColors.Add(col);
                        Test[col] = mostPop;
                    }
                        
                }
                //Testing 
                Console.WriteLine("now reduce");
               
               
                //once done them remove all the matching colors in the color table
                foreach (Color c in matchingColors)
                    colorTable.Remove(c);

                //reset the color table
                matchingColors.Clear();
                ColRemoved++;
            }
            //to the most popular color
            //get the pixel from the bitmap and if the pixel is in the list of matching colors then set the pixel
            for (int x = 0; x < copy.Width; x++)
            {
                for (int y = 0; y < copy.Height; y++)
                {
                    Color pixel = copy.GetPixel(x, y);
                    if (Test.ContainsKey(pixel))
                        copy.SetPixel(x, y, Test[pixel]);
                }
            }
            //stop the timer 
            timer.Stop();
            return copy;
        }
        #endregion
    }
}
