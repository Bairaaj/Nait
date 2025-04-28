using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA16_AdrianBaira
{
    internal class Blob: BaseShape, IAnimatable
    {
        int _rad;
        Point _point;
        double _animation;
        public Blob(int rad, Point point, double animation): base(point, Color.Gold)
        {
            _rad = rad;
            _point = point;
            _animation = animation;

        }
        protected override Point VirtualMove()
        {
            _point = base.VirtualMove();
            return _point;
        }
        protected override void VirtualPaint()
        {
            _rad = _rad + (_rad / 2);
            throw new NotImplementedException();
        }
        public void Animate(CDrawer canvas)
        {
            
        }
    }
}
