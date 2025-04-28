using System;

namespace BitWiseCS
{
    class Program
    {
        //Masks Constants
        const UInt16 BIT0 =  0x0001;
        const UInt16 BIT1 =  0x0002;
        const UInt16 BIT2 =  0x0004;
        const UInt16 BIT3 =  0x0008;
        const UInt16 BIT4 =  0x0010;
        const UInt16 BIT5 =  0x0020;
        const UInt16 BIT6 =  0x0040;
        const UInt16 BIT7 =  0x0080;
        const UInt16 BIT8 =  0x0100;
        const UInt16 BIT9 =  0x0200;
        const UInt16 BIT10 = 0x0400;
        const UInt16 BIT11 = 0x0800;
        const UInt16 BIT12 = 0x1000;
        const UInt16 BIT13 = 0x2000;
        const UInt16 BIT14 = 0x4000;
        const UInt16 BIT15 = 0x8000;

        static void Main(string[] args)
        {
            string input;
            UInt16 number;

            while(true)
            {
                Console.Write("Enter a positive number: ");
                input = Console.ReadLine();

                if(UInt16.TryParse(input, out number))
                {
                    Console.WriteLine("The number in DEC: {0:D}", number);
                    Console.WriteLine("The number in HEX: 0x{0:X}", number);
                    Console.WriteLine("The number in BIN: {0}", ToBinary(number));
                }
                else
                {
                    Console.WriteLine("The number you have entered is not valid");
                }

                Console.WriteLine("The : " + input);
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
                if((_number & (BIT15 >> i)) != 0)
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
