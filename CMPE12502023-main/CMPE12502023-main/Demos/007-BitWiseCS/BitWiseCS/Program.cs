using System;

namespace BitWiseCS
{
    class Program
    {
        //Masks Constants
        const UInt16 BIT0 =  0x0001;
        const UInt16 BIT15 = 0x8000;

        static void Main(string[] args)
        {
            string input;
            UInt16 number;

            while(true)
            {


                Console.Write("Enter a positive number: ");
                input = Console.ReadLine();
                try
                {
                    number = UInt16.Parse(input);
                    if( number < 0 ) 
                    {
                        throw new Exception("The number cannot be negative");
                    }
                    Console.WriteLine("The number in DEC: {0:D}", number);
                    Console.WriteLine("The number in HEX: 0x{0:X}", number);
                    Console.WriteLine("The number in BIN: {0}", ToBinary(number));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The number you have entered is not valid");
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.Write("Press Any Key to repeat... ");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static string ToBinary(UInt16 _number)
        {
            string binOutput = "";
            for (int i = 0; i < 16; i++)
            {
                if ((_number & (BIT15 >> i)) != 0)
                {
                    binOutput += '1';
                }
                else
                {
                    binOutput += '0';
                }
            }
            return binOutput;
        }
    }
}
