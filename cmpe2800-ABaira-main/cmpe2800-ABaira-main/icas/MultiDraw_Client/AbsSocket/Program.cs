/*
 *  Abstract Socket
 *  CMPE2800 - A03
 *  Adrian Baira
 *  April 09, 2025
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AbsSocket
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class AbsSocket
    {
        Socket _socket = null;                              //server to connect
        Action<List<string>, AbsSocket> _dataReady = null;             // callback for data ready
        Action<Exception> _error = null;                    // callback for error
        Thread _sendThread, _receiveThread, _processThread; // threads for sending, receiving and processing data
        Queue<string> _Rx = new Queue<string>();            // queue for received data
        Queue<string> _Tx = new Queue<string>();            // queue for sending data
        List<string> dataList = new List<string>();
        string json = "";

        public int framesRX = 0;
        public int fragments = 0;
        public double destackAvg = 0;
        public volatile int bytesRx = 0;

        public bool Connected { get; set; } = false;

        /// <summary>
        /// Constructor for AbsSocket
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="dataReady"></param>
        /// <param name="error"></param>
        public AbsSocket(Socket socket, Action<List<string>, AbsSocket> dataReady, Action<Exception> error)
        {
            _socket = socket;
            _dataReady = dataReady;
            _error = error;

            //assign threads to methods
            _sendThread = new Thread(SendThread);
            _receiveThread = new Thread(ReceiveThread);
            _processThread = new Thread(ProcessThread);

            //set threads to background
            _sendThread.IsBackground = true;
            _receiveThread.IsBackground = true;
            _processThread.IsBackground = true;

            //start threads
            _sendThread.Start();
            _receiveThread.Start();
            _processThread.Start();

            Connected = true;
        }

        /// <summary>
        /// receive thread
        /// processing the data to json
        /// </summary>
        public void ReceiveThread()
        {
            try
            {

                while (true)
                {
                    // receive data from socket
                    byte[] buff = new byte[2048];
                    int bytes = _socket.Receive(buff, SocketFlags.None);
                    if (bytes < 0)
                    {
                        
                        return;
                    }
                    else
                    {

                        bytesRx += bytes;
                    }
                    // convert bytes to string
                    string data = Encoding.UTF8.GetString(buff, 0 , bytes);
                    string fragment = ProcessJSON(data);

                    if(fragment.Length != 0)
                    {
                        fragments++;
                    }
          

                    Thread.Sleep(0);

                }
            }
            catch (SocketException e)
            {
                // Invoke error handler if a socket exception occurs
                _error?.Invoke(e);
            }
            catch (Exception ex)
            {
                // Invoke error handler for any other type of exception
                _error?.Invoke(ex);
                return;
            }

        }
        /// <summary>
        /// Process the data to json
        /// Defragment / reassemble the data
        /// </summary>
        /// <param name="data">data sent from the server</param>
        public string ProcessJSON(string data)
        {
            bool inside = false;
            framesRX++;
            foreach (char c in data)
            {
                //if the character is a '{' then we are inside a json object
                
                if (c == '{')
                {
                    inside = true;
                }
                if (inside)
                {
                    json += c;
                }
                //if the character is a '}' then we are outside a json object
                if (c == '}')
                {
                    inside = false;
                    //add to the queue
                    lock (_Rx)
                    {
                        _Rx.Enqueue(json);
                    }
                    json = "";
                    data = "";
                }
            }
            return data;
        }
        /// <summary>
        /// adding data to the queue to send to the server
        /// </summary>
        /// <param name="data"></param>
        public void Send(string data)
        {
            lock(_Tx)
            {
                _Tx.Enqueue(data);
            }
        }

        /// <summary>
        /// hread responsible for sending data from the tx queue over the socket.
        /// </summary>
        public void SendThread()
        {
            try
            {
                // Continuously check for data to send
                while (true)
                {

                    Thread.Sleep(0);
                    string data = null;
                    // If there is data in the tx queue then dequeue it
                    if (_Tx.Count > 0)
                    {
                        data = _Tx.Dequeue();
                    }
                    // If data was dequeued, convert it to bytes and send
                    if (data != null)
                    {
                        byte[] message = Encoding.UTF8.GetBytes(data);
                        _socket.Send(message, message.Length, SocketFlags.None);
                    }
                }
            }
            catch (SocketException e)
            {
                // Invoke error handler if a socket exception occurs
                _error?.Invoke(e);
            }
            catch (Exception ex)
            {
                // Invoke error handler for any other type of exception
                _error?.Invoke(ex);
                return;
            }
        }

        /// <summary>
        /// Thread responsible for processing received data from the _Rx queue
        /// </summary>
        private void ProcessThread()
        {
            try
            {
                // Continuously check for received data to process
                while (true)
                {
                    Thread.Sleep(0);
                    // Lock the _Rx queue to ensure thread safety while dequeuing
                    lock (_Rx)
                    {
                        //deque all data 
                        while (_Rx.Count > 0)
                        {
                            dataList.Add(_Rx.Dequeue());
                        }

                    }
                    //invoke the data ready callback if there is data to process
                    if (dataList.Count > 0)
                    {
                        _dataReady?.Invoke(dataList, this);
                    }
                    dataList.Clear();

                }
            }
            catch (SocketException e)
            {
                // Invoke error handler if a socket exception occurs
                _error?.Invoke(e);
            }
            catch (Exception ex)
            {
                // Invoke error handler for any other type of exception
                _error?.Invoke(ex);
                return;
            }
           
        }
    }
}
