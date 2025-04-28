using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ICA14
{
    internal class Light
    {
        protected Point _center;
        public virtual bool bKillMe { get; } = false;

        protected Color _color;

        public Light(Point center)
        {
            _center = center;
            _color = RandColor.GetColor();

        }
        public virtual void Animate() { }
        public virtual void Draw(CDrawer canvas)
        {
            canvas.AddCenteredEllipse(_center, 4, 4, Color.Red);
        }
    }
    class FadeLight : Light
    {
        protected int _opacity = 255;
        protected double _radius;
        public FadeLight(Point center, double radius) : base(center)
        {
            _radius = radius;
        }
        public override bool bKillMe => _opacity < 50;
        public override void Animate()
        {
            _opacity -= 4;
            if (_opacity <= 1)
                _opacity = 1;
        }
        public override void Draw(CDrawer canvas)
        {
            canvas.AddPolygon(base._center.X - (int)_radius, base._center.Y - (int)_radius, (int)_radius, 5, 0, Color.FromArgb(_opacity, _color));
            base.Draw(canvas);
        }

    }
    class SpinLight : Light
    {
        double rotation = 2 * Math.PI;
        public SpinLight(Point center) : base(center) { }

        public override bool bKillMe => rotation < 0.1;
        public override void Animate()
        {
            rotation = rotation * 0.95;
        }
        public override void Draw(CDrawer canvas)
        {
            canvas.AddPolygon(base._center.X - 40, base._center.Y - 40, 40, 3, rotation, _color);
            base.Draw(canvas);
        }
    }
    class ShrinkLight : FadeLight
    {
        public ShrinkLight(Point center, double radius) : base(center, radius) { }
        public override bool bKillMe => _radius < 10 || base.bKillMe == true;
        public override void Animate()
        {
            _radius = _radius * 0.95;
            base.Animate();
        }

    }
}
