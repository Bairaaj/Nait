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
namespace ICA14
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Timer Timer = new Timer();
        CDrawer canvas = null;
        List<Light> lights = new List<Light>();
        public Form1()
        {
            InitializeComponent();
            canvas = new CDrawer();
            canvas.ContinuousUpdate = false;
            Timer.Interval = 25;
            Timer.Enabled = true;
            Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(canvas.GetLastMouseLeftClick(out Point point))
            {
                switch(random.Next(0,3))
                {
                    case 0:
                        lights.Add(new FadeLight(point, random.Next(30, 61)));
                        BackColor = Color.Red;
                        break;
                    case 1:
                        lights.Add(new SpinLight(point));
                        BackColor = Color.Green;
                        break;
                    case 2:
                        lights.Add(new ShrinkLight(point, random.Next(50,80)));
                        BackColor = Color.Blue;
                        break;
                }
                    
               
            }
            canvas.Clear();
            foreach (Light light in lights)
            {
                light.Animate();
                light.Draw(canvas);
            }
            lights.RemoveAll(x => x.bKillMe);
            canvas.Render();
        }
    }
}
