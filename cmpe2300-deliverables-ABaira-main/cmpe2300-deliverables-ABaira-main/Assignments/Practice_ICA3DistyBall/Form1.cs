using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace Practice_ICA3DistyBall
{
    public partial class Form1 : Form
    {
        private CDrawer canvas = new CDrawer(800, 600, false, true);
        private List<CDistyBall> balls = new List<CDistyBall>();
        int ballsize = 10;
        public Form1()
        {
            InitializeComponent();
            CDistyBall.SetDrawer(canvas);
            canvas.MouseLeftClick += Canvas_MouseLeftClick;
            this.MouseWheel += Form1_MouseWheel;
            CDistyBall._ballSize = ballsize;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta < 0)
            {
                ballsize--;
            }
            if(e.Delta > 0)
            {
                ballsize++;
            }
            if(ballsize <= 0)
            {
                ballsize = 1;
            }
            CDistyBall._ballSize = ballsize;
            Render();
        }

        private void Canvas_MouseLeftClick(Point pos, CDrawer dr)
        {
            balls.Add(new CDistyBall(pos));
            Render();
        }
        private void Render()
        {
            canvas?.Clear();
            float distance = 0;
            for(int i = 0; i < balls.Count; i++)
            {
                foreach(CDistyBall b in balls)
                {
                    distance = b.GetDistance(balls[i]);
                    Console.WriteLine(distance);
                    canvas?.AddLine((int)b._position.X, (int) b._position.Y, (int)balls[i]._position.X, (int)balls[i]._position.Y, Color.White , 2);
                    
                }
                canvas?.AddText($"{distance:F2}", 10, (int)((distance / 2) + balls[i]._position.X), (int)((distance / 2) + balls[i]._position.Y), 40, 20, Color.White);

            }


            foreach (CDistyBall b in balls)
            {
                b.Render();
            }
            canvas.Render();
        }
    }
}
