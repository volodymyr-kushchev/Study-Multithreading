using System;
using System.Threading;

namespace _001_CriticalSection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 40);

            Myclass instance = new Myclass();

            for (int i = 0; i < 3; i++)
            {
                new Thread(instance.Method).Start();
            }

            Thread.Sleep(500);
        }
    }

    public class Myclass
    {
        object block = new object();

        public void Method()
        {
            int hash = Thread.CurrentThread.GetHashCode();

            lock (block)
            {
                for (int counter = 0; counter < 10; counter++)
                {
                    Console.WriteLine("Thread # {0}: step {1}", hash, counter);
                    Thread.Sleep(100);
                }
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}
