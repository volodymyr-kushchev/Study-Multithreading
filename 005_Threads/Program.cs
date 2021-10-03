using System;
using System.Threading;

namespace _005_Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;

            Thread thread = new Thread(delegate () { Console.WriteLine("1. counter = {0}", ++counter); });
            thread.Start();

            Thread.Sleep(100);
            Console.WriteLine("2. counter = {0}", counter);

            thread = new Thread((object argument) => { Console.WriteLine("3. counter = {0}", (int)argument); });
            thread.Start(counter);

            Console.ReadKey();
        }
    }
}
