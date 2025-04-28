using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_11_demo_9_Predicatess
{
    class Program
    {
        static void Main(string[] args)
        {
            //demo 9
            List<string> list = new List<string>() { "Edmonton", "Calgary", "Canada", "Good", "Bad", "Try", "Hard", "Paris", "Berlin", "Too", "You", "Toronto" };

            List<string> fileredList = list.FindAll(delegate (string x) { return x.Length >= 4; });
            Console.WriteLine("Inital values of the list");

           foreach (string ds in list)
           {
                Console.Write($" {ds}, ");
           }
            Console.WriteLine("\n\n");

            Console.WriteLine("Filerterd values of list");
            //using Findall with an annonymous function to find all strings of length of 5 or higher
            
            foreach(string a in fileredList)
            {
                Console.Write($"{a}, ");
            }
            Console.ReadLine();
            Console.WriteLine("\n");
            //demo 9


            //demo 10
            List<string> lists = new List<string>() { "Edmonton", "Calgary", "Canada", "Good", "Bad", "Try", "Hard", "Paris", "Berlin", "Too", "You", "Toronto" };

            int n = 3;
            List<string> fileredLists = list.FindAll(x => x.Length >= n);
            Console.WriteLine("Inital values of the list for demo 10");

            foreach (string s in lists)
            {
                Console.Write($"{s}, ");
            }
            Console.WriteLine("\n\n");

            
            Console.WriteLine("Filerterd values of list for demo 10 Lamaba expressions");
            Console.WriteLine($"Number of filtered values is: {lists.FindAll(x => x.Length >= n).Count}");

            //using Findall with an annonymous function to find all strings of length of 5 or higher

            foreach (string a in fileredLists)
            {
                Console.Write($"{a}, ");
            }
            Console.ReadLine();

        }
    }
}
