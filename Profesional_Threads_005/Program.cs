using System;
using System.Threading;

namespace Profesional_Threads_005
{
    class Program
    {
        static long counter;

        static void Procedure()
        {

            for (int i = 0; i < 1000000; i++)
            {
                // Interlocked предоставляет атомарные операции для переменных, общедоступных нескольким потокам
                Interlocked.Increment(ref counter);
                // counter++;
            }
        }

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(Procedure);
                threads[i].Start();
            }

            Thread.Sleep(1000);

            Console.WriteLine("Expected output: 10000000");
            Console.WriteLine($"Excual output: {counter}");
        }
    }
}
