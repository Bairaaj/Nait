//*************************************************************************************************
//Submission Code:  2800_1242_A02                  
//Program:          ica02_AdrianB
//Description:      IEnumerable, Iterator Methoids, Defferred Execution
//Date:             Jan. 20, 2025
//Author:           Adrian Baira
//Course:           CMPE2800
//Class:            CNTA03
//**************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ica02_AdrianB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GridExt Grid = new GridExt((3, 3));
            Console.WriteLine("Corner Check top left(0,0)");
            /* Corner Check
             *(0,0) 0   0
             *  0   0   0
             *  0   0   0   
             */
            foreach ((int x, int y) z in Grid)
            {
                if(z.x != -1 && z.y != -1)
                    Console.WriteLine($"{z.x} {z.y}");
            }



            Console.WriteLine("\nCorner Check bottom right(2,2)");
            /* Corner Check
             *  0   0   0
             *  0   0   0
             *  0   0 (2,2)   
             */
            Grid.setCursor((2, 2));
            foreach ((int x, int y) z in Grid)
            {
                if (z.x != -1 && z.y != -1)
                    Console.WriteLine($"{z.x} {z.y}");
            }


            Console.WriteLine("\nMiddle Check (1,1)");
            /* Middle Check
             *  0   0   0
             *  0 (1,1) 0
             *  0   0   0   
             */

            Grid.setCursor((1, 1));
            foreach ((int x, int y) z in Grid)
            {
                if (z.x != -1 && z.y != -1)
                    Console.WriteLine($"{z.x} {z.y}");
            }


            Console.WriteLine("\nLeft Edge Check (0,2)");
            /* Edge Check
             *  0   0   0
             *(0,2) 0   0
             *  0   0   0   
             */
            Grid.setCursor((0, 2));
            foreach ((int x, int y) z in Grid)
            {
                if (z.x != -1 && z.y != -1)
                    Console.WriteLine($"{z.x} {z.y}");
            }

            Console.WriteLine("\nRight Edge Check (2,1)");
            /* Edge Check
             *  0   0   0
             *  0   0 (2,1)
             *  0   0   0   
             */
            Grid.setCursor((2, 1));
            foreach ((int x, int y) z in Grid)
            {
                if (z.x != -1 && z.y != -1)
                    Console.WriteLine($"{z.x} {z.y}");
            }
            Console.ReadLine();
        }
    }
}
