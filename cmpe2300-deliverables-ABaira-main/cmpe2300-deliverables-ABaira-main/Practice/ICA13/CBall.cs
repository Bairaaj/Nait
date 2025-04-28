using GDIDrawer;
using ICA_08AdrianB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA13
{
    internal class CBall : Ball
    {
        int ShowCount = 0;
        public CBall(Point point, Color color): base(point, color) { }
        
        public new void Show(CDrawer canvas, int number)
        {
            base._rad = base._rad + 3;
            base._color = Color.Black;
            base.Show(canvas, number);
            ShowCount++;
        }
        public new void Move(CDrawer canvas)
        {
            if (ShowCount % 50 == 0)
            {
                base._color = RandColor.GetColor();
            }
            base.Move(canvas);
        }

    }
    class SBall : Ball
    {
        int showcount = 0;
        public SBall(Point point, Color color) : base(point, color) { }

        public new void Show(CDrawer canvas, int number)
        {
            base.Show(canvas, number);
            showcount++;
        }
        public new void Move(CDrawer canvas)
        {
            if (showcount % 50 == 0 && base._rad < 200)
            {
                base._rad += 5;
            }
            base.Move(canvas);
        }
    }
}
