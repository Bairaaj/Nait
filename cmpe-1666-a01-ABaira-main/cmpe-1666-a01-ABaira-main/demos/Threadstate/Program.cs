using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threadstate
{
    class Program
    {
        public static Thread t1 = null;
        static void Main(string[] args)
        {
            t1 = new Thread(ThreadTest);
            Console.WriteLine($"The State of T1 is: {t1.ThreadState.ToString()}");
            t1.IsBackground = true;
            Thread.Sleep(5000);
            Console.WriteLine($"The state of T1 is: {t1.ThreadState.ToString()}");
            t1.Start();
            Thread.Sleep(2000);
            Console.WriteLine($"The state of T1 is: {t1.ThreadState.ToString()}");
            if (t1.ThreadState == ThreadState.Stopped)
            {
                Console.WriteLine("Thread Has been stopped");
            }
            Console.ReadLine();
        }
        static void ThreadTest()
        {
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"i = {i} ");
                Thread.Sleep(50);
            }
            Console.WriteLine($"The state of T1 is: {t1.ThreadState.ToString()}");
        }
    }
}
