//****************************************************************************************************************************
//Program:          ICA 07 PrediBlocks
//                  BLOCK CLASS
//Description:      Maze solver
//Date:             Oct, 8, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace ICA_07AdrianB
{
    internal class Block : IComparable
    {
        #region Properties

        public static CDrawer _canvas { get; private set; }         //Canvas to Draw on
        public static int _height { get; private set; }             //Height of the blocks
        private static Random _random = new Random(1);              //random number generator with the seed of 1
        public int _width { get; private set; }                     //Width of the block

        public bool _highLight { get; set; }                        //highlighted block
        private Color _color;                                       //color of the block

        #endregion


        #region CTOR

        /// <summary>
        /// static CTOR makes all blocks height 20
        /// sets canvas with 1000 x 800
        /// sets the canvas background to black
        /// </summary>
        static Block()
        {
            _height = 20;
            _canvas = new CDrawer(1000, 800, false);
            _canvas.BBColour = Color.Black;
        }
        /// <summary>
        /// Random block being generated
        /// width a random width between 10 and 90
        /// </summary>
        public Block()
        {
            _width = _random.Next(1,20) * 10;
            _highLight = false;
            _color = Color.FromArgb(_random.Next(4, 9) * 32 - 1, _random.Next(4, 9) * 32 - 1, _random.Next(4, 9) * 32 - 1);
        }

        #endregion

        #region Methods

        /// <summary>
        /// if the user point is on the canvas it will change the border of it
        /// </summary>
        /// <param name="point">Point on the canvas</param>
        public void ShowBlock(Point point)
        {
            if(_highLight)
                _canvas?.AddRectangle(point.X, point.Y, _width, _height, _color, 3, Color.White);
            else
                _canvas?.AddRectangle(point.X, point.Y, _width, _height, _color, 1, Color.Black);
            
        }

        /// <summary>
        /// Override equals if both width and color are the same then return true
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is Block b))
                throw new Exception("this is not a Block");

            if (b._width == this._width && b._color == this._color)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compares color of one block to another
        /// </summary>
        public int CompareTo(object arg)
        {
            if (!(arg is Block b))
                throw new Exception("This is not a block");

            return b._color.ToArgb().CompareTo(this._color.ToArgb());
        }

        /// <summary>
        /// Sorting by Color then by Width
        /// </summary>
        /// <param name="left">one block</param>
        /// <param name="right">second block from a list</param>
        public static int ColorWidthSort(Block left, Block right)
        {
            if (left == null || right == null)
                throw new Exception("Null");

            if (left.CompareTo(right) == 0)
                return left._width.CompareTo(right._width);
            else
                return left.CompareTo(right);
        }

        /// <summary>
        /// brightness of the blocks and if its greater than 0.7 then remove from list
        /// </summary>
        public static bool Brightness(Block block)
        {
            if (block == null)
                throw new Exception("Null");

            if(block._color.GetBrightness() > 0.7)
                return true;
            else
                return false;
        }

        /// <summary>
        /// helps with equals override
        /// </summary>
        public override int GetHashCode()
        {
            return 1;
        }

        #endregion
    }
}
