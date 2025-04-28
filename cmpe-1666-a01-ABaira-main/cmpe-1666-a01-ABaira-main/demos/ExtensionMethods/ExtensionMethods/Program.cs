using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> ints = new List<int>(new int[] { 3, 5, 7, 1, 78, 2, 0, -5 });
            IEnumerable<int> dupint = new List<int>(new int[] { 8, 5, 5, 8, 5, 2, 8, 8 });
            IEnumerable<char> chars = new List<char>("This is the end of the world".ToArray());
            IEnumerable<(int, string)> tupints = new List<(int, string)>(new (int, string)[] { (1, "one"), (2, "two"), (3, "three"), (4, "four"), (5, "five"), (6, "six") });

            List<List<int>> ints2D = new List<List<int>>();
            ints2D.Add(new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
            ints2D.Add(new List<int>(new int[] { 17, 23, -6, 14, 32, 8, 61, 3, 15 }));
            ints2D.Add(new List<int>(new int[] { 17, 23, -6, 14, 32, 8, 61, 3, 15 }));



            Console.WriteLine("Displaying ints: ");
            Show(ints);


            Console.Write("\nValues from ints, Using Where: ");
            Show(ints.Where(q => q >= 5));

            int c = 34;
            int b = 54;
            //set a if C< B then ? TRUE Set C to B then if False leave C as C
            c = c < b ? b : c;

            Console.WriteLine($"\nTesting Conditionals {c}");

            Console.Write($"\nUsing Agregate on ints: ");
            Console.WriteLine(ints.Aggregate(ints.First(), (a, r) => a = r > a ? r : a));
            //Console.WriteLine($"{ints.Aggregate(ints.First(), (a, r) => a = r > a ? r : a)}");
            //to count how many are in the list that are greater than 5
            Console.WriteLine($"\nCount Values Greater than 5 from ints: {ints.Count(q => q > 5)}");
            //so that i dont have any duplicates
            Console.Write("Distinct Values from dupint:");
            Show(dupint.Distinct());


                

            Console.WriteLine("\nPress Any Key to continue");



            Console.ReadLine();

        }

        static void Show<T>(IEnumerable<T> col)
            => Console.WriteLine(string.Join(" ,", col));
    }
}
