using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture11_Demo_1_2
{
    internal class Program
    {
        static public List<int> list = new List<int>();
        static public List<int> list2 = new List<int>() {1,234,13,16,329,70,305,2,3,6,23,2};
        static void Main(string[] args)
        {
            list.Add(12);
            list.Add(20);
            list.Add(1);
            list.Add(15);
            list.Add(12);
            list.Add(50);
            list.Add(78);
            list.Add(84);
            list.Add(13);
            //list.Sort();
            Console.Write("List one before sorting: ");
            foreach (int x in list) 
            {
                Console.Write(x + " ");
            }
            Console.Write("\n\n");
            list.Sort();
            Console.Write("List one after sorting: ");
            foreach (int x in list)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("\n");

            Console.Write("List two before sorting: ");
            foreach (int x in list2)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("\n");
            list2.Sort(SortDesc);
            Console.Write("List two after sorting: ");
            foreach (int x in list2)
            {
                Console.Write(x + " ");
            }

           

            Console.ReadLine();

        }
        public void Sort(Comparer<int> comparision)
        {

        }
        public int SortAsc(int x, int y)
        {
            if (x < y)
                return -1;
            else if (x > y) 
                return 1;
            else 
                return 0;
        }
        static public int SortDesc(int x, int y)
        {
            if (x > y)
                return -1;
            else if (x < y)
                return 1;
            else
                return 0;
        }
    }
}
