//****************************************************************************************************************************
//Program:          Lab 02 CLASS -Table
//Description:      Table Class
//Date:             Nov, 07, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.CodeDom.Compiler;
namespace Lab_02AdrianB
{
    internal class Table
    {
        #region Properties
        public CDrawer _canvas { get; private set; } = null;        //Canvas
        private List<Ball> _balls = new List<Ball>();               //List of balls including cueball
        private Vector2 _mouseLocation;                             //mouse location on drawer
        private Ball cueBall = null;                                //cueball 
       
        //new copy of the list
        public List<Ball> newCopy
        { 
            get { return _balls; }
        }
        //if the game is running 
        public bool Running
        {
            get
            {
                List<Ball> balls = _balls;
                return balls.Any((x) => x.Velocity.X != 0.0 || x.Velocity.Y != 0.0);
            }
        }
        #endregion

        #region CTOR
        public Table() { }
        #endregion

        #region Methods
        /// <summary>
        /// Making the drawer and number of balls to be placed
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="numofBallReq"></param>
        public void MakeTable(int width, int height, int numofBallReq)
        {
            if(_canvas != null)
                _canvas.Close();
            
            _canvas = new CDrawer(width, height, false, true);
            _canvas.MouseMoveScaled += _canvas_MouseMoveScaled;
            _canvas.MouseLeftClickScaled += _canvas_MouseLeftClickScaled;
            MakeBalls(numofBallReq);
            ShowTable();
        }
        /// <summary>
        /// gets the position of the mouse on the drawer
        /// </summary>
        /// <param name="pos">Poisiton of the mouse</param>
        /// <param name="dr">Current Drawer Being CLicked</param>
        private void _canvas_MouseLeftClickScaled(Point pos, CDrawer dr)
        {
            if (Running)
                return;

            foreach(Ball ball in _balls)
                ball.ResetHits();

            Form1.totalcolFlag = true;
            Vector2 directionShot = new Vector2(pos.X - cueBall.Center.X, pos.Y - cueBall.Center.Y);
            directionShot = Vector2.Normalize(directionShot) * 40f;

            cueBall.SetVelocity(directionShot);
     

            
        }
        /// <summary>
        /// to get the position of the mouse
        /// </summary>
        /// <param name="pos">position of the mouse</param>
        private void _canvas_MouseMoveScaled(Point pos, CDrawer dr)
        {
            //gettign the mouse position 
            _mouseLocation = new Vector2(pos.X, pos.Y);
            if (!Running)
                ShowTable();
        }
        /// <summary>
        /// if the game is running then it will show the balls moving on the screen
        /// if the game is not running then it will draw a line on the cueball so that the palyer can shoot in the dirction of the line
        /// </summary>
        public void ShowTable()
        {
            if (_canvas == null)
                return;
            
            foreach(Ball ball in _balls.ToList())
            {
                ball.Move(_canvas, _balls);
                ball.Show(_canvas);
            }
            if(!Running)
                _canvas.AddLine((int)cueBall.Center.X, (int)cueBall.Center.Y, (int)_mouseLocation.X, (int)_mouseLocation.Y, Color.Yellow, 2);      
            
        }
        /// <summary>
        /// Make balls that dont overlap on the drawer and instert them to a list
        /// </summary>
        /// <param name="numOfballs"></param>
        public void MakeBalls(int numOfballs)
        {
            //clears the current list of balls
            _balls.Clear();
            //Create a balls in list that dont overlap
            while(_balls.Count <= numOfballs && cueBall == null)
            {
                if (numOfballs - _balls.Count == 0)
                {
                    Ball cue = new Ball(_canvas);
                    //if the cue ball overlaps with any ball then dont add
                    if(!_balls.Contains(cue))
                    {
                        _balls.Add(cue);
                        cueBall = cue;
                    }
                }
                else
                {
                    //if the new ball overlaps dont add to the list and keep trying until the balls == the number of balls
                    Ball temp = new Ball(_canvas, RandColor.GetColor());
                    if (!_balls.Contains(temp))
                        _balls.Add(temp);
                    
                }
            }         
        }
        #endregion
    }
}
