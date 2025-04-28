using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompQuads_ICAPracticeAdrianBaira
{
    internal class CBall: IComparable
    {
        public int _BallID;
 
        public Point _direction;
        public Point _position;
        int _rad;
        Color _color;


        private int _size;

        public int size 
        {
            set
            {
                _size = Math.Abs(value);
            }
        }

        public enum EsortType { test, ok, things};

        public static EsortType OKATTT { get; set; }
  
  




        public CBall(int rad, Color col)
        {
            _rad = rad;
            _color = col;
        }

        public void Move()
        {

        }

        public int CompareTo(object obj)
        {
            if(!(obj is CBall b)) 
                return 1;

            if(_rad.CompareTo(b._rad) == 0)
                return _color.ToArgb().CompareTo(b._color.ToArgb());
            else
                return _rad.CompareTo(b._rad);
        }

        public static int CompareRad(CBall left, CBall right)
        {
            return left._rad.CompareTo(right._rad);
        }
        public override string ToString()
        {
            return $"Rad: {_rad} | Color {_color}";
        }

    }
}
