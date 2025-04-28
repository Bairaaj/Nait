//****************************************************************************************************************************
//Program:          ICA 04 
//Description:      BALL CLASS
//Date:             Sept, 20, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Numerics;
namespace ICA_04AdrianBaira
{
    internal class Ball
    {
        #region Properties
        private static CDrawer _canvas = null;          //Creating a Static _canvas 
        private static Random _random = new Random();   //Random value
        private int _rad;                               //Radius of the ball
        private Color _color;                           //Color of the ball
        private Vector2 _center;                         //center position of the ball

        /// <summary>
        /// Radius of the ball to keep it not 0 and a positive value
        /// </summary>
        public int rad
        {
            set
            {
                int temp = Math.Abs(value);
                if(temp < 0)
                {
                    _rad = temp;
                }
                else if (temp == 0)
                {
                    _rad = 1;
                }
                else
                {
                    _rad = temp;
                }

            }
        }

        /// <summary>
        /// to render onto the drawer and or clear it
        /// </summary>
        public static bool Loading
        {
            set
            {
                if (value)
                {
                    _canvas.Clear();
                }
                else
                {
                    _canvas.Render();
                }
            }
        }

        /// <summary>
        /// sets the position of the canvas on the screen
        /// </summary>
        public static Point Placement
        {
            set
            {
                _canvas.Position = new Point(value.X, value.Y);
            }
        }
        #endregion

        #region CTOR
        /// <summary>
        /// Static constructor where we set the new drawer and set continuous update to false
        /// </summary>
        static Ball()
        {
            _canvas = new CDrawer();
            _canvas.ContinuousUpdate = false;
            //_canvas.BBColour = RandColor.GetColor();
        }
        /// <summary>
        /// Making a ball when a new instance of ball is being called
        /// </summary>
        /// <param name="radius">Radius size of the ball</param>
        public Ball(int radius)
        {
            _color = RandColor.GetColor();                                      //random color of ball
            rad = radius;                                                       //setting the radius
            float x = _random.Next(_rad, _canvas.ScaledWidth - _rad - 1);       //random x value on GDI
            float y = _random.Next(_rad, _canvas.ScaledHeight - _rad - 1);      //random y value on GDI
            _center = new Vector2(x, y);                                        //Center of the ball being placed
        }
        #endregion

        #region Methods

        /// <summary>
        /// Add ball to the canvas
        /// </summary>
        public void AddBall()
        {
            _canvas?.AddCenteredEllipse((int)_center.X, (int)_center.Y, _rad * 2, _rad * 2, _color);   
        }

        /// <summary>
        /// Overide equals for overlapping balls
        /// </summary>
        /// <param name="obj">object of ball being passed in</param>
        /// <returns>Return true if balls overlap and false if balls dont overlap</returns>
        public override bool Equals(object obj)
        {
            if(!(obj is Ball b))
                return false;
            //Distance between two balls
            double distance = Math.Sqrt(Math.Pow(b._center.X - _center.X, 2) + Math.Pow(b._center.Y - _center.Y, 2));

            //if the distance is overlaping with both the radius then reutrn true
            if(distance <= b._rad + _rad)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// For override equals
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 1;
        }
        #endregion
    }

}
