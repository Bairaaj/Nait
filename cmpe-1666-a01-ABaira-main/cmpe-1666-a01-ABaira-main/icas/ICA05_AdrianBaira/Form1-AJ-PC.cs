using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA_05_AdrianB
{
    public partial class form1Structs : Form
    {
        //struct Like a Variable that can contain anything like string, int double
        struct SLine
        {
            public Point start;
            public Point end;
            public Color color;
            public Byte thickness;
            public SLine(Point Start, Point End, Color Color, Byte Thickness)
            {
                //setting variables to be able to be called in .x or .y in GDI
                start = Start;
                end = End;
                color = Color;
                thickness = Thickness;
                
            }
        }
        
        //This is a list that stores things in the stuct that can hold any varaiable i specify
        static private List<SLine> lines = new List<SLine>();
        Point startOfLine;
        Point endOfLine;
        //Strut or variable that im calling to save into
        SLine valueofline;
        //
        static private CDrawer canvas = new CDrawer(800, 800, true);
        //
        static private Random random = new Random();
        private enum eState { State_Idle, State_Armed };
        eState state;

        public form1Structs()
        {
            InitializeComponent();
        }

        private void UI_TimerTick_Tick(object sender, EventArgs e)
        {
            //setting new points every time it loops and only reset when condtions are met
            startOfLine = new Point();
            endOfLine = new Point();
            
            //Will do this until it gets a mouse LEFT click and save it as a point
            while (!canvas.GetLastMouseLeftClick(out startOfLine))
            {
            }
            //allow for it to change ENUM states and go to the next conditions
            if ((state == eState.State_Idle) && !startOfLine.IsEmpty)
            {
                state = eState.State_Armed;
            }
            //once condition is met will find the second point to draw
            if (state == eState.State_Armed)
            {
                //Will do this until it gets a mouse LEFT click and save it as a point
                while (!canvas.GetLastMouseLeftClick(out endOfLine))
                {

                }
                //If the end of the line is not empty then it will draw line
                if (!endOfLine.IsEmpty)
                {
                    //put back state into idle so it can loop again
                    state = eState.State_Idle;
                    //saves the values in a strut
                    valueofline = new SLine(startOfLine, endOfLine, Color.Red , 5);
                    //Adds values into a list
                    lines.Add(valueofline);
                    //draws the lines
                    Render();

                }
            }
        }
        static private void Render(SLine sLine)
        {
            //adds the lines on to the GDI from the strut
            canvas.AddLine(sLine.start.X, sLine.start.Y, sLine.end.X, sLine.end.Y, sLine.color, sLine.thickness);
        }
        static private void Render()
        {
            //will go though the list and in each stut value
            foreach(SLine sLine in lines)
            {
                //passes the values to the other render method
                Render(sLine);
            }
        }

        private void form1Structs_Load(object sender, EventArgs e)
        {

        }

        private void UI_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
