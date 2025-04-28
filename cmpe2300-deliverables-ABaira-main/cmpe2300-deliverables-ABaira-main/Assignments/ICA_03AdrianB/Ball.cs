//****************************************************************************************************************************
//Program:          ICA 03
//Description:      BALL CLASSs
//Date:             Sept, 20, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ICA_03_AdrianB
{
    internal class Ball
    {
        #region Properties
        private static Random _random = new Random();           //shared random value for all the balls
        private static CDrawer _canvas = null;                  //canvas to draw on
        private static int _rad;                                //radius of each ball
        private Color _color;                                   //color of the ball
        private Vector2 _position;                              //position of the ball on the drawer
        private Vector2 _velocity;                              //how fast the ball is going
        private int _iAlive = 255;                              //lifespan of the ball

        /// <summary>
        /// Abs value of the radius and make sure that the radius be smaller than the smallest height and width of the drawer
        /// </summary>
        public static int rad    
        {  
            get 
            { 
                return _rad; 
            }
            set 
            { 
                //gets only the positive value
                int temp = Math.Abs(value);
                //gets the smaller value between the height and width of the drawer
                int smaller = Math.Min(_canvas.m_ciWidth, _canvas.m_ciHeight) / 2;
                if (temp < 0)
                {
                    temp = 1;
                }
                if(temp > (smaller / 2))
                {
                    _rad = smaller / 2;
                }
                else
                {
                    _rad = temp;
                }
            }
        }

        /// <summary>
        /// Draws on to the drawer at a certain time when user wants to display
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
        /// Placing the Drawer to the same location specified
        /// </summary>
        static Point DrawerLocation 
        { 
            set 
            {
                _canvas.Position = new Point(value.X, value.Y);
            } 
        }

        #endregion

        #region CTOR

        /// <summary>
        /// Static Constuctor create a random drawer width between 500- 700 and height 600 - 800 and random radius between 10-80
        /// </summary>
        static Ball()
        {
            _canvas = new CDrawer(_random.Next(500,701), _random.Next(600,801), false);
            _rad = _random.Next(10, 81);
        }

        /// <summary>
        /// Default CTOR initalize random color, random velocity from -10 and 10 and a random location on the drawer
        /// </summary>
        public Ball()
        {
            _color = RandColor.GetColor();                                      //get random color for the ball
            float x = (float)_random.NextDouble() * 20 - 10;                    //Random x value for velocity
            float y = (float)_random.NextDouble() * 20 - 10;                    //Random y value for velocity
            _velocity = new Vector2(x, y);                                      //setting the velocity
            _position = new Vector2(_random.Next(_rad, _canvas.m_ciWidth - _rad - 1), _random.Next(_rad, _canvas.m_ciHeight - _rad - 1)); //random positon within the drawer
        }
        #endregion
        

        #region Methods

        /// <summary>
        /// To draw on the canvas a ball
        /// </summary>
        public void ShowBall()
        {
            _canvas?.AddCenteredEllipse((int)_position.X, (int)_position.Y, rad * 2, rad * 2, Color.FromArgb(_iAlive, _color));
        }

        /// <summary>
        /// to give movement to the ball and make balls disappear and re-appear and make them in a random positon in the drawer
        /// </summary>
        public void MoveBall()
        {
            _iAlive--;                      //alive decement for the opacity of the ball to simulate the disappearance
            if (_iAlive < 1)                //once ball has disappeared then place in a new random spot and give it a life timer
            {
                _position = new Vector2(_random.Next(_rad, _canvas.m_ciWidth - _rad - 1), _random.Next(_rad, _canvas.m_ciHeight - _rad - 1));
                _iAlive = _random.Next(50, 127);
            }
            //Simulate the movement of the ball
            _position.X += _velocity.X;
            _position.Y += _velocity.Y;

            //if the ball is moving left of the drawer
            if (_position.X < _rad)
            {
                _position.X = rad;
                _velocity.X = -_velocity.X;
            }

            //ball moving to the right of the drawer
            if (_position.X > _canvas.m_ciWidth - _rad - 1)
            {
                _position.X = _canvas.m_ciWidth - rad;
                _velocity.X = -_velocity.X;
            }

            //ball moving upwards in the drawer
            if (_position.Y < _rad)
            {
                _position.Y = _rad;
                _velocity.Y = -_velocity.Y;
            }

            //ball moving downwards in the drawer
            if (_position.Y > _canvas.m_ciHeight - _rad - 1)
            {
                _position.Y = _canvas.m_ciHeight - rad;
                _velocity.Y = -_velocity.Y;
            }
        }
        #endregion
    }
}
