using System;
using System.Threading;

namespace Profesional_Threads_002
{
    class Program
    {
        static void WriteChar(char chr, int count, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(20);
                Console.Write(chr);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Method3()
        {
            Console.WriteLine("Third thread # {0}", Thread.CurrentThread.GetHashCode());
            WriteChar('3', 80, ConsoleColor.Yellow);
            Console.WriteLine("Third thread is completed");
        }

        public static void Method2()
        {
            Console.WriteLine("Second thread # {0}", Thread.CurrentThread.GetHashCode());
            WriteChar('2', 80, ConsoleColor.Blue);

            var thread = new Thread(Method3);
            thread.Start();
            thread.Join();

            WriteChar('2', 80, ConsoleColor.Blue);
            Console.WriteLine("Second thread is completed");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Firts thread # {0}", Thread.CurrentThread.GetHashCode());
            WriteChar('1', 80, ConsoleColor.Green);

            Thread thread = new Thread(Method2);
            thread.Start();
            thread.Join();

            WriteChar('1', 80, ConsoleColor.Green);

            Console.WriteLine("First thread is complete");
        }
    }
}
