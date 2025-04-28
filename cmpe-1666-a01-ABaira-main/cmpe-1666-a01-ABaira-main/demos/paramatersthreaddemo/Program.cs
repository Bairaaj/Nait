using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace paramatersthreaddemo
{
    class Program
    {
        struct PrimeData
        {
            public int min;
            public int max;
            public PrimeData(int Min, int Max)
            {
                min = Min;
                max = Max;
            }
        }
        static void Main(string[] args)
        {
            Thread thPrime = new Thread(new ParameterizedThreadStart(FindPrime));
            thPrime.Start(new PrimeData(50000, 100000));
        }
        static void FindPrime(object objData)
        {
            bool bisPrime = true;
            if (objData is PrimeData prime)
            {
                for(int iNumber = prime.min; iNumber <= prime.max; iNumber++)
                {
                    bisPrime = true;
                    for (int iTry = 2; iTry <= iNumber - 1; ++iTry)
                    {
                        if (iNumber % iTry == 0)
                        {
                            bisPrime = false;
                        }
                    }
                    if(bisPrime)
                    {
                        Console.WriteLine(iNumber);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
