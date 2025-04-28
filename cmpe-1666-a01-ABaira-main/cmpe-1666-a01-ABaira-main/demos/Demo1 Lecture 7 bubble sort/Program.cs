using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1_Lecture_7_bubble_sort
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
            foreach(int value in myArray)
            {
                Console.Write($"{value}, ");
            }
            Console.WriteLine();

            Bubblesort(myArray);
            Console.Write("Array Values after sorting: ");
            foreach (int value in myArray)
            {
                Console.Write($"{value}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();


        }

        static private void Bubblesort(int[] intArrays)
        {
            //n-1 passes where n is the number of elements in the array
            int n = intArrays.Length;

            for(int pass = 0; pass <  n - 1; pass++)
            {
                for(int j = 0; j < (n - (pass + 1)); j++)
                {
                    if (intArrays[j] > intArrays[j+1])
                    {
                        Swap(ref intArrays[j], ref intArrays[j + 1]);
                    }
                }
            }
        }
        static private void Swap(ref int valueone, ref int valuetwo)
        {
            int temp = valueone;
            valueone = valuetwo;
            valuetwo = temp;
        }
    }
}
