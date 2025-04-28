//****************************************************************************************************************************
//Program:          ICA 05 Blockz
//Description:      Using Icompareable sorting blocks depending on the color, radius and distance
//Date:             Sept, 26, 2024
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
using System.Threading;
namespace ICA05_AdrianBaira
{
    public partial class UI_FORM : Form
    {
        #region Members

        public List<Block> Blocks = new List<Block>();              //list of blocks
        public int addBlocks;                                       //blocks that are added to list
        public int discardedBlocks;                                 //block that are discarded that overlap
        public int blockSize;                                       //size of block

        #endregion

        #region CTOR
        /// <summary>
        /// Initalize Form
        /// Subscribe to mousewheel event on form
        /// initalizing block size
        /// </summary>
        public UI_FORM()
        {
            InitializeComponent();
            this.MouseWheel += UI_FORM_MouseWheel;
            blockSize = 20;
            UI_BTN_AddBlocks.Text = $"Add Blocks ({blockSize})";
        }
        #endregion

        #region Methods
        /// <summary>
        /// If user scrolls on form it will change block size
        /// </summary>
        private void UI_FORM_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
                blockSize--;

            if (e.Delta > 0)
                blockSize++;

            if (blockSize == 0)
                blockSize = 1;

            UI_BTN_AddBlocks.Text = $"Add Blocks ({blockSize})";
        }

        /// <summary>
        /// adding blocks onto the drawer
        /// </summary>
        private void UI_BTN_AddBlocks_Click(object sender, EventArgs e)
        {
            addBlocks = 0;
            discardedBlocks = 0;
            Block.Loading = true;
            while (addBlocks < 25 && discardedBlocks < 1000)
            {
                Block block = new Block(blockSize);
                if(!(Blocks.Contains(block)))
                {
                    addBlocks++;
                    Blocks.Add(block);
                    if(addBlocks > 25)
                        break;

                }
                else
                    discardedBlocks++;

            }

            this.Text = $"Loaded {addBlocks} distinct blocks with {discardedBlocks} discards";
            foreach(Block block in Blocks)
                block.ShowBlock();


            Block.Loading = false;
        }

        /// <summary>
        /// To clear half of the list and display what was removed
        /// </summary>
        private void UI_FORM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Block.Loading = true;
                Blocks.RemoveRange(Blocks.Count / 2, Blocks.Count / 2);
                foreach (Block block in Blocks)
                    block.ShowBlock();


                Block.Loading = false;
            }
        }

        /// <summary>
        /// Sorting Methods
        /// -Block Size
        /// -Block Distance from (0,0)
        /// -Block Color
        /// -Block Size and Color
        /// </summary>
        private void UI_RAD_Size_MouseClick(object sender, MouseEventArgs e)
        {
            if (UI_RAD_Size.Checked)
                Block.sorts = Block.ESortType.eSize;

            else if (UI_RAD_Distance.Checked)
                Block.sorts = Block.ESortType.eDistance;

            else if (UI_RAD_Color.Checked)
                Block.sorts = Block.ESortType.eColor;

            else if(UI_RAD_ColSize.Checked)
                Block.sorts = Block.ESortType.eColorSize;

            Blocks.Sort();                 
            Block.Loading = true;
            foreach (Block block in Blocks)
            {
                block.ShowBlock();
                Thread.Sleep(25);
                Block.Loading = false;
            }

        }
        #endregion
    }
}
