using System;
using System.Threading;

namespace _001_Threads
{
    class Program
    {
        static void WriteSecond()
        {
            int count = 0;
            while (true)
            {
                Console.WriteLine(new string(' ', 10) + "Secondary " + (count++).ToString());
            }
        } 

        static void Main(string[] args)
        {
            ThreadStart writeSecond = new ThreadStart(WriteSecond);
            Thread thread = new Thread(writeSecond);
            thread.Start();
            int count = 0;
            while (true)
            {
                Console.WriteLine("Primary " + (count++).ToString());
            }

            //Delay
            Console.ReadKey();
        }
    }
}
