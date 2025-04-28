//****************************************************************************************************************************
//Program:          ICA 11
//Description:      Dictionary
//Date:             Oct, 30, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA11_AdrianBaira
{
    public partial class ICA10 : Form
    {
        #region Members

        Dictionary<Color, int> dictionary = new Dictionary<Color, int>();           //Dictionary of Color and Int 
        int sumofFrequency = 0;                                                     //Amount of Color in the picture given
        int avg = 0;                                                                //average value of frequency
        CDrawer canvas = null;                                                      //Canvas to draw on

        #endregion;

        #region CTOR
        /// <summary>
        /// Initalize Form 
        /// Subscribe
        /// -Button click event
        /// -Column Header Click event
        /// -Column formatting
        /// -Allow drag drop fuction for picture box
        /// 
        /// </summary>
        public ICA10()
        {
            InitializeComponent();
            UI_DataGridView.DataSource = UI_BindingSource;
            UI_BTN_AVG.Click += UI_BTN_AVG_Click;
            UI_DataGridView.ColumnHeaderMouseClick += UI_DataGridView_ColumnHeaderMouseClick;
            UI_DataGridView.CellFormatting += UI_DataGridView_CellFormatting;
            UI_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            UI_PictureBox.AllowDrop = true;
            canvas = new CDrawer();
            canvas.ContinuousUpdate = false;
        }
        #endregion

        #region  Methods
        /// <summary>
        /// Drag drop event for picture box
        /// </summary>
        private void UI_PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            FileInfo fileInfo = new FileInfo(file[0]);
            LoadFile(fileInfo);
            
        }
        /// <summary>
        /// Help with DragDop for mouse event allowing the file to be dropped within the picture box
        /// </summary
        private void UI_PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;

            else
                e.Effect = DragDropEffects.None;
        }
        /// <summary>
        /// changing the background of the cell depending on the average value
        /// </summary>
        /// <param name="e">Grabbing Column Index </param>
        private void UI_DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
                e.CellStyle.ForeColor = (Color)e.Value;
            
            if(e.ColumnIndex == 1)
            {
                if((int)e.Value < avg)
                    e.CellStyle.BackColor = Color.LightSalmon;

                else
                    e.CellStyle.BackColor = Color.LightGreen;
            }
        }

        
        /// <summary>
        /// If user presses the first column it will order the values by ARGB values
        /// IF user presses the second column it will sort by frequency then color
        /// </summary>
        /// <param name="e">Grabs Column header that use clicked</param>
        private void UI_DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex == 0)
                dictionary = dictionary.OrderBy(x => x.Key.ToArgb()).ToDictionary(x => x.Key, x => x.Value);

            if(e.ColumnIndex == 1)
            {
                //temp list to sort
                List<KeyValuePair<Color, int>> templist = dictionary.ToList();

                // Lamda expression of two tier sort
                templist.Sort((left, right) =>
                {
                    if(left.Value == right.Value)
                        return left.Key.ToArgb().CompareTo(right.Key.ToArgb());

                    else
                        return -left.Value.CompareTo(right.Value);

                });
                dictionary = templist.ToDictionary(x => x.Key, y => y.Value);
            }
            ShowDictionary();

        }

        /// <summary>
        /// Gets the average value of all the colors and shows them in the coloumn
        /// </summary>
        private void UI_BTN_AVG_Click(object sender, EventArgs e)
        {
            if (dictionary.Count <= 0)
                return;

            dictionary = dictionary.Where(x => x.Value <= avg).ToDictionary(x => x.Key, y => y.Value );
            ShowDictionary();
        }
        /// <summary>
        /// Shows the Dictionary and puts it into the columns and gets the average value and put it into the button on form
        /// </summary>
        public void ShowDictionary()
        {
            
            UI_BindingSource.DataSource = dictionary.ToList();
            UI_DataGridView.Columns[0].HeaderText = $"Color";
            UI_DataGridView.Columns[1].HeaderText = $"Frequency";

            //gets the average values of the dictionary
            avg = (int)dictionary.Values.Average();
            UI_BTN_AVG.Text = $"Average : {avg}";
            
            //gets the total sum of the values in the dictionary
            foreach(int values in dictionary.Values)
                sumofFrequency += values;
            
            if(dictionary.Count > 1)
               ShowLL();
            
            

        }
        /// <summary>
        /// Loads the file onto a bitmap to draw colors onto the canvas 
        /// </summary>
        /// <param name="file">File info that user gives with drag drop</param>
        public void LoadFile(FileInfo file)
        {
            Bitmap bitmap = (Bitmap)Bitmap.FromFile(file.FullName);
            UI_PictureBox.Image = bitmap;
            dictionary.Clear();
            //iterate though the bitmap and grab each pixel and make the color a key and add it to its frequency in the dictionary
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    if (!dictionary.ContainsKey(pixel))
                        dictionary.Add(pixel, 1);

                    else
                        dictionary[pixel]++;
                }
            }

            ShowDictionary();
        }
        /// <summary>
        /// SHow the colors of the dictionary and add them to a linked list sorting them and displaying them into the drawer
        /// </summary>
        public void ShowLL()
        {
            //make a list of colors to hold all the pixels
            LinkedList<Color> colors = new LinkedList<Color>();
            
            //Look foreach key int the dictonary the KEY IS THE COLOR
            foreach (KeyValuePair<Color, int> key in dictionary.ToList())
            {
                // if the first position in the list is null then we start there
                if(colors.Count <= 0)
                    colors.AddFirst(key.Key);
                
                else
                {
                    //grabs the first node
                    LinkedListNode<Color> node = colors.First;

                    //iterate though the list until it hits a null
                    while (node != null)
                    {
                        //grabe the rbg value from the list and compare it to the loop value
                        if(node.Value.ToArgb().CompareTo(key.Key.ToArgb()) < 0)
                        {
                            //add the color to the list
                            colors.AddBefore(node, key.Key);
                            break;
                        }
                        
                        //iterate though the next node
                        node = node.Next;
                    }
                    // if the node becomes null then we are at the end of the list
                    if(node == null)
                        colors.AddLast(key.Key);
                    
                }
            }
            
            //clear canvas and reset
            canvas.Clear();
            canvas.Scale = 1;

            //update the scale of the canvas for everytime until the scaled width / height fit in the drawer
            while(canvas.ScaledHeight * canvas.ScaledWidth > colors.Count)
                ++canvas.Scale;
    
            --canvas.Scale;
            //x and y position to draw
            int x = 0;
            int y = 0;
            
            for (LinkedListNode<Color> col = colors.First; col != null; col = col.Next)
            {
                if (x > canvas.ScaledWidth - 1) 
                { 
                    x = 0; 
                    y += 1;
                    canvas.AddRectangle(x, y, 1, 1, col.Value);
                }
                else
                {
                    canvas.AddRectangle(x, y, 1, 1, col.Value);
                    x += 1;
                }
                

            }
            canvas.Render();
        }
        #endregion

    }
}
