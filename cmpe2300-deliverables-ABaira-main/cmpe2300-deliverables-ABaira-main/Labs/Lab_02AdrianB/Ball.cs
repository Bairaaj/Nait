//****************************************************************************************************************************
//Program:          Lab 02 CLASS -Ball
//Description:      Ball Class
//Date:             Nov, 07, 2024
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
using GDIDrawer;

namespace Lab_02AdrianB
{
    internal class Ball : IComparable
    {
        #region Properties
        public static float _friction = 0.991f;
        static Random _rng = new Random();
        private Vector2 _center;
        private Vector2 _velocity;
        public Vector2 Center { get { return _center; } }
        public Vector2 Velocity { get { return _velocity; } }
        public int Radius { get; private set; }
        public int Hits { get; private set; }
        public int TotalHits { get; private set; }
        public Color BallColor { get; private set; }
        #endregion

        #region CTOR
        /// <summary>
        /// Creating a pool ball with a random radius and position on canvas
        /// </summary>
        /// <param name="canvas">GDI Drawer </param>
        /// <param name="color">Color of ball</param>
        public Ball(CDrawer canvas, Color color)
        {
            BallColor = color;
            Radius = _rng.Next(20, 51);
            float x = _rng.Next(Radius, canvas.m_ciWidth - Radius + 1);
            float y = _rng.Next(Radius, canvas.m_ciHeight - Radius + 1);
            _center = new Vector2(x,y);
        }
        /// <summary>
        /// Create a Pool Ball with a set radius of 30
        /// </summary>
        /// <param name="canvas">GDI Drawer</param>
        public Ball(CDrawer canvas)
        {
            BallColor = Color.White;
            Radius = 30;
            float x = _rng.Next(Radius, canvas.m_ciWidth - Radius + 1);
            float y = _rng.Next(Radius, canvas.m_ciHeight - Radius + 1);
            _center = new Vector2(x, y);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reset each ball hits
        /// </summary>
        public void ResetHits()
        {
            Hits = 0;
        }
        /// <summary>
        /// set the velocity of the ball so it can move across the screen if hit
        /// </summary>
        /// <param name="velocity">Velocity of the ball</param>
        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
        }
        /// <summary>
        /// IF balls overlap with each other then return true but if not the return false
        /// </summary>
        /// <param name="obj">Ball to compare if balls overlap with each other</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Ball ball))
                throw new Exception("This is not a ball");

