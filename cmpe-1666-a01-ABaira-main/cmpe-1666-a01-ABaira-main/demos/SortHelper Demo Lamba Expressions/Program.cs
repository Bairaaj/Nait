using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortHelper_Demo_Lamba_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 24, 25, 267, 74, 8, 2, 6, 8, 1, 7, 93, 23, 6, 3, 63, 7, 37 };
            Console.WriteLine("Inital Values for list before sorting: ");
            foreach(int i in list)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine("\n");

            //this is the lamba express ion for the comparison delegate asc order
            list.Sort((x , y) => 
            {
                if (x < y) 
                    return -1; 
                else if (x > y)
                    return 1;
                return 0; 
            });
            //sorting in dec order
            list.Sort((x, y) =>
            {
                if (x < y)
                    return 1;
                else if (x > y)
                    return -1;
                return 0;
            });
            Console.WriteLine("\n");
            Console.WriteLine("Values for list after sorting: ");
            foreach (int i in list)
            {
                Console.Write($"{i}, ");
            }

            Console.ReadLine();
        }
    }
}
