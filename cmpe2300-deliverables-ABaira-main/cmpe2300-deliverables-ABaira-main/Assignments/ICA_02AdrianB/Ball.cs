//****************************************************************************************************************************
//Program:          ICA 02 
//Description:      Bouncy Properties - BALL CLASS
//Date:             Sept, 12, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using GDIDrawer;
namespace ICA02_AdrianB
{
    internal class Ball
    {
        #region Properties

        static Random _random = new Random();                   //Random Value for radius and velocity
        private int _rad;                                       //Radius of the balls   
        public Vector2 _center { get; private set; }            //Center of the Ball
        public Vector2 _velocity { get; private set; }          //Velocity of the ball
        private Color _color;                                   //Color of the ball
        private int _opacity;                                   //Opacity of the ball
        public int opacity                                      //manual property to lock the opacity value
        {
            set
            {
                int temp = Math.Abs(value);
                if(temp <= 64)
                    temp = 64;
                if(temp >= 255)
                    temp = 255;
                _opacity = temp;
            }
        }
        public int rad                                          //radius to make the radius greater than 1 but less then 100
        {
            set 
            {
                if (value < 1)
                    value = 1;
                else if (value > 100)
                    value = 100;
                else
                    _rad = value; 
            }
        }
        #endregion

        #region CTOR
        /// <summary>
        /// Creating a New ball and random velocity and radius from where the user clicked onto the Canvas
        /// </summary>
        /// <param name="center">Center of the ball using user input</param>
        public Ball(Point center)
        {
            _color = RandColor.GetColor();                      //Random Color of the ball being generated
            _rad = _random.Next(30, 101);                       //Random Radius value
            float x = (float)_random.NextDouble() * 20 - 10;    //Random Float Values between -10 and 10
            float y = (float)_random.NextDouble() * 20 - 10;  
            _center = new Vector2(center.X, center.Y);          //Center of the ball using the Point user clicked
            _velocity = new Vector2(x,y);                       //Random Velocty value that was generated
            opacity = 128;                                      //Opacity of the ball
        }
        #endregion

        #region Methods

        /// <summary>
        /// Moving the ball according to its velocity that was generated
        /// </summary>
        /// <param name="canvas">Canvas Drawer to allow width and height used for reflection of the walls</param>
        public void MoveBall(CDrawer canvas)
        {
            float x = _center.X;
            float y = _center.Y;
            //if the ball is going left and hit the wall
            if(x < _rad)
            {
                x = _rad;
                _velocity = new Vector2(-_velocity.X, _velocity.Y);
            }

            //if the ball is going right and hit the wall
            if(x >= canvas.m_ciWidth - _rad)
            {
                x = canvas.m_ciWidth - _rad- 1;
                _velocity = new Vector2(-_velocity.X, _velocity.Y);
            }

            //if the ball is hitting the top of the screen
            if (y < _rad)
            {
                y = _rad;
                _velocity = new Vector2(_velocity.X, -_velocity.Y);
            }

            //if the ball is hitting the bottom of the screen taking into account of the radius 
            if (y >= canvas.m_ciHeight - _rad)
            {
                y = canvas.m_ciHeight - _rad - 1;
                _velocity = new Vector2(_velocity.X, -_velocity.Y);
            }
            //adding the velocity to the x center and y center to move the ball
            x += _velocity.X;
            y += _velocity.Y;
            
            //making the new center of the ball with the added velocity
            _center = new Vector2(x, y);
        }
        /// <summary>
        /// Helper Method to draw the ball on the canvas
        /// </summary>
        /// <param name="canvas">canvas to draw on</param>
        public void ShowBall(CDrawer canvas)
        { 
            canvas?.AddCenteredEllipse((int)_center.X, (int)_center.Y, _rad * 2, _rad * 2, Color.FromArgb(_opacity, _color));
        }
        /// <summary>
        /// Allowing the properties of the ball to be shown
        /// </summary>
        /// <returns>Format to show the radius position and opacity</returns>
        public override string ToString()
        {
            return $"<{_center.X:F2}, {_center.Y:F2}> - Radius : {_rad}, Opacity: {_opacity}";
        }
        #endregion
    }
}
