using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_9_exercise3
{
    internal class Program
    {
        delegate int Deleopbinary(int x, int y);

        


        static void Main(string[] args)
        {
            Deleopbinary delobj1 = null, delobj2 = null, delopj3 = null;

            delobj1 = add;
            delobj2 = new Deleopbinary(add);
            

            int x;
            int y;
            Console.Write("Enter first number: ");
            int.TryParse(Console.ReadLine(), out x);

            Console.Write("Enter second number: ");
            int.TryParse(Console.ReadLine(), out y);

            Console.WriteLine("Invoking the delegate: {0}",delobj1.Invoke(x, y));
           

            Console.WriteLine("Using short hand method: {0}",delobj2(5, 6));
           
            delopj3 = delegate(int z, int c) { return z*c; };

            Console.WriteLine("Using Anonymus method: {0}",delopj3(5,8));

            Console.ReadLine();

        }
        static private int add(int x, int y) 
        {   
            return x + y;
        }
       
    }

}
