//****************************************************************************************************************************
//Program:          ICA 05 Blocks class
//Description:      Using Icompareable sorting blocks depending on the color, radius and distance
//Date:             Sept, 26, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace ICA05_AdrianBaira
{
    public class Block : IComparable
    {
        #region Members

        private static CDrawer _canvas = null;              //static Canvas
        private static Random _random = new Random();       //Random varable to use for random placement of blocks
        private int _size;                                  //size of the blocks

        #endregion

        #region Properties
        //only get the positive values for blocks
        public int size
        {
            set
            {
                _size = Math.Abs(value);
            }
        }
        private Color _color;           //color of the blocks
        private Rectangle _block;       //block that wil lbe put onto the drawer

        public enum ESortType { eSize, eDistance, eColor, eColorSize }      //sorting methods
        public static ESortType sorts { get; set; }                         //Selecting sorting methods

        /// <summary>
        /// Rendering or clearing the drawer to show blockes being placed
        /// </summary>
        public static bool Loading                                          
        {
            set
            {
                if (value)
                    _canvas?.Clear();
                else
                    _canvas?.Render();
            }
        }
        /// <summary>
        /// Placement of the Drawer on user monitor
        /// </summary>
        public static Point placement
        {
            set
            {
                _canvas.Position = new Point(value.X, value.Y);
            }
        }

        #endregion

        #region CTORS

        /// <summary>
        /// Static when a block class is called it will make a new drawer and set thebackground color to grey and ContinuousUpdate to false
        /// </summary>
        static Block()
        {
            _canvas = new CDrawer();
            _canvas.BBColour = Color.DarkGray;
            _canvas.ContinuousUpdate = false;
        }

        /// <summary>
        /// when a new block is created with user input for size it will give it a random position within the drawer
        /// </summary>
        /// <param name="Size"></param>
        public Block(int Size)
        {
            _color = RandColor.GetColor();
            size = Size;
            _block = new Rectangle(_random.Next( _canvas.ScaledWidth - _size), _random.Next( _canvas.ScaledHeight - _size), _size, _size);
        }
        #endregion

        #region Methods
        /// <summary>
        /// to draw the block on the canvas
        /// </summary>
        public void ShowBlock()
        {
            _canvas?.AddRectangle(_block, _color);
        }

        /// <summary>
        /// override equals to see if a block intersects with another block
        /// </summary>
        /// <param name="obj">object of block will only work</param>
        /// <returns>true if balls overlap, false if balls dont</returns>
        public override bool Equals(object obj)
        {
            if(!(obj is Block block))
                return false;
            
            return (block._block.IntersectsWith(this._block));

        }
        /// <summary>
        /// helps with Equals override
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 1;
        }

        /// <summary>
        /// Sorting methods that will sort by Color, distance and size
        /// </summary>
        /// <param name="obj">block type object</param>
        /// <exception cref="Exception">if user doesnt put in a object type box</exception>
        public int CompareTo(object obj)
        {
            if(!(obj is Block block))
                throw new Exception("This is not a Block");

            //Return value for sorting methods
            int i = 0;

            if(sorts == ESortType.eSize)
                i = -block._size.CompareTo(_size);
            
            if (sorts == ESortType.eDistance)
            {
                //we are looking from orgin 0,0 on drawer so it would be _block.X - 0
                double distance = Math.Sqrt(Math.Pow(_block.X, 2) + Math.Pow(_block.Y, 2));                     //gets the distance of the current block
                double blockdistance = Math.Sqrt(Math.Pow(block._block.X, 2) + Math.Pow(block._block.Y, 2));    //gets the distance of the given block      
                i = distance.CompareTo(blockdistance);
            }

            if (sorts == ESortType.eColor)
                i = _color.ToArgb().CompareTo(block._color.ToArgb());
            
            if (sorts == ESortType.eColorSize)
            {
                if (_color.ToArgb().CompareTo(block._color.ToArgb()) == 0)
                    i = block._size.CompareTo(_size);
                else
                    i =   _color.ToArgb().CompareTo(block._color.ToArgb());
            }

            return i;    
        }
        #endregion
    }
}
