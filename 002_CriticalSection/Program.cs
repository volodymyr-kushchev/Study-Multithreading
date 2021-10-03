using System;
using System.Threading;

namespace _002_CriticalSection
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass instance = new MyClass();

            for (int i = 0; i < 3; i++)
            {
                new Thread(instance.Method).Start();
            }

            Thread.Sleep(500);
        }
    }

    public class MyClass
    {
        object block = new object();

        public void Method()
        {
            int hash = Thread.CurrentThread.GetHashCode();

            Monitor.Enter(block);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread # {0}: step {1}", hash, i);
                Thread.Sleep(100);
            }
            Console.WriteLine(new string('-', 20));

            Monitor.Exit(block);
        }
    }
}
