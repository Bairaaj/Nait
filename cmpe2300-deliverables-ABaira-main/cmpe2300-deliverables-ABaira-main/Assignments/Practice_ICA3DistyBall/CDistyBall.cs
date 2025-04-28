using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace Practice_ICA3DistyBall
{
    internal class CDistyBall
    {
        private static CDrawer _canvas = null;

        public static int _ballSize { get; set; }

        public PointF _position { get; private set; }



        public CDistyBall(PointF Position)
        {
            if(Position.X < _ballSize)
            {
                Position.X = _ballSize;
            }
            else if(Position.X > _canvas.m_ciWidth - _ballSize)
            {
                Position.X = _canvas.m_ciWidth - _ballSize;
            }
            else if(Position.Y < _ballSize)
            {
                Position.Y = _ballSize;
            }
            else if(Position.Y > _canvas.m_ciHeight - _ballSize)
            {
                Position.Y = _canvas.m_ciHeight - _ballSize;
            }
            else
            {
                _position = Position;
            }
            
        }


        public void Render()
        {
            _canvas?.AddCenteredEllipse((int)_position.X, (int)_position.Y, _ballSize, _ballSize, Color.Red);
        }


        public static float GetDistance(CDistyBall left, CDistyBall right)
        {
            return (float)Math.Sqrt(Math.Pow(left._position.X - right._position.X, 2) + Math.Pow(left._position.Y - right._position.X, 2)); 
        }
        public float GetDistance(CDistyBall ball)
        {
            return GetDistance(ball, this);
        }

        public static void SetDrawer(CDrawer canvas)
        {
            _canvas = canvas;
        }

    }
}
