using System;
using System.Collections.Generic;
using System.Threading;

namespace Professional_Sync_001
{
    class Program
    {
        // static volatile bool stop; // without optimization
        static int stop; // with JIT optimization

        static void Main(string[] args)
        {
            Thread thread = new Thread(Function);
            thread.Start();

            Thread.Sleep(2000);

            Thread.VolatileWrite(ref stop, 1);
            Console.WriteLine("Main: Wait for second thread is complete");
            thread.Join();
        }

        static void Function()
        {
            int x = 0;

            while (Thread.VolatileRead(ref stop) == 1)
            {
                x++;
            }

            Console.WriteLine("Second thread has been stoped with x = {0}", x);
        }
    }
}
