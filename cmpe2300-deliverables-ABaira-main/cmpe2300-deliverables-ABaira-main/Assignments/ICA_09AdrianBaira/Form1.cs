using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA_09AdrianBaira
{
    public partial class Form1 : Form
    {
        const int totalShoppers = 200, minproducts = 5,  maxproducts = 15, canvasScale = 20;

        int reqCashiers = 10;
        int reqShoppers = 0;

        List<ConcurrentQueue<Cart>> cashiers = new List<ConcurrentQueue<Cart>>();

        CDrawer canvas = null;
        int processedSum;
        Stopwatch runtime = new Stopwatch();
        int threadID;

        public Form1()
        {
            InitializeComponent();
            UI_BTN_Simulate.MouseWheel += Form1_MouseWheel;
            MouseWheel += Form1_MouseWheel;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta < 0)
                reqCashiers--;    
            
            if(e.Delta > 0)           
                reqCashiers++;     
            
            if(reqCashiers <= 1)           
                reqCashiers = 1;
            
            if(reqCashiers >= 25)           
                reqCashiers = 25;

            UI_BTN_Simulate.Text = $"Simulate[{reqCashiers}]";
        }
        public string GetProducts()
        {
            string products = "";
            for(int i = 0; i < Cart.Next(minproducts, maxproducts + 1); i++)
            {
                products += (char)(Cart.Next(0,26) + 'A');
            }
            Console.WriteLine($"{products}");
            return products;
        }
        public void Cashier(object data)
        {
            if (data == null)
                return;
            if (!(data is ConcurrentQueue<Cart> cashiers))
                return;
            int sleep = Cart.Next(200, 400);
            int localsum = 0;
            Interlocked.Add(ref threadID, Thread.CurrentThread.ManagedThreadId);

            while(true)
            {
                Thread.Sleep(sleep);
                if (cashiers.Count <= 0)
                    continue;
                if(!cashiers.TryPeek(out Cart cart))
                    break;

                localsum += cart.Process();

                if(cart.done)
                {
                    cashiers.TryDequeue(out Cart result);
                    Interlocked.Add(ref processedSum, localsum);
                    localsum = 0;
                }
            }
            return;
            
        }
        private void UI_BTN_Simulate_Click(object sender, EventArgs e)
        {

            foreach (ConcurrentQueue<Cart> cash in cashiers)
            {
                cash.Enqueue(null);
            }
            while (threadID != 0)
            {
                Thread.Sleep(10);
            }
            cashiers.Clear();
            runtime.Restart();
            canvas?.Close();
            canvas = new CDrawer(1600, reqCashiers * canvasScale);
            canvas.Scale = canvasScale;
            processedSum = 0;

            reqShoppers = totalShoppers;

            for (int i = 0; i < reqShoppers; i++)
            {
                cashiers.Add(new ConcurrentQueue<Cart>());
            }
            
            foreach(ConcurrentQueue<Cart> cart in cashiers)
            {
                Thread thread = new Thread(()=>Cashier(cart));
                thread.IsBackground = true;
                thread.Start();
            }
           

        }

        private void UI_Timer_Tick(object sender, EventArgs e)
        {
            if (canvas == null)
                return;

        

            if (cashiers.Count != 0)
            {
                if (reqShoppers != 0)
                {
                    if (cashiers.Any((c) => c.Count < 4))
                    {
                        reqShoppers--;
                        cashiers.Where(z => z.Count < 4).First().Enqueue(new Cart(GetProducts()));
                        UI_LBL_CartsLeft.Text = $"{reqShoppers} left";
                    }
                }
                canvas.Clear();
                int x = 0;
                int y = 0;
                foreach (ConcurrentQueue<Cart> person in cashiers)
                {
                    x = 0;
                    foreach (Cart cart in person)
                    {
                        cart.ShowCart(canvas, new Point(x, y));
                        x += cart._maxproducts;
                    }
                    ++y;
                    if (y > cashiers.Count)
                    {
                        y = 0;
                    }

                }
                canvas.Render();
            }


        }
    }
}
