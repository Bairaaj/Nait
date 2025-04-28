//****************************************************************************************************************************
//Program:          ICA 08
//Description:      Collide-o-matic
//Date:             Oct, 15, 2024
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
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA_08AdrianB
{
    public partial class Form1 : Form
    {
        #region Members

        List<Ball> collided = new List<Ball>();         //list of balls that collided with eachother
        List<Ball> greenBalls = new List<Ball>();       //list of green balls
        List<Ball> redBalls = new List<Ball>();         //list of reballs
        CDrawer main = null;                            //main drawer user clicks on
        CDrawer secondary = null;                       //secondary drawer collided list balls shows

        #endregion

        #region CTOR
        /// <summary>
        /// Form CTOR set the secondary drawer and main drawer and set the position of the drawers to be side by side
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            main = new CDrawer(800, 600, false);
            secondary = new CDrawer(800, 600, false);
            main.Position = new Point(this.Location.X + this.Width + 10, this.Location.Y);
            secondary.Position = new Point(main.Position.X + main.m_ciWidth + 10, this.Location.Y);
            UI_Timer.Interval = 80;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Timer tick controls how fast the balls are moving and always checking if they overlap and if the ydo them ove them to the other drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_Timer_Tick(object sender, EventArgs e)
        {
            //if left click is pressed then add a red ball into the list
            if(main.GetLastMouseLeftClick(out Point left))
            {
                Ball redball = new Ball(left, Color.Red);
                if(redBalls.IndexOf(redball) == -1)
                    redBalls.Add(redball);
            }

            //if right clicked is pressed then add a green ball into the greenball list
            if (main.GetLastMouseRightClick(out Point right))
            {
                Ball greenball = new Ball(right, Color.Green);
                if(!greenBalls.Contains(greenball))
                    greenBalls.Insert(greenBalls.Count, greenball);
            }

            //move both red and green balls in the list onto the main drawer
            foreach (Ball item in redBalls)
                item.Move(main);

            foreach (Ball item in greenBalls)
                item.Move(main);

            //use lambda foreach to move balls onto the second drawer with the collided list
            collided.ForEach(ball => { ball.Move(secondary); });

            
            //temp list of collided balls
            List<Ball> temp = new List<Ball>();

            //save any ball that overlap with eachother that is a different color
            temp = greenBalls.Intersect(redBalls).ToList();

            //remove the balls that overlapped from the original list and change there color to yellow in the temp list

            
            foreach (Ball ball in temp)
            {
                ball._color = Color.Yellow;
                greenBalls.RemoveAll(b => b.Equals(ball));
                redBalls.RemoveAll(b => b.Equals(ball));
            }


            collided = new List<Ball>(collided.Union(temp).Distinct());//collided.Concat(temp).Distinct());

            //clear both drawers
            main.Clear();
            secondary.Clear();

            //text for how many balls are on the screen
            main.AddText($"Red: {redBalls.Count} Green: {greenBalls.Count}", 30, main.m_ciWidth / 2 - 200, main.m_ciHeight / 2, (main.m_ciWidth / 2), 40, Color.White);
            secondary.AddText($"{collided.Count}", 30, secondary.m_ciWidth / 2, secondary.m_ciHeight / 2, 40, 40, Color.White);

            //Show each ball on the screen using the i as the count 
            for (int i = 0; i < redBalls.Count; i++)
                redBalls[i].Show(main, i);

            for (int i = 0; i < greenBalls.Count; i++)
                greenBalls[i].Show(main, i);

            for (int i = 0; i < collided.Count; i++)
                collided[i].Show(secondary, i);
            

            //render the drawers
            main.Render();
            secondary.Render();

        }

        #endregion
    }
}
