using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
namespace ICA15
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        List<BaseShape> list = new List<BaseShape>();
        CDrawer canvas = new CDrawer();
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            BaseShape._canvas = canvas;
            canvas.ContinuousUpdate = false;
            timer.Interval = 50;
            timer.Start();
            timer.Tick += Timer_Tick;
            KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            canvas.GetLastMouseLeftClick(out Point point);

            if(e.KeyCode == Keys.C)
            {
                list.Clear();
            }
            if(e.KeyCode == Keys.S)
            {
                list.Add(new Snake(point, random.Next(20, 61), Color.Red));
            }
            if(e.KeyCode == Keys.B)
            {
                list.Add(new Blob(random.Next(30,51), point, Color.Blue));
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            canvas.Clear();

            list.RemoveAll(x => x is IMortal mortal && !mortal.Step());

            list.OfType<IAnimatable>().ToList().ForEach(x => x.Animate(canvas));

            list.ForEach(shape => { shape.Move(); shape.Paint(); });
            canvas.Render();
        }
    }
    public abstract class BaseShape
    {
        public static CDrawer _canvas { get; set; } // Change to your PicDrawer
        public static Random _rnd { get; private set; }
        private Point _pt { get; set; } // Center of Shape
        public Color _color { get; private set; } // Color of Shape
        private double _dir = 0; // Radians vector of direction
        private double _vel = 5; // Movement velocity
        static BaseShape()
        {
            _rnd = new Random(0);
        }
        public BaseShape(Point pt, Color c)
        {
            _pt = pt;
            _color = c;
            // 0 is right, then counter-clockwise, in radians
            _dir = _rnd.NextDouble() * 2 * Math.PI;
        }
        public Point Move() // NVI - public Move()
        {
            return VirtualMove(); // invokes VirtualMove()
        }
        public void Paint() // NVI - public Paint()
        {
            VirtualPaint(); // invokes VirtualPaint()
        }
        protected virtual Point VirtualMove()
        {
            // Adjust current direction by small random amount
            _dir = _dir + (_rnd.NextDouble() * 0.8 - 0.4);
            // Calculate new X, Y based on direction and velocity
            int iNewX = _pt.X + (int)(_vel * Math.Cos(_dir));
            int iNewY = _pt.Y - (int)(_vel * Math.Sin(_dir));
            // Bounce by adding 90 degrees to direction
            if (iNewX < 0 || iNewX >= _canvas.ScaledWidth)
            {
                _dir += Math.PI / 2;
                iNewX = _pt.X;
            }
            if (iNewY < 0 || iNewY >= _canvas.ScaledHeight)
            {
                _dir += Math.PI / 2;
                iNewY = _pt.Y;
            }
            _pt = new Point(iNewX, iNewY); // Save and return new Point
            return _pt;
        }
        protected abstract void VirtualPaint();
    }
    interface IAnimatable
    {
        void Animate(CDrawer canvas);
    }
    interface IMortal
    {
        bool Step();
    }
    class Snake : BaseShape, IMortal
    {
        private LinkedList<Point> points;
        private int length;
        private int lives;

        public Snake(Point point, int length, Color color) : base(point, color)
        {
            this.length = length; ;
            this.lives = length * 10;
            points = new LinkedList<Point>();
            points.AddFirst(point);
        }
        protected override Point VirtualMove()
        {
            Point newPoint = base.VirtualMove();
            points.AddFirst(newPoint);
            if (points.Count > length)
                points.RemoveLast();
            return newPoint;

        }
        protected override void VirtualPaint()
        {
            BaseShape._canvas.AddCenteredEllipse(points.First.Value, 3, 3, Color.Red);
            int alphaStep = 255 / points.Count; 
            int alpha = 255; 
            foreach (Point point in points) 
            { 
                Color color = Color.FromArgb(alpha, 255, 0, 0); 
                if (point != points.First.Value) 
                { 
                    _canvas.AddLine(points.First.Value.X, points.First.Value.Y, point.X, point.Y, _color,1);
                }
                alpha -= alphaStep; 
            }
        }
        public bool Step()
        {
            lives--;
            return lives > 0;
        }
    }
    class Blob : BaseShape, IAnimatable
    {
        int _rad;
        double _animation;
        Point _lastPoint;
        public Blob(int rad, Point point, Color color) : base(point, color)
        {
            this._rad = rad;
            this._lastPoint = point;
            this._animation = 0;
        }
        protected override Point VirtualMove()
        {
            Point newPoint = base.VirtualMove();
            _lastPoint = newPoint;

            return newPoint;
        }

        protected override void VirtualPaint()
        {
            double currentRadius = _rad + _rad * 0.5 * Math.Cos(_animation);
            _canvas.AddEllipse(_lastPoint.X - (int)currentRadius, _lastPoint.Y - (int)currentRadius, (int)(currentRadius * 2), (int)(currentRadius * 2), _color);
        }
        public void Animate(CDrawer drawer) 
        {
            _animation += Math.PI / 8; 
        }
    }
}
