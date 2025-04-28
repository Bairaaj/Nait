using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_7_demo1B_Selection_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; //Number of values to be generated
            Random random = new Random();
            Console.Write("Input the number of values to be generated: ");
            int.TryParse(Console.ReadLine(), out n);
            int[] myArray = new int[n]; //creating an arrat of size n

            //Generating random numbers in the range 1 - 100
            for (int count = 0; count < n; count++)
            {
                myArray[count] = random.Next(1, 101);
            }
            Console.Write("Array Values before sorting: ");
            foreach (int value in myArray)
            {
                Console.Write($"{value}, ");
            }
            Console.WriteLine();

            SelectionSort(myArray);
            Console.Write("Array Values after sorting: ");
            foreach (int value in myArray)
            {
                Console.Write($"{value}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();


        }

        static private void SelectionSort(int[] intArray)
        {
            for(int pass = 0; pass < intArray.Length -1; pass++)
            {
                int max_posn = 0;
                int last_posn = intArray.Length - 1 - pass;
                for (int j = 0; j <= last_posn; j++)
                {
                    if(intArray[j] > intArray[max_posn])
                    {
                        max_posn = j;
                    }
                    Swap(ref intArray[max_posn], ref intArray[last_posn]);
                }
            }

        }
        static private void Swap(ref int valueone, ref int valuetwo)
        {
            int temp = valueone;
            valueone = valuetwo;
            valuetwo = temp;
        }
        //This is reverse
        static private void SelectionSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] > list[max])
                    {
                        max = j;
                    }

                }
                Swap(list, max, i);
            }

        }
    }
}

