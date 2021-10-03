using System;
using System.Collections.Generic;
using System.Threading;

namespace _004_Threads
{
    public static class Program
    {
        static void WriteSecond(object argument)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(argument);
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            //ParameterizedThreadStart writeSecond = new ParameterizedThreadStart(WriteSecond);
            //Thread thread = new Thread(writeSecond);
            //thread.Start("Hello");

            //Thread.Sleep(500);
            Console.ReadKey();
        }
    }
}
