/*
 *  Multi Draw Client
 *  CMPE2800 - A03
 *  Adrian Baira
 *  April 09, 2025
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDlg_AdrianBaira;
using System.Threading;
using AbsSocket;
using Newtonsoft.Json;
using System.Data.SqlTypes;
namespace MultiDraw_Client
{
    public partial class MDClient : Form
    {
        Socket socket = null;                                           //Socket to connect
        bool connected = false;                                         //If the socket is connected
        Color drawColor = Color.Blue;                                   //Color of the line
        int thickness = 1;                                             //Thickness of the line
        int alpha = 255;
        List<LineSegment> drawings = new List<LineSegment>();           //Drawings to draw on the windows form
        AbsSocket.AbsSocket absSocket = null;                           //Abstract Socket
        Queue<string> _Rx = new Queue<string>();                        
        bool draw = false;


        /// <summary>
        /// CTOR for client
        /// </summary>
        public MDClient()
        {
            InitializeComponent();                                      // Initialize the form and its controls
            UI_LBL_Thickness.MouseWheel += UI_LBL_Thickness_MouseWheel; // Mouse wheel event to change thickness
            UI_LBL_Color.BackColor = drawColor;                         // Set the color label to match the current drawing color
            UI_LBL_Aplha.MouseWheel += UI_LBL_Aplha_MouseWheel;
        }

        private void UI_LBL_Aplha_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (++alpha >= 255)
                    alpha = 255;
            }
            else if (e.Delta < 0)
            {
                if (--alpha <= 0)
                    alpha = 1;
            }

            UI_LBL_Aplha.Text = $"Alpha: {alpha}";
        }
        /// <summary>
        /// Scroll wheel to increase or decrease the thickness of the pen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_LBL_Thickness_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (++thickness >= 255)
                    thickness = 255;
            }
            else if (e.Delta < 0)
            {
                if (--thickness <= 0)
                    thickness = 1;
            }

            UI_LBL_Thickness.Text = $"Thickness: {thickness}";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_BTN_ConnectDisconnect_Click(object sender, EventArgs e)
        {
            //Connect to the server
            if (!connected)
            {
                socket = null;
                CDlg_AdrianB dialog = new CDlg_AdrianB("bits.cnt.sast.ca", 1667);
                //Socket connect dialog
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    socket = dialog.socket;                             // Assign the socket from the dialog
                    connected = true;                                  // Mark as connected
                    UI_BTN_ConnectDisconnect.Text = "Disconnect";      // Update button text
                    absSocket = new AbsSocket.AbsSocket(socket, ProcessData, HandleError);
                }
            }
            else // If already connected, disconnect
            {
                connected = false;       
                try
                {
                    socket?.Shutdown(SocketShutdown.Both);             // Shut down the socket communication
                    socket?.Close();                                   // Close the socket
                    socket = null;                                     // Reset socket object
                }
                // Display socket-related exception
                catch (SocketException ex)
                {
                    MessageBox.Show($"Socket Exeption: {ex}");
                }
                // Display other exceptions
                catch (Exception exx)
                {
                    MessageBox.Show($"Exception: {exx}");
                }

                UI_BTN_ConnectDisconnect.Text = "Connect";
            }
            
            
        }

        private void ProcessData(List<string> json, AbsSocket.AbsSocket socket)
        {
            
            if(InvokeRequired)
            {
                Invoke((Action)(() => 
                { 
                    UI_LBL_BytesRX.Text = $"Bytes Rx'd: {socket.bytesRx}";
                    UI_LBL_Frames.Text = $"Frames RX': {socket.framesRX}";
                    UI_LBL_Fragments.Text = $"Fragments: {socket.fragments}";

                }));
            }
           
            // Iterate through received JSON strings
            foreach (var frame in json)                                
            {
                // Deserialize JSON into LineSegment object
                var ok = LineSegment.JSONToLineSegment(frame);         
                // Add the line segment to the drawing list
                if(ok == null)
                {
                    return;
                }
                drawings.Add(ok);                                      
                
            }
            Draw(); // Render the drawings on the form

        }

        public void Draw()
        {
            // Iterate through the drawings list
            foreach (var line in drawings)
            {
                // Ensure the line segment is valid
                if (line != null)
                {
                    // Render the line segment onto the form
                    line.Render(CreateGraphics());
                }
            }
            drawings.Clear();
        }
        private void HandleError(Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }

        private void UI_BTN_Color_Click(object sender, EventArgs e)
        {
            UI_ColorDlg.ShowDialog();
            drawColor = UI_ColorDlg.Color;
            UI_LBL_Color.BackColor = drawColor;
        }
      


        private void MDClient_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
        }


        private void MDClient_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }
        private void MDClient_MouseMove(object sender, MouseEventArgs e)
        {
            if (absSocket == null)
                return;

            
            if (draw)
            {
                LineSegment line = new LineSegment();
                line.SX = (short)e.X;
                line.SY = (short)e.Y;
                line.EX = (short)e.X;
                line.EY = (short)e.Y;
                line.C =  Color.FromArgb(alpha, drawColor);
                line.T = (byte)thickness;  
                absSocket.Send(line.LineSegmentToJSON());
            }
           
        }
    }
   
}
