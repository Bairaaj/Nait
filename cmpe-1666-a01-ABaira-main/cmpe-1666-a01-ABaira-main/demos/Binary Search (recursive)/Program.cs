using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search__recursive_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>();
            int P1;
            int value;
            myList.Add(8);
            myList.Add(12);
            myList.Add(15);
            myList.Add(19);

            myList.Add(23);
            myList.Add(38);
            myList.Add(45);
            myList.Add(56);

            value = 56;
            P1 = RBinarySearch(myList, 0, myList.Count -1, value);
            if (P1 > -1)
                Console.WriteLine($"{value} found at position {P1}");
            else
                Console.WriteLine($"{value} not found ");

            Console.Read();


            value = 12;
            P1 = RBinarySearch(myList, 0, myList.Count - 1, value);
            if (P1 > -1)
                Console.WriteLine($"{value} found at position {P1} ");
            else
                Console.WriteLine($"{value} not found");
            value = 40;
            P1 = RBinarySearch(myList, 0, myList.Count - 1, value);
            if (P1 > -1)
                Console.WriteLine($"{value} found at position {P1} ");
            else
                Console.WriteLine($"{value} not found ");

            Console.Read();
        }
        static private int RBinarySearch(List<int> L, int low, int high, int val)
        {
            if (high >= low)
            {
                int mid = (low + high) / 2;
                // If the element is present at the middle
                if (L[mid] == val)
                    return mid;
                // If element is smaller than L[mid], then it can only be present in left sublist
                if (val < L[mid])
                    return RBinarySearch(L, low, mid - 1, val);
                // Else the element can only be present in right sublist
                return RBinarySearch(L, mid + 1, high, val);
            }
            // We reach here when element is not present in the list
            return -1;
        }
    }
}
