using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using System.Resources;
using ICA12_AdrianBaira.Properties;
namespace ICA12_AdrianBaira
{
    public partial class Form1 : Form
    {
        private RectDrawer _rectcan = null; // Rectangle derived CDrawer
        private PosDrawer _poscan = null; // Positionable derived CDrawer
        private PicDrawer _piccan = null; // Grayscale Picture double derived CDrawer
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown1;
        }

        private void Form1_KeyDown1(object sender, KeyEventArgs e)
        {
            _poscan?.Close();
            _rectcan?.Close();
            _piccan?.Close();
            _poscan = null;
            _rectcan = null;
            _piccan = null;
            switch (e.KeyCode)
            {
                case Keys.E:
                    _poscan = new PosDrawer(400, 200, this, PosDrawer.EPosition.eRight);
                    break;
                case Keys.S:
                    _poscan = new PosDrawer(200, 400, this, PosDrawer.EPosition.eBelow);
                    break;
                case Keys.D:
                    _poscan = new PosDrawer(400, 400, this, PosDrawer.EPosition.eBelowRight);
                    break;
                case Keys.R:
                    _rectcan = new RectDrawer();
                    Activate(); // Steal focus back so keys continue to work
                    break;
                case Keys.P:
                    _piccan = new PicDrawer(this);
                    break;
            }
        }

    }

    class DrawerRandom : Random
    {
        int _max;
        public DrawerRandom(int max)
        {
            _max = max;
        }
        public Rectangle NextDrawerRect(CDrawer canvas)
        {
            int x = Next(_max, canvas.m_ciWidth - _max + 1);
            int y = Next(_max, canvas.m_ciHeight - _max + 1);
            int width = Next(10, _max);
            int height = Next(10, _max);
            return new Rectangle(x, y, width, height);
        }
    }

    class RectDrawer : CDrawer
    {
        DrawerRandom drawerRand = null;

        public RectDrawer() : base(400, 800)
        {
            int size = Math.Max(ScaledWidth, ScaledHeight) / 5;

            drawerRand = new DrawerRandom(size);
            BBColour = Color.White;

            int count = 0;
            while (count < 100)
            {
                count++;
                AddRectangle(drawerRand.NextDrawerRect(this), RandColor.GetKnownColor());
            }
        }
    }

    class PosDrawer : CDrawer
    {
        public enum EPosition { eRight, eBelow, eBelowRight, eNone };

        public void SetPosition(Form form, EPosition position)
        {

        }
        public void SetPosition(CDrawer canvas, EPosition pos)
        {

        }
        public PosDrawer(int width = 600, int height = 400, Form form = null, EPosition position = EPosition.eNone) : base(width, height)
        {
            ContinuousUpdate = false;
            BBColour = Color.LemonChiffon;
            if (form == null)
                return;
            form.Activate();
        }
    }


    class PicDrawer : PosDrawer
    {
        public PicDrawer(Form form = null) : base(Resources.tux2.Width, Resources.tux2.Height, form, EPosition.eNone)
        {
            if (form == null) return;

            Bitmap bitmap = new Bitmap(Resources.tux2);
            Bitmap grayBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    base.SetBBPixel(x, y, color);
                    int avg = (color.R + color.G + color.B) / 3;
                    Color grey = Color.FromArgb(avg, avg, avg);
                    grayBitmap.SetPixel(x, y, grey);
                }
            }
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = bitmap.Height / 2; y < bitmap.Height; y++)
                {
                    base.SetBBPixel(x,y, grayBitmap.GetPixel(x, y));
                }
            }
            Render();
        }
    }
}

