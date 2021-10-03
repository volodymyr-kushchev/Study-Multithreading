using System;
using System.Threading;

namespace _002_Threads
{
    class Program
    {
        static void WriteSecond()
        {
            int counter = 0;

            while (true)
            {
                Console.WriteLine("Thread id {0}, counter = {1}", Thread.CurrentThread.GetHashCode(), counter++);
            }
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(WriteSecond);
            thread.Start();

            WriteSecond();
        }
    }
}
