using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15_AdrianBaira
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Gate or = new OR();
            Console.Write(ToTable(or));
            Console.ReadLine();
        }
        public static string ToTable(Gate gate)
        {
            StringBuilder tes = new StringBuilder();

            tes.AppendFormat(format:("{0}", object test, object a);
            string table = $"A    B     {gate._name}\n";
            for(int i = 0; i < 2; i++)
            { 
                for (int j = 0; j < 2; j++)
                {
                    
                    gate.Set(i, j);    
                    gate.Latch();
                    if(gate.Output)
                    {
                        table += $"{i}    {j}       1\n";
                    }
                    else
                        table += $"{i}    {j}       0\n";

                }

            }
            return table;


        }
    }
}
