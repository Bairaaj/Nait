using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //first, second, return value
            Func<int, int, int> delBinartOp = new Func<int, int, int>(Sum);

            int result;

            result = delBinartOp(10, 15);

            Console.WriteLine("Result is {0}", result);

            Console.WriteLine("Press any key to exit;");
            Console.ReadLine();
            Console.ReadKey();
        }
        private static int Sum(int x, int y)
        {
            return x * y;
        }
    }
}
