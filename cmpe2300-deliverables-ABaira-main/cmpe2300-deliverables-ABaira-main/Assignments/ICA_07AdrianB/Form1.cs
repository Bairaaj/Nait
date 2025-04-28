//****************************************************************************************************************************
//Program:          ICA 07 PrediBlocks
//Description:      Maze solver
//Date:             Oct, 8, 2024
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICA_07AdrianB
{
    public partial class ICA07 : Form
    {
        #region Members

        List<Block> blocks = new List<Block>();         //list of blocks
        CDrawer canvas = null;                          //canvas to draw on
        int removed = 0;                                //how many blocks removed from the list

        #endregion

        #region CTOR

        /// <summary>
        /// Form CTOR 
        /// Adding canvas
        /// subscriing to the mousemove event for the canvas
        /// </summary>
        public ICA07()
        {
            InitializeComponent();
            canvas = Block._canvas;
            UI_BTN_Longerthan.Text = $"Longer than {UI_TrackBar.Value * 10}";
            canvas.MouseMove += Canvas_MouseMove;
            this.MouseMove += ICA07_MouseMove;
        }

        /// <summary>
        /// when user puts mouse on the form it will highlight the block with the x pos 
        /// </summary>
        private void ICA07_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = new Point(e.Location.X, e.Location.Y);
            blocks.ForEach((block) => { block._highLight = false; });

            blocks.FindAll((x) => pos.X + 10 > x._width && pos.X - 10 < x._width).ForEach((block) => { block._highLight = true; });

            ShowBlock();
  
        }

        #endregion

        #region Methods

        /// <summary>
        /// when user puts mouse on the drawer it will highlight the block with the x pos 
        /// </summary>
        private void Canvas_MouseMove(Point pos, CDrawer dr)
        {
            blocks.ForEach((block)=> { block._highLight = false; });

            blocks.FindAll((x) => pos.X + 10 > x._width && pos.X - 10 < x._width).ForEach((block) => { block._highLight = true; });

            ShowBlock();
        }

        /// <summary>
        /// shows the block onto the drawer with a padding of 10 pixels
        /// </summary>
        public void ShowBlock()
        {
            canvas?.Clear();

            //cordinates to place the blocks
            int x = 0;
            int y = 0;

            foreach(Block b in blocks)
            {
                //condition to make the block not be to thhe edge and have a padding of 10 pixels
                if (x + b._width >= canvas.m_ciWidth - 10)
                {
                    y += Block._height;                 //moving down on the drawer
                    x = 0;                              //reset back to the left side   
                }
                else
                {
                    b.ShowBlock(new Point(x, y));       //drawing on the canvas with the new points
                    x += b._width;                      //width of each block foor x postion
                }
            }
            canvas?.Render();                           //render the drawer
        }

        /// <summary>
        /// Populate the canvas with 85% filled
        /// </summary>
        private void UI_BTN_Populate_Click(object sender, EventArgs e)
        {
            blocks.Clear();             
            double area = canvas.ScaledWidth * canvas.ScaledHeight / Block._height;  //area needed to be filled
            int runningsum = 0;                                                     //the sum of the area filled
            while (runningsum < area * 0.85)                                        //condition to leave once 85% of the drawer is filled
            {
                //new block
                Block block = new Block();
                //check if block is already in the list dont add
                if(!blocks.Contains(block))
                {
                    blocks.Add(block);
                    runningsum += block._width;
                }
            }
            TrackBar();
            ShowBlock();

        }

        /// <summary>
        /// sort the list by color
        /// </summary>
        private void UI_BTN_Color_Click(object sender, EventArgs e)
        {
            blocks.Sort();
            TrackBar();
            ShowBlock();
        }

        /// <summary>
        /// sort the list by width using a lambda expression ascending
        /// </summary>
        private void UI_BTN_Width_Click(object sender, EventArgs e)
        {
            blocks.Sort((a, b) => { return a._width.CompareTo(b._width); });
            TrackBar();
            ShowBlock();
        }

        /// <summary>
        /// sort the list by width using a lambda expression descending 
        /// </summary>
        private void UI_BTN_WidthDesc_Click(object sender, EventArgs e)
        {
            blocks.Sort((a, b) => { return -a._width.CompareTo(b._width); });
            TrackBar();
            ShowBlock();
        }

        /// <summary>
        /// sorting with a compliant function in block class for Width and Color
        /// </summary>
        private void UI_BTN_WidthColor_Click(object sender, EventArgs e)
        {
            blocks.Sort(Block.ColorWidthSort);
            TrackBar();
            ShowBlock();
        }

        /// <summary>
        /// sorting with a compliant function in block class for the birghtness of the block
        /// </summary>
        private void UI_BTN_Bright_Click(object sender, EventArgs e)
        {
            removed = blocks.RemoveAll(Block.Brightness);
            this.Text = $"Removed {removed} blocks!";
            TrackBar();
            ShowBlock();
        }

        /// <summary>
        /// removes any block that is longer than the Trackbar value
        /// </summary>
        private void UI_BTN_Longerthan_Click(object sender, EventArgs e)
        {
            removed = 0;
            removed = blocks.RemoveAll((block) =>
            {
                if (block._width > UI_TrackBar.Value)
                    return true;
                return false;
            });
            this.Text = $"Removed {removed} blocks!";
            TrackBar();
            ShowBlock();
        }

        /// <summary>
        /// update the UI for the track bar value
        /// </summary>
        private void UI_TrackBar_Scroll(object sender, EventArgs e)
        {
            UI_BTN_Longerthan.Text = $"Longer than {UI_TrackBar.Value}";  
        }

        /// <summary>
        /// method to keep the trackbar value to be the middle of the trackbar and set new min and max values for items that have been removed
        /// </summary>
        private void TrackBar()
        {
            int min = blocks.Min(block => block._width);   //min value in the list
            int max = blocks.Max(block => block._width);   //max width value in the list
            UI_TrackBar.Minimum = min;
            UI_TrackBar.Maximum = max;
            UI_TrackBar.Value = (min + max) / 2;
            UI_BTN_Longerthan.Text = $"Longer than {UI_TrackBar.Value}";
        }

        #endregion
    }
}
