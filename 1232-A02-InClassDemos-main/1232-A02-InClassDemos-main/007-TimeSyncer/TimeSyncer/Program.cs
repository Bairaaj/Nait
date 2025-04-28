using System.IO.Ports;

namespace TimeSyncer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SerialPort _port = null;
            TimeData time = new TimeData();

            Connect(ref _port);
            Timer ticker = new Timer(UpdateTime);
            ticker.Change(0, 500);
            Console.Clear();
            while (true)
            {

                if(Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;                   
                    Console.WriteLine("Time sync requested ("+key.ToString() + " pressed). " +
                        "Press any key to resume time...");
                    time.SendTime(_port, DateTime.Now);
                    ticker.Dispose();
                    Console.ReadKey();
                    Console.Clear();
                    ticker = new Timer(UpdateTime);
                    ticker.Change(0, 500);
                }
                    
            }
        }

        private static void UpdateTime(object? state)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(DateTime.Now.ToString());
            Console.SetCursorPosition(0, 15);
            while (Console.GetCursorPosition() != (0, 15)) ;
            Console.WriteLine("Press any key to sync time...");
        }

        static void Connect(ref SerialPort port)
        {
            Console.WriteLine("Select a COM Port to connect to at 115,200 Kbps: ");

            string[] ports = SerialPort.GetPortNames();

            if(ports.Length == 0 ) 
            {
                Console.WriteLine("No COM port found...");
            }
            else
            {
                for (int i = 0; i < ports.Length; i++)
                {
                    Console.WriteLine("({0}) - {1}", i + 1, ports[i]);
                }
                int option = PromptInt("Enter option: ", 1, ports.Length);

                try
                {
                    port = new SerialPort(ports[option - 1], 115200);
                    port.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.WriteLine("Connected to {0} at 115,200 BR", ports[option - 1]);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }


        static int PromptInt(string message, int min, int max)
        {
            bool success = false;
            int selection = - 1;

            while(!success)
            {
                Console.Write(message);
                try
                {
                    selection = int.Parse(Console.ReadLine());
                    if(selection < min || selection > max)
                    {
                        throw new Exception("Ivalid option range. Try again...");
                    }
                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return selection;

        }
    }
}