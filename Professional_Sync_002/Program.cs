using System;
using System.Threading;

namespace Professional_Sync_002
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programm start");
            Report();

            ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
            Report();

            ThreadPool.QueueUserWorkItem(Task2);
            Report();

            Thread.Sleep(3000);
            Console.WriteLine("Programm is completed");
            Report();
        }

        static void Task1(Object state)
        {
            Thread.CurrentThread.Name = "1";
            Console.WriteLine("Thread has been started {0}\n", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} is completed {0}\n", Thread.CurrentThread.Name);
        }

        static void Task2(Object state)
        {
            Thread.CurrentThread.Name = "2";
            Console.WriteLine("Thread has been started {0}\n", Thread.CurrentThread.Name);
            Thread.Sleep(500);
            Console.WriteLine("Thread {0} is completed {0}\n", Thread.CurrentThread.Name);
        }

        static void Report()
        {
            Thread.Sleep(200);
            int availableWorkThreads, availableIOThreads, maxWorkThreads, maxIOThreads;
            ThreadPool.GetAvailableThreads(out availableWorkThreads, out availableIOThreads);
            ThreadPool.GetMaxThreads(out maxWorkThreads, out maxIOThreads);

            Console.WriteLine("Work threads available in a pool :{0} from {1}", availableWorkThreads, maxWorkThreads);
            Console.WriteLine("IO threads available in a pool   :{0} from {1}", availableIOThreads, maxIOThreads);
        }
    }
}
