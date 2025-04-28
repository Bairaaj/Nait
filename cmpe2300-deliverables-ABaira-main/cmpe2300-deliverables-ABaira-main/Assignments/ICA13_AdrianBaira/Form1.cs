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


namespace ICA13_AdrianBaira
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        List<Ball> balls = new List<Ball>();
        CDrawer canvas = new CDrawer(800,600, false);
        
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 20;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            canvas?.Clear();
            Random rng = new Random();
            if(canvas.GetLastMouseLeftClick(out Point point))
            {
               
                switch(rng.Next(0,3))
                {
                    case 0:
                        balls.Add(new Ball(point, RandColor.GetColor()));
                        BackColor = Color.Blue;
                        break;
                    case 1:
                        balls.Add(new CBall(point, RandColor.GetColor()));
                        BackColor = Color.HotPink;
                        break;
                    case 2:
                        balls.Add(new SBall(point, RandColor.GetColor()));
                        BackColor = Color.Green;
                        break;
                }
            }
            foreach(var ball1 in balls)
            {
                if (ball1 is CBall cBall)
                    cBall.Move(canvas);
                else if (ball1 is SBall sBall)
                    sBall.Move(canvas);
                else
                    ball1.Move(canvas);
               
            }
            for(int i = 0; i < balls.Count; i++)
            {
                if (balls[i] is CBall cBall)
                    cBall.Show(canvas, i);
                else if (balls[i] is CBall sBall)
                    sBall.Show(canvas, i);
                else
                    balls[i].Show(canvas, i);
            }
            canvas.Render();
        }
    }
}
