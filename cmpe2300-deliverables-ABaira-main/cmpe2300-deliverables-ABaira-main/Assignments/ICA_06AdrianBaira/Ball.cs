//****************************************************************************************************************************
//Program:          ICA 06
//Description:      BALL CLASS
//Date:             Sept, 30, 2024
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
    internal class Ball : IComparable
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
                    _rad = temp;
                
                else if (temp == 0)
                    _rad = 1;
                
                else
                    _rad = temp;
                

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
                    _canvas.Clear();

                else
                    _canvas.Render();
                
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
            _canvas.BBColour = Color.LightGray;
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
                return true;

            else
                return false;

        }

        /// <summary>
        /// Compares the radius of one ball to another and sorts by the biggest radius first then small radius
        /// </summary>
        /// <param name="obj">Object Ball</param>
        public int CompareTo(object obj)
        {
            if(!(obj is Ball b))
                throw new Exception("This is not a Ball");

            if (b._rad.CompareTo(_rad) == 0)
                return CompareColor(b, this);         
            else
                return b._rad.CompareTo(_rad);

        }

        /// <summary>
        /// Sorting the balls from color
        /// </summary>
        /// <param name="left">left Ball </param>
        /// <param name="right">right ball given</param>
        public static int CompareColor(Ball left, Ball right)
        {
            return -left._color.ToArgb().CompareTo(right._color.ToArgb());
        }

        /// <summary>
        /// Compare the distance between one ball and another to the orgin 0,0 and if it is the farthest
        /// </summary>
        public static int CompareDistance(Ball left, Ball right)
        {
            double leftBall = Math.Sqrt(Math.Pow(left._center.X, 2) + Math.Pow(left._center.Y, 2));
            double rightBall = Math.Sqrt(Math.Pow(right._center.X, 2) + Math.Pow(right._center.Y, 2));
            return -leftBall.CompareTo(rightBall);
        }

        /// <summary>
        /// For override equals
        /// </summary>
        public override int GetHashCode()
        {
            return 1;
        }
        #endregion
    }

}
