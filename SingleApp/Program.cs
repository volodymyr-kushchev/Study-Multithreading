using System;
using System.Threading;

namespace SingleApp
{
    class Program
    {
        static Mutex mutex = new Mutex(false, "My Custom Mutex");

        static void Main(string[] args)
        {
            Console.WriteLine("Single app per machine using blocking mechanism in multithreading");

            //Thread thread = new Thread(SomeWorkWhichCloseCopiesOfApp);
            //thread.Start();
            //Environment.Exit(0);

            SomeWorkWhichCloseCopiesOfApp();

            Console.WriteLine("After exit");
            Console.ReadKey();
        }

        static void SomeWorkWhichCloseCopiesOfApp()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(2), false))
            {
                Console.WriteLine("An instance of this app has been already started, please, close this one.");
            }

            Console.WriteLine($"Thread - {Thread.CurrentThread.ManagedThreadId} mutex wait one " + mutex.WaitOne().ToString());
            bool isAlive = true;

            while (isAlive)
            {
                //Thread.Sleep(1000);
                Console.WriteLine($"Thread - {Thread.CurrentThread.ManagedThreadId} Enter Y to contuniue, N to close");
                var answer = Console.ReadKey();

                if (answer.KeyChar == 'Y')
                {
                    isAlive = true;
                }

                if (answer.KeyChar == 'N')
                {
                    isAlive = false;
                }
            }

            mutex.ReleaseMutex();
        }
    }
}
