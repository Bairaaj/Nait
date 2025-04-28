using GDIDrawer;
using ICA_08AdrianB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA13
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        List<Ball> balls = new List<Ball>();
        CDrawer canvas = new CDrawer(800,600,false);
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 20;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            canvas.Clear();
            if(canvas.GetLastMouseLeftClick(out Point point))
            {
                switch(random.Next(0,3))
                {
                    case 0:
                        this.BackColor = Color.Blue;
                        balls.Add(new Ball(point, RandColor.GetColor()));
                        break;
                    case 1:
                        this.BackColor = Color.Red;
                        balls.Add(new SBall(point, RandColor.GetColor()));
                        break;
                    case 2:
                        this.BackColor = Color.Green;
                        balls.Add(new CBall(point, RandColor.GetColor()));
                        break;
                }
            }
            foreach(var ball in balls)
            {
                if (ball is CBall cBall)
                    cBall.Move(canvas);
                else if (ball is SBall sBall)
                    sBall.Move(canvas);
                else
                    ball.Move(canvas);

            }
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Show(canvas, i);
            }
            canvas.Render();


        }
    }
}
