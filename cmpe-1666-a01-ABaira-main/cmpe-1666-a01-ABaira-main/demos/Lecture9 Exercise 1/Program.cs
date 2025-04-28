using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture9_Exercise_1
{
    internal class Program
    {
        delegate int delBinaryOp(int x, int y);
        static void Main(string[] args)
        {
            delBinaryOp additions = new delBinaryOp(addition);
            delBinaryOp mult = new delBinaryOp(Multi);
            delBinaryOp divs = new delBinaryOp(div);

            int plus = additions.Invoke(4, 5);
            int times = mult.Invoke(4, 5);
            int half = divs.Invoke(4, 2);

            Console.WriteLine($"{additions.Invoke(4, 5)}, {mult.Invoke(4, 5)}, {divs.Invoke(4, 2)}");
            Console.WriteLine("{0}, {1}, {2}", plus, times, half) ;
            Console.ReadLine();

        }
        static private int addition(int x, int y)
        {
            int z;
            z = x + y;
            return z;
        }
        static private int Multi(int x, int y)
        {
            int z;
            z = x * y;
            return z;
        }
        static private int div(int x, int y)
        {
            int z;
            z = x / y;
            return z;
        }
    }
}
