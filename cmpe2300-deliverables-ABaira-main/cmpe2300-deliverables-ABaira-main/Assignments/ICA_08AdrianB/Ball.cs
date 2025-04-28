//****************************************************************************************************************************
//Program:          ICA 08 BALL CLASS
//Description:      Collide-o-matic
//Date:             Oct, 15, 2024
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
using System.Numerics;
using GDIDrawer;
namespace ICA_08AdrianB
{
    internal class Ball
    {
        #region Properties
        private static Random _rng = new Random();          //random number
        private PointF _center;                             //center of the ball
        private Vector2 _velocity;                          //velocity of the ball
        private int _rad;                                   //radius of the ball
        public Color _color { get; set; }                   //color of the ball

        #endregion

        #region CTOR

        /// <summary>
        /// Adding a ball from user mouse click on the drawer and set its location, Color and velocity witha random radius
        /// </summary>
        /// <param name="center">mouseclick on drawer</param>
        /// <param name="color">Color of Ball</param>
        public Ball(PointF center, Color color)
        {
            _center = center;
            _color = color;
            float x = (float)_rng.NextDouble() * 12 - 6;    //random value between -6 and 6
            float y = (float)_rng.NextDouble() * 12 - 6;
            _velocity = new Vector2(x, y);
            _rad = _rng.Next(20, 51);
                 
        }
        #endregion

        #region Methods
        /// <summary>
        /// method to check the distance between two balls and return true if they overlap   
        /// </summary>
        public override bool Equals(object obj)
        {
            //error checking
            if (!(obj is Ball b))
                throw new Exception("this is not a ball");

            //distance of the ball
            double distance = Math.Sqrt(Math.Pow(_center.X - b._center.X, 2) + Math.Pow(_center.Y - b._center.Y, 2));

            //if the distance is less than the the radius of both of the balls then its touching
            return distance <= _rad + b._rad;

        }
        /// <summary>
        /// Helps with override equals
        /// </summary>
        public override int GetHashCode()
        {
            return 1;
        }

        /// <summary>
        /// moves the ball within the drawer and checks the boundary if it hits a wall and change its velocity
        /// </summary>
        /// <param name="canvas">Canvas that use to see balls move and click</param>
        public void Move(CDrawer canvas)
        {
            //changing the positon of the ball with its velocity
            _center.X += _velocity.X;
            _center.Y += _velocity.Y;

            //boundary of the drawer left side
            if (_center.X < _rad)
            {
                _center.X = _rad;
                _velocity.X = -_velocity.X;
            }
            //boundary of the drawer right side

            if (_center.X > canvas.m_ciWidth - _rad)
            {
                _center.X = canvas.m_ciWidth - _rad - 1;
                _velocity.X = -_velocity.X;
            }

            //boundary of the top of the drawer
            if (_center.Y < _rad)
            {
                _center.Y = _rad;
                _velocity.Y = -_velocity.Y;
            }

            //boundary of the bottom of the drawer
            if (_center.Y > canvas.m_ciHeight - _rad)
            {
                _center.Y = canvas.m_ciHeight - _rad - 1;
                _velocity.Y = -_velocity.Y;
            }
            

        }
        /// <summary>
        /// Add the ball the drawer with the number of ball it is
        /// </summary>
        /// <param name="canvas">canvas to draw on</param>
        /// <param name="number">number given to the ball</param>
        public void Show(CDrawer canvas, int number)
        {
            canvas?.AddCenteredEllipse((int)_center.X, (int)_center.Y, _rad * 2, _rad * 2, _color);
            canvas?.AddText($"{number}", _rad/2 , (int)_center.X - (_rad/2), (int)_center.Y - (_rad/2), _rad, _rad, Color.Blue);
            
        }
        #endregion

    }
}
