using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ICA16_AdrianBaira
{
    internal class Snake : BaseShape, IMortal
    {
        LinkedList<Point> _listOfPoints = new LinkedList<Point>();
        int _length;
        int _lives = 0;

        public Snake(int length):base(Point.Empty, RandColor.GetColor())
        {
            _length = length;   
        }


        protected override Point VirtualMove()
        {
            Point point = base.VirtualMove();
            _listOfPoints.AddFirst(point);
            if(_listOfPoints.Count > _length)
            {
                _listOfPoints.RemoveLast();
            }
            return point;
        }
        protected override void VirtualPaint()
        {
            BaseShape._canvas.AddCenteredEllipse(_listOfPoints.First(), 3, 3, Color.Red);
            for(LinkedListNode<Point> node = _listOfPoints.First; node != null; node = node.Next)
            {
                
            }
        }
        public bool Step()
        {
            return --_lives <= 0;
        }

    }
}
