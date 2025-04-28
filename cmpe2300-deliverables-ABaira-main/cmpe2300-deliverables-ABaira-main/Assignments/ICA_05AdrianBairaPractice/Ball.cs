using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace ICA_05AdrianBairaPractice
{
    internal class Ball
    {
        private PointF _pos;
        private PointF _direction;
        private float _rad;
        public const int height = 600;
        public const int width = 400;
        private int numberequals;
        public bool highlight { private get;  set; }

        public Ball(Point pos, PointF direction, float rad)
        {
            _rad = rad;
            _pos = pos;
            _direction = direction;
        }
        public static float GetDistance(Ball left, Ball right)
        {
            return (float)Math.Sqrt(Math.Pow(left._pos.X - right._pos.X, 2) + Math.Pow(left._pos.Y - right._pos.Y, 2));
        }
        public void Move()
        {
            _pos.X += _direction.X;
            _pos.Y += _direction.Y;

            if (_pos.X < _rad)
            {
                _pos.X = _rad;
                _direction.X = -_direction.X;
            }
            if (_pos.X > width - _rad)
            {
                _pos.X = width - _rad - 1;
                _direction.X = -_direction.X;
            }
            if (_pos.Y < _rad)
            {
                _pos.Y = _rad;
                _direction.Y = -_direction.Y;
            }
            if (_pos.Y > height - _rad)
            {
                _pos.Y = height - _rad - 1;
                _direction.Y = -_direction.Y;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ball b))
                throw new Exception("this is not a ball");
            float distance = GetDistance(b, this);
            if (distance <= b._rad + this._rad)
                numberequals++;

            return distance <= b._rad + this._rad;

        }

        public void Render(CDrawer canvas)
        {
            if (highlight)
                canvas?.AddCenteredEllipse((int)_pos.X, (int)_pos.Y, (int)_rad * 2, (int)_rad * 2, Color.Yellow, 1, Color.White);
            else
                canvas?.AddCenteredEllipse((int)_pos.X, (int)_pos.Y, (int)_rad * 2, (int)_rad * 2, Color.DarkCyan, 1, Color.White);
            canvas?.AddText($"{numberequals}", _rad / 2, (int)(_pos.X - _rad / 2), (int)(_pos.Y - _rad / 2), (int)_rad, (int)_rad, Color.White);
        }
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
