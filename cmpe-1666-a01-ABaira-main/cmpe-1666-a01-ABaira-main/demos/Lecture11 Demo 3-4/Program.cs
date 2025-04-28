using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture11_Demo_3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>() { 1, 234, 13, 16, 329, 70, 305, 2, 3, 6, 23, 2 };
            List<int> list2 = new List<int>() { 1, 234, 13, 16, 329, 70, 305, 2, 3, 6, 23, 2 };
            List<string> stringlist = new List<string>() { "Edmonton", "Calgary", "Banff", "Canmore", "Red Deer", "St. Albert", "Toronto" };
            Console.Write("List one before sorting: ");
            foreach (int x in list1)
            {
                Console.Write(x + " ");
            }


            list1.Sort(SortAsc);
            Console.WriteLine("\n");
            Console.Write("List one after sorting: ");
            foreach (int x in list1)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("\n");
            Console.Write("List two before sorting: ");
            foreach (int x in list2)
            {
                Console.Write(x + " ");
            }

            list2.Sort(SortDesc);

            Console.Write("\nList string before sorting: ");
            foreach (string x in stringlist)
            {
                Console.Write(x + " ");
            }
            stringlist.Sort(SortDesc);
            
            
           
            Console.Write("\nList string after sorting: ");
            foreach (string x in stringlist)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("\n\n");
            Console.Read();

        }
        static private int SortDesc(int x, int y)
        {
            return y.CompareTo(x);
        }
        //Overload
        static private int SortDesc(string str1, string str2)
        {
            return str2.CompareTo(str1);
        }
        static private int SortAsc(int x, int y) 
        { 
            return x.CompareTo(y);
        }

    }
}
