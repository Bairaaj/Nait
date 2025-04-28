//****************************************************************************************************************************
//Program:          Lab 02
//Description:      Pool
//Date:             Nov, 07, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
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
using System.Numerics;
namespace Lab_02AdrianB
{
    public partial class Form1 : Form
    {
        #region Members
        Table table = null;                 //table
        Timer timer = new Timer();          //timer for the game
        bool running = true;                //if the application is running
        int numberofBalls = 5;              //number of balls to make
        List<Ball> list = null;             //List of balls
        bool flag = false;                  //flag to open and close the drawers
        public static bool totalcolFlag { get; set; } = true;          //flag to only do when game is not running
        int totalCol = 0;
        #endregion

        #region CTOR
        /// <summary>
        /// To set all elements of the game
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            UI_TXTBOX_Friction.Text = $"{Ball._friction:F3}";
            UI_BTN_NewTable.MouseWheel += UI_BTN_NewTable_MouseWheel;
            UI_BTN_NewTable.Click += UI_BTN_NewTable_Click;
            UI_LBL_Friction.MouseWheel += UI_LBL_Friction_MouseWheel;
            UI_TXTBOX_Friction.MouseWheel += UI_LBL_Friction_MouseWheel;
            UI_RAD_Radius.Checked = true;
            timer.Interval = 35;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            UI_DataGridView.DataSource = null;
            UI_BTN_NewTable.Text = $"New Table [{numberofBalls}]";
            UI_LBL_TotalCol.Text = $"Total Collisions: {totalCol}";
        }
        #endregion

        #region Methods
        /// <summary>
        /// to rende
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (table == null)
                return;
            //clear the table to make it look like theres one shape
            table._canvas.Clear();
            //to move the balls 
            table.ShowTable();
           
            if(running && !table.Running)         
                UpdateGridView();
            
        }
        /// <summary>
        /// Update the grid vew to show how many balls have been hit during the turn and the total ammount that it was hit
        /// </summary>
        private void UpdateGridView()
        {
            //copy of the ball list
            list = table.newCopy;
            //sorting by radius
            if (UI_RAD_Radius.Checked)
                list.Sort();

            //sorting by hits descending
            if (UI_RAD_Hits.Checked)
                list.Sort(Ball.SortHitsDecending);

            //sorting by total hits decending
            if (UI_RAD_TotalHits.Checked)
                list.Sort(Ball.SortTotalHitsDecending);

            if (totalcolFlag)
            {
                totalcolFlag = false;
                list.ForEach(item => { 
                    if(item.BallColor != Color.White)
                        totalCol += item.Hits; 
                });
            }
            


            UI_LBL_TotalCol.Text = $"Total Colisions {totalCol}";
            //reset the data view and update it to the Dataview with new sorted values
            UI_DataGridView.DataSource = null;
            UI_DataGridView.DataSource = list;
            UI_DataGridView.RowHeadersVisible = false;
            UI_DataGridView.Columns["BallColor"].Visible = false;
            UI_DataGridView.Columns["Center"].Visible = false;
            UI_DataGridView.Columns["Velocity"].Visible = false;
            


        }

        /// <summary>
        /// Friction of the table 
        /// </summary>
        /// <param name="e">Delta value of mouse</param>
        private void UI_LBL_Friction_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (Ball._friction <= 0.0)
                    Ball._friction = 0.001f;

                else
                    Ball._friction -= 0.001f;
            }
            if (e.Delta > 0)
                Ball._friction += 0.001f;

            UI_TXTBOX_Friction.Text = $"{Ball._friction:F3}";
        }

        /// <summary>
        /// To change the ammount of balls that would be displayed
        /// </summary>
        /// <param name="e"></param>
        private void UI_BTN_NewTable_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                numberofBalls++;

            if (e.Delta < 0)
                numberofBalls--;

            if (numberofBalls <= 0)
                numberofBalls = 1;

            UI_BTN_NewTable.Text = $"New Table : [{numberofBalls}]";

        }

        
        /// <summary>
        /// New table for a new game it will lcose the drawer and make a new list of balls and draw them on the canvas
        /// </summary>
        private void UI_BTN_NewTable_Click(object sender, EventArgs e)
        {
            //Close the drawer if one is open
            if (!flag)
                flag = true;

            else
                table._canvas.Close();

            totalCol = 0;
            table = new Table();
            table.MakeTable(800, 600, numberofBalls);
            table._canvas.BBColour = Color.DarkOliveGreen;


        }
        #endregion
    }
}
