//****************************************************************************************************************************
//Program:          ICA 14 - Classes
//Description:      PolyLights
//Date:             Nov, 27, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA14_AdrianBaira
{
    internal class Light
    {
        #region Properties
        protected Point _lightCenter;                       //Position of Light
        public virtual bool _bKillMe { get; } = false;      //If light is visible or dead
        protected Color _color;                             //color of the light

        #endregion

        #region CTOR
        /// <summary>
        /// Default light
        /// setting the light center and color
        /// </summary>
        /// <param name="lightCenter">User cllick on GDI Canvas</param>
        public Light(Point lightCenter)
        {
            _lightCenter = lightCenter;
            _color = RandColor.GetColor();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Method to show animations on the GDIDrawer like spinning or shrinking base class doesnt animate anything
        /// </summary>
        public virtual void Animate(){}

        /// <summary>
        /// Draws the circle onto the drawer from the position user clicked on GDI Canvas
        /// </summary>
        /// <param name="canvas">GDI Drawer Canvas</param>
        public virtual void Draw(CDrawer canvas) 
        {
            canvas?.AddCenteredEllipse(_lightCenter.X, _lightCenter.Y, 8, 8, Color.Red);
        }
        #endregion
    }

    class FadeLight : Light
    {
        #region Properties
        protected int _opacity = 255;       //Opacity of the polygon
        protected double _rad;              //Radius of the polygon

        #endregion

        #region CTOR
        /// <summary>
        /// Making a Polygon centered at the point user clicked with a random radius
        /// </summary>
        /// <param name="center">Point where the User Clicked on GDI Drawer</param>
        /// <param name="rad">Radius of the Polygon</param>
        public FadeLight(Point center, double rad): base(center)
        {
            _rad = rad;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// If the Opacity is less than 50 then remove the light from the GDI Canvas
        /// </summary>
        public override bool _bKillMe => _opacity < 50;

        /// <summary>
        /// Slowly show the light fading away
        /// </summary>
        public override void Animate()
        {
            _opacity -= 4;
            if (_opacity <= 1)
                _opacity = 1;
        }

        /// <summary>
        /// Draws the polygon centered on the Red Point (base Class)
        /// </summary>
        /// <param name="canvas">GDI Canvas</param>
        public override void Draw(CDrawer canvas)
        {
            canvas.AddPolygon(base._lightCenter.X - (int)_rad, _lightCenter.Y - (int)_rad, (int)_rad,5, 0, Color.FromArgb(_opacity, _color));
            base.Draw(canvas);
        }
        #endregion
    }
    class SpinLight : Light
    {
        #region properties
        double _rotation = 2 * Math.PI; //rotation of the Polygon

        #endregion

        #region CTOR
        /// <summary>
        /// Making a SpinLight from user click on GDI
        /// </summary>
        /// <param name="point">User Clicked on GDI Canvas</param>
        public SpinLight(Point point) : base(point) { }

        #endregion

        #region Overrides
        /// <summary>
        /// if it has done a full rotation the delete itself
        /// </summary>
        public override bool _bKillMe => _rotation < 0.1;

        /// <summary>
        /// Spinning the polygon
        /// </summary>
        public override void Animate()
        {
            _rotation = _rotation * 0.95;
        }

        /// <summary>
        /// Draw the polygon onto the drawer centered on the Red light(Base class)
        /// </summary>
        /// <param name="canvas"></param>
        public override void Draw(CDrawer canvas)
        {
            canvas.AddPolygon(_lightCenter.X - 40, _lightCenter.Y - 40, 40, 3, _rotation, _color);
            base.Draw(canvas);
        }
        #endregion
    }
    class ShrinkLight : FadeLight
    {
        #region CTOR
        /// <summary>
        /// Shrink light CTOR
        /// </summary>
        /// <param name="point">User clicked on GDI Drawer</param>
        /// <param name="rad">Radius of the polygon</param>
        public ShrinkLight(Point point, double rad) :base(point, rad) { }

        #endregion

        #region Overrides
        /// <summary>
        /// if the radius is less than 10 or the base class _bkillme is true in FADELIGHT not light class
        /// </summary>
        public override bool _bKillMe => _rad < 10 || base._bKillMe == true;

        /// <summary>
        /// To slowly decrease the radius of the polygon
        /// </summary>
        public override void Animate()
        {
            _rad = _rad * 0.95;
        }
        #endregion
    }
}
