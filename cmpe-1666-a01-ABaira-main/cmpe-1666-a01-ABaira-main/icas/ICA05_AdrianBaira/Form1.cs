//****************************************************************************
//Program: ICA05 Adrian
//Description: GDI Line Drawer
//Date: Oct, 3, 2023
//Author: Adrian Baira
//Course: CMPE1666
//Class: CNTA01
//****************************************************************************
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
      
        //Strut or variable that im calling to save into
        SLine valueofline;
        //global variablefor canvas
        static private CDrawer canvas = new CDrawer(800, 800, true);
        //global variable for random number to be used in any method
        static private Random random = new Random();
        //State of the point
        private enum eState { State_Idle, State_Armed };
        eState state = eState.State_Idle;

        public form1Structs()
        {
            InitializeComponent();
        }
        //**********************************************************************************************
        //Method:           private void UI_TimerTick_Tick(object sender, EventArgs e)
        //Peramaters:       to check the new points
        //                  change states for left click 
        //Purpose:          to event hander
        //Returns:          GDI drawer
        //**********************************************************************************************
        private void UI_TimerTick_Tick(object sender, EventArgs e)
        {
            //setting new points every time it loops and only reset when condtions are met
            Point startOfLine = new Point();
            Point endOfLine = new Point();

            //Will do this until it gets a mouse LEFT click and save it as a point
            
            while (!canvas.GetLastMouseLeftClick(out startOfLine))
            {
                RightClick();
            }
            
            //allow for it to change ENUM states and go to the next conditions
            if ((state == eState.State_Idle) && !startOfLine.IsEmpty)
            {
                state = eState.State_Armed;
                UI_LabelBox.Text = state.ToString();
            }
            UI_LabelBox.Text = state.ToString();
            //once condition is met will find the second point to draw
            if (state == eState.State_Armed)
            {
                
                //Will do this until it gets a mouse LEFT click and save it as a point
                while (!canvas.GetLastMouseLeftClick(out endOfLine))
                {
                    RightClick();
                    
                    
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
                    UI_LabelBox.Text = "State_idle";
                }
            }
        }
        //**********************************************************************************************
        //Method:           private void Render(SLine sLine)
        //Peramaters:       - Add lines onto gdi drawer
        //Purpose:          - to set poitns for gdi drawer to draw the line
        //Returns:          Gdi canvas to draw
        //**********************************************************************************************
        static private void Render(SLine sLine)
        {
            //adds the lines on to the GDI from the strut
            canvas.AddLine(sLine.start.X, sLine.start.Y, sLine.end.X, sLine.end.Y, sLine.color, sLine.thickness);
            
        }
        //**********************************************************************************************
        //Method:           private void Render()
        //Peramaters:       to clear the GDI
        //                  - Will look into every line in list and
        //Purpose:          to draw lines
        //Returns:          Sline with all lines in it
        //**********************************************************************************************
        static private void Render()
        {
            canvas.Clear();
            //will go though the list and in each stut value
            foreach (SLine sLine in lines)
            {
                //passes the values to the other render method
                Render(sLine);
            }
        }
        //**********************************************************************************************
        //Method:           static private void RightClick()
        //Peramaters:       point to change the value of color and thickness to be drawn
        //Purpose:          event handler will check if user pressed right click
        //Returns:          to display in GDI
        //**********************************************************************************************
        static private void RightClick()
        {
            Point rightclick;
            if (canvas.GetLastMouseRightClick(out rightclick))
            {
                PressedRightclick(lines, canvas);
            }
        }
        //**********************************************************************************************
        //Method:           static private void PressedRightClick(List<SLine> LeftclickLines, CDrawer canvas)
        //Peramaters:       to call the list and GDI                 
        //Purpose:          to replace the lines in the list
        //Returns:          Returns new color and line values
        //**********************************************************************************************
        static private void PressedRightclick(List<SLine> LeftclickLines, CDrawer canvas)
        {
            List<SLine> rightClickLines = new List<SLine>();
            foreach (SLine line in LeftclickLines)
            {
                Color newRandomcolour = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                Byte newRandomthickness = (byte)random.Next(1, 20);
                SLine newLine = new SLine(line.start, line.end, newRandomcolour, newRandomthickness);
                rightClickLines.Add(newLine);
            }
            lines = rightClickLines;
            Render();
        }

        private void UI_LabelBox_Click(object sender, EventArgs e)
        {

        }
    }
}
