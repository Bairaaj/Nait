//****************************************************************************************************************************
//Program:          ICA 14
//Description:      PolyLights
//Date:             Nov, 27, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using GDIDrawer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA14_AdrianBaira
{
    public partial class Form1 : Form
    {
        #region Members

        Random rng = new Random();                  //Random numbers for radius
        Timer timer = new Timer();                  //timer tick for drawing and animation for canvas
        CDrawer canvas = null;                      //GDI Drawer 
        List<Light> lights = new List<Light>();     //list of lights to be displayed
        #endregion

        #region CTOR
        /// <summary>
        /// Set canvas and timer interval and use timer Tick Event
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            canvas = new CDrawer();
            canvas.ContinuousUpdate = false;
            timer.Interval = 25;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Timer Tick event every 25 ms
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Gets user last left click on canvas and draws it on canvas 
            if(canvas.GetLastMouseLeftClick(out Point point))
                AddLights(point);
            
            //if user right clicks it will show one light on user licked and then randomly generate lights within the drawer
            if(canvas.GetLastMouseRightClick(out Point rightPoint))
            {
                for(int i = 0; i < 20; i++)
                {
                    if(i == 0)
                        AddLights(rightPoint);
                    else
                    {
                        Point rand = new Point(rng.Next(canvas.m_ciWidth - 1), rng.Next(canvas.m_ciHeight - 1));
                        AddLights(rand);
                    }
                        
                }
            }
            //showing the animation to see the changes in each light
            canvas.Clear();
            foreach (var light in lights)
            {
                light.Animate();
                light.Draw(canvas);
            }
            //removes all the lights that arent showing anymore from the list
            lights.RemoveAll(x => x._bKillMe == true);
            canvas.Render();
        }
        /// <summary>
        /// Adding lights into the drawer randomly picked with number random number
        /// </summary>
        /// <param name="point">Position where the light is drawn</param>
        private void AddLights(Point point)
        {
            switch (rng.Next(3))
            {
                //Fade light 
                case 0:
                    lights.Add(new FadeLight(point, rng.Next(30, 61)));
                    BackColor = Color.Red;
                    break;
                //Spinning light
                case 1:
                    lights.Add(new SpinLight(point));
                    BackColor = Color.Green;
                    break;
                //Shrinking Light, with random radius
                case 2:
                    lights.Add(new ShrinkLight(point, rng.Next(50, 81)));
                    BackColor = Color.Blue;
                    break;
            }
        }
        #endregion
    }
}