            double distance = Math.Sqrt(Math.Pow(ball.Center.X - _center.X , 2) +  Math.Pow(ball.Center.Y - _center.Y, 2));
            return distance <= ball.Radius + Radius;
            
        }
        /// <summary>
        /// helps with equals override
        /// </summary>
        public override int GetHashCode()
        {
            return 1;
        }
        /// <summary>
        /// String to put into center of ball to display radius and amount of time the ball has been hit
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Radius} : {Hits} ";
        }
        /// <summary>
        /// compares two balls for sorting with radius
        /// </summary>
        public int CompareTo(object obj)
        {
            if (!(obj is Ball ball)) 
                throw new Exception("this is not a ball");

            return ball.Radius.CompareTo(Radius);
        }
        /// <summary>
        /// Sorting the ball with hits decending
        /// </summary>
        /// <param name="left">one object ball</param>
        /// <param name="right">one object ball</param>
        public static int SortHitsDecending(Ball left, Ball right)
        {
            if (left == null && right == null)
                return 0;

            if(left == null)
                return -1;

            if(right == null) 
                return 1;

            return left.Hits.CompareTo(right.Hits);

        }
        /// <summary>
        /// Sorting the ball with total hits decending
        /// </summary>
        /// <param name="left">one object ball</param>
        /// <param name="right">one object ball</param>
        public static int SortTotalHitsDecending(Ball left, Ball right)
        {
            if (left == null && right == null)
                return 0;

            if (left == null)
                return -1;

            if (right == null)
                return 1;

            return left.TotalHits.CompareTo(right.TotalHits);

        }
        /// <summary>
        /// Shoe each ball on the canvas to render
        /// </summary>
        /// <param name="canvas"></param>
        public void Show(CDrawer canvas)
        {
            //cueball
            if(BallColor == Color.White)
                canvas?.AddCenteredEllipse((int)_center.X, (int)_center.Y, Radius * 2, Radius * 2, Color.White, 2, Color.Yellow);
           
            else
            {
                //pool balls
                canvas?.AddCenteredEllipse((int)_center.X, (int)_center.Y, Radius * 2, Radius * 2, BallColor);
                canvas?.AddText($"{this}", (Radius / 4) , (int)_center.X - Radius / 2  - 5, (int)_center.Y - Radius / 2, Radius + 8, Radius, Color.Black);
            }
            canvas.Render();

           
        }

        /// <summary>
        /// Move the ball with its velocity 
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="balls"></param>
        public void Move(CDrawer canvas, List<Ball> balls)
        {
            _velocity *= _friction;
            if(_velocity.LengthSquared() < 0.1f)
            {
                _velocity = Vector2.Zero;
                return;
            }
            //The left side of drawer
            if (_center.X < Radius)
            {
                _center.X = Radius;
                _velocity.X = -_velocity.X;
            }
            //right side of drawer
            if (_center.X > canvas.m_ciWidth - Radius - 1)
            {
                _center.X = canvas.m_ciWidth - Radius - 1;
                _velocity.X = -_velocity.X;
            }
            //top of drawer
            if (_center.Y < Radius)
            {
                _center.Y = Radius;
                _velocity.Y = -_velocity.Y;
            }
            //bottom of drawer
            if (_center.Y > canvas.m_ciHeight - Radius - 1)
            {
                _center.Y = canvas.m_ciHeight - Radius - 1;
                _velocity.Y = -_velocity.Y;
            }
            //moving the ball
            _center.X += _velocity.X;
            _center.Y += _velocity.Y;


            foreach (Ball ball in balls)
            {
                if (ball == this)
                    continue;

                if (ball.Equals(this))
                    ProcessCollision(ball);
                

            }
        }
        /// <summary>
        /// Helper method giving in pdf to process the collision of balls bouncing off of eachother
        /// </summary>
        /// <param name="tar">object ball</param>
        private void ProcessCollision(Ball tar)
        {
            Vector2 dist = tar._center - _center; // Get Collision Vector
            Vector2 myNorm = Vector2.Normalize(tar._center - _center); // Normalize for invoking ball
            Vector2 targetNorm = Vector2.Normalize(_center - tar._center); // Normalize for target ball

            // Calculate Radius weighted velocity vector
            //Vector2 CMVelocity = Vector2.Add(Vector2.Multiply((float)_iRadius / (_iRadius + tar._iRadius), _v), Vector2.Multiply((float)tar._iRadius / (_iRadius + tar._iRadius), tar._v));
            Vector2 CMVelocity = (_velocity * ((float)Radius / (Radius + tar.Radius)) + (tar._velocity * ((float)tar.Radius / (Radius + tar.Radius))));

            // Process invoking ball
            _velocity -= CMVelocity;// Vector2.Subtract(_v, CMVelocity);
            _velocity = Vector2.Reflect(_velocity, myNorm); // perform "bounce"
            _velocity += CMVelocity;// Vector2.Add(_v, CMVelocity);
            Hits++;
            TotalHits++;

            // Process target ball
            tar._velocity -= CMVelocity;
            tar._velocity = Vector2.Reflect(tar._velocity, targetNorm); // perform bounce
            tar._velocity += CMVelocity;// Vector2.Add(tar._v, CMVelocity);
            tar.Hits++;
            tar.TotalHits++;

            // "Fix" collision if balls overlapped - could apply weighted adjustment shift between both balls
            //       but here we just move the target ball over on collision vector so it doesn't overlap
            //tar._center = Vector2.Add(tar._center, Vector2.Multiply((float)((_iRadius + tar._iRadius - dist.Length()) / (_iRadius + tar._iRadius)), dist));
            tar._center += dist * (float)((Radius + tar.Radius - dist.Length()) / (Radius + tar.Radius));
        }
        #endregion
    }
}
