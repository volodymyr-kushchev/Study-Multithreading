using System;
using System.Threading;

namespace Prefesional_Threads_004
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityTest priorityTest = new PriorityTest();
            ThreadStart startDelegate = priorityTest.ThreadMethod;

            Thread threadOne = new Thread(startDelegate);
            threadOne.Name = "ThreadOne";
            threadOne.Priority = ThreadPriority.Lowest;

            Thread threadTwo = new Thread(startDelegate);
            threadTwo.Name = "ThreadTwo";
            threadTwo.Priority = ThreadPriority.Highest;

            threadOne.Start();
            threadTwo.Start();

            Thread.Sleep(1000);

            priorityTest.LoopSwitch = false;
        }
    }
}
