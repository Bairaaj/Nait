//****************************************************************************************************************************
//Program:          ICA01_AdrianB
//Description:      TrekLights
//Date:             Sept, 12, 2024
//Author:           Adrian Baira
//Course:           CMPE2300
//Class:            CNTA02
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA_0AdrianB
{
    public partial class Form1 : Form
    {
        #region Members
        TrekLight[] _trekLights = null;     // 1D array of the Treklights
        CDrawer _canvas = null;             // GDIdrawer 
        Timer _timer = new Timer();         // Timer for showing treklight every 80 ms
        Random _rng = new Random();         // Random number for on value
        #endregion

        #region CTOR
        /// <summary>
        /// Form constructor setting the timer interval
        /// subscribing to all the events of the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            _timer.Interval = 80;


            Shown += Form1_Shown;           // Subscribing to the Form shown event
            _timer.Tick += _timer_Tick;     // Timer Tick event method
            KeyDown += Form1_KeyDown;       // KeyDown Medthod when a key is pressed
        }
        #endregion

        #region Methods

        /// <summary>
        /// Key Down Events
        /// Numpad 0 - Fills first half of array with lights and second half with randomly placed
        /// Numpad 1 - Fills all null / empty spots with default treklights
        /// Add - Finds the last spot null spot and fills it with a new treklight
        /// Subtract - Finds the last treklight that is NOT NULL and makes it NULL
        /// Multiply - Finds a random spot and if its NOT NULL then Replace it with a new TrekLight
        /// Enter - Makes all TrekLights be on
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Numpad 0 - Fills first half of array with lights and second half with randomly placed
            if (e.KeyCode == Keys.NumPad0)
            {
                //for the first half of the drawer
                for(int i = 0; i < _trekLights.Length / 2; i++)
                {
                    _trekLights[i] = new TrekLight();
                }
                //for the second half of the drawer 
                for (int i = (_trekLights.Length / 2); i < _trekLights.Length; i++)
                {
                    _trekLights[i] = new TrekLight(RandColor.GetColor(), (byte)_rng.Next(50, 201), 4);     
                }
            }
            // Numpad 1 - Fills all null / empty spots with default treklights
            if (e.KeyCode == Keys.NumPad1)
            {
                //Fill the array with a new default treklight
                for (int i = 0; i < _trekLights.Length; i++)
                {
                    if (_trekLights[i] == null)
                    {
                        _trekLights[i] = new TrekLight();
                    }
                }
            }
            // Add - Finds the last spot null spot and fills it with a new treklight
            if (e.KeyCode == Keys.Add)
            {
                // it will find the last null spot int the array and will fill it with a new treklight
                for(int i = _trekLights.Length -1; i >= 0; i--)
                {
                    if (_trekLights[i] == null)
                    {
                        _trekLights[i] = new TrekLight();
                        break;  //Once found stop searching and leave the loop
                    }
                }
            }
            // Subtract - Finds the last treklight that is NOT NULL and makes it NULL
            if (e.KeyCode == Keys.Subtract)
            {
                for (int i = _trekLights.Length -1 ; i >= 0; i--)
                {
                    /// goest theough the array backwards and finds a treklight and if it does make it null
                    if(_trekLights[i] != null)
                    {
                        _trekLights[i] = null;
                        break; //Once found stop searching and leave the loop
                    }
                }
            }
            // Multiply - Finds a random spot and if its NOT NULL then Replace it with a new TrekLight
            if (e.KeyCode == Keys.Multiply)
            {
                bool check = true;
                do
                {
                    // random position within the array
                    int rngnum = _rng.Next(0, _trekLights.Length);
                    if (_trekLights[rngnum] != null)
                    {
                        _trekLights[rngnum] = new TrekLight();
                        check = false; // leave condition once found a non null spot
                    }
                } while (check);
            }
            // Enter - Makes all TrekLights be on
            if (e.KeyCode == Keys.Enter)
            {
                foreach(TrekLight light in _trekLights)
                {
                    light?.RedAlert(); // turns all the treklights 
                    
                  
                }
            }
        }

        /// <summary>
        /// Initalization of the drawer, array, and timer
        /// </summary
        private void Form1_Shown(object sender, EventArgs e)
        {
            _canvas = new CDrawer(800, 500, false);
            _canvas.Scale = 50;
            _trekLights = new TrekLight[_canvas.ScaledHeight * _canvas.ScaledWidth];
            _canvas.Position = new Point(Location.X, Location.Y); //Moves the canvas position to the location of the form
            Activate(); //takes focus of the windows form
            _timer.Start();
        }

        /// <summary>
        /// Every 80 ms it will clear the drawer and iterate though the array and adding the tick value and rendering the light
        /// </summary>
        private void _timer_Tick(object sender, EventArgs e)
        {
            _canvas.Clear();
            for(int i = 0 ; i < _trekLights.Length; i++)
            {
                if (_trekLights[i] != null)
                {
                    _trekLights[i].RenderLight(_canvas, i); // goes though all the lights and will render it into the canvas
                    _trekLights[i].Tick(); //increment the tick value so that the light will turn on
                }
            }
            _canvas.Render();
        }
        #endregion
    }
}
