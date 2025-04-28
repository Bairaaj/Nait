using GDIDrawer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA_05AdrianBairaPractice
{
    public partial class Form1 : Form
    {
        static CDrawer main = new CDrawer(Ball.width, Ball.height, false);
        static CDrawer secondary = new CDrawer(Ball.width, Ball.height, false);
        static Random random = new Random();
        List<Ball> mainlist = new List<Ball>();
        List<Ball> secondarylist = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
            main.Position = new Point(Location.X + this.Width + 10, Location.Y);
            secondary.Position = new Point(main.Position.X +  main.m_ciWidth + 10, main.Position.Y);
            main.MouseLeftClick += Main_MouseLeftClick;
            secondary.MouseLeftClick += Secondary_MouseLeftClick;
            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Ball b in mainlist)
            {
                b.Move();
            }
            
                List<Ball> list = new List<Ball>();
                for (int i = 0; i < mainlist.Count; i++)
                {
                    for (int j = i + 1; j < mainlist.Count; j++)
                    {
                        if (mainlist[i].Equals(mainlist[j]))
                        {
                            list.Add(mainlist[i]);
                            list.Add(mainlist[j]);
                        }
                    }
                }
                foreach(Ball b in list)
                {
                    if(mainlist.Contains(b))
                    {
                        mainlist.Remove(b);
                        secondarylist.Add(b);
                }
                    //mainlist.RemoveAll(x => x.Equals(b));
                   
                }

            main.Clear();
            foreach (Ball b in mainlist)
            {
                b.Render(main);
            }
            main.Render();

            foreach (Ball b in secondarylist)
            {
                b.Move();
                b.highlight = false;

            }

                for (int i = 0; i < secondarylist.Count; i++)
                {
                    for (int j = i + 1; j < secondarylist.Count; j++)
                    {
                        if (secondarylist[i].Equals(secondarylist[j]))
                        {
                            secondarylist[i].highlight = true;
                            secondarylist[j].highlight = true;
                        }
                    }
                }
            
            secondary.Clear();

            foreach(Ball b in secondarylist)
            {
                b.Render(secondary);
            }
            secondary.Render();





        }

        private void Secondary_MouseLeftClick(Point pos, CDrawer dr)
        {
            float velocityX = (float)random.NextDouble() * 10 - 5;
            float velocityY = (float)random.NextDouble() * 10 - 5;
            float ballRad = random.Next(20, 51);
            secondarylist.Add(new Ball(pos, new PointF(velocityX, velocityY), ballRad));
        }

        private void Main_MouseLeftClick(Point pos, CDrawer dr)
        {
            float velocityX = (float)random.NextDouble() * 10 - 5;
            float velocityY = (float)random.NextDouble() * 10 - 5;
            float ballRad = random.Next(20, 51);

            mainlist.Add(new Ball(pos, new PointF(velocityX, velocityY), ballRad));
        }
    }
}
