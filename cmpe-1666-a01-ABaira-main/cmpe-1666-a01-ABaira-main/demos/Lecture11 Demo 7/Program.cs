using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture11_Demo_7
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            List<string> newlist;
            int numofnames;
            Console.Write("Number of names to add: ");
            int.TryParse(Console.ReadLine(), out numofnames);

            for(int i = 0; i < numofnames; i++) 
            {
                Console.Write($"{i + 1}. Input Name: ");
                list.Add(Console.ReadLine());
            }
            newlist = list.FindAll(FindVowel);

            Console.WriteLine("Here are the list of names that have the vowels [aeiou]:");
            foreach(string name in newlist) 
            { 
                Console.Write(name + " ");
            }
            Console.ReadLine();
        }
        static private bool FindVowel(string name)
        {
            return ("aeiou".Contains(char.ToLower(name[0])));
        }
    }
}
