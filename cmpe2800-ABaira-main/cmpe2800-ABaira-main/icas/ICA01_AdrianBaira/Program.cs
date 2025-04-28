/*
 * Adrian Baira CMPE2800 
 * Section A03
 * ICA 01 ExtensionGeneric
 * 
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ICA01_AdrianBaira
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Categorize Method only works with LIST<INT>
            Console.WriteLine("List<int> Extension");

            List<int> iNum = new List<int>(new int[] { 4, 12, 4, 3, 5, 6, 7, 6, 12 });
            foreach (KeyValuePair<int, int> scan in iNum.Categorize())
                Console.WriteLine($"{scan.Key:d3} x {scan.Value:d5}");


            //Categorized Method Generic int
            Console.WriteLine("\nGeneric Extension INT");

            List<int> iNums = new List<int>(new int[] { 4, 12, 4, 3, 5, 6, 7, 6, 12 });
            foreach (KeyValuePair<int, int> scan in iNums.CategorizeG())
                Console.WriteLine($"{scan.Key:d3} x {scan.Value:d5}");

            Console.WriteLine("\nGeneric Extension STRING");
            //Categorized Method Generic String
            List<string> name = new List<string>(new string[] { "Rick", "Glenn", "Rick", "Carl", "Michonne", "Rick", "Glenn" });
            foreach (KeyValuePair<string, int> scan in name.CategorizeG())
                Console.WriteLine($"{scan.Key} x {scan.Value:d5}");





            //Categorized Method with Generic IEnumerable
            Console.WriteLine("\nGeneric Extension IEnumerable");
            List<string> names = new List<string>(new string[] {"Rick", "Glenn", "Rick", "Carl", "Michonne", "Rick", "Glenn" });
            foreach (KeyValuePair<string, int> scan in names.CategorizeIE())
                Console.WriteLine($"{scan.Key} x {scan.Value:d5}");



            //Categorized Method with Generic Ienumerable For Letters
            Console.WriteLine("\n Generic Extension IEnumerable Letters");
            Random _rnd = new Random();
            LinkedList<char> llfloats = new LinkedList<char>();
            while (llfloats.Count < 1000)
                llfloats.AddLast((char)_rnd.Next('A', 'Z' + 1));
            foreach (KeyValuePair<char, int> scan in llfloats.CategorizeIE())
                Console.WriteLine($"{scan.Key} x {scan.Value:d5}");

            string TestString = "This is the test string, do not panic!";
            foreach (KeyValuePair<char, int> scan in TestString.CategorizeIE())
                Console.WriteLine($"{scan.Key} x {scan.Value:d5}");



            List<string> tests = new List<string>(new string[] { "Rick", "Glenn", "Rick", "Carl", "Michonne", "Rick", "Glenn" });
            Console.WriteLine(tests[0]);
            string comp = tests[0];
            for(int i = 0; i < tests.Count; i++)
            {
                for(int j = i + 1; j < tests.Count; j++)
                {
                  
                }
            }
      
            

            Console.ReadLine();
        }
    }
  
   

}
