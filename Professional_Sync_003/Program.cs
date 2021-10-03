using System;
using System.Threading;

namespace Professional_Sync_003
{
    class Program
    {
        static Mutex mutex = new Mutex(false, "Custom Mutex");
        static Semaphore semaphore = new Semaphore(2, 4, "Custom Semaphore");
        static object locker = new object();

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(Procedure);
                threads[i].Name = i.ToString();
                threads[i].Start();
            }

            Console.ReadKey();
        }

        static void Procedure()
        {
            mutex.WaitOne();
            //lock(locker)
            //{
                Console.WriteLine("Thread {0} in the critical section", Thread.CurrentThread.Name);
                Thread.Sleep(2000);
                Console.WriteLine("Thread {0} left critical section", Thread.CurrentThread.Name);
            //}

            mutex.ReleaseMutex();
            Console.WriteLine();
        }
    }
}
