namespace _009_EndiansDemoCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UInt16 num1 = 0xA1A2;
            UInt32 num2 = 0xA1A2A3A4;

            byte[] data1 = BitConverter.GetBytes(num1);
            byte[] data2 = BitConverter.GetBytes(num2);
        }
    }
}