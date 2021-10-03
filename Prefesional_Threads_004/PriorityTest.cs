using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prefesional_Threads_004
{
    public class PriorityTest
    {
        bool loopSwitch;

        public PriorityTest()
        {
            loopSwitch = true;
        }

        public bool LoopSwitch
        {
            set { loopSwitch = value; }
        }

        public void ThreadMethod()
        {
            long threadCount = 0;

            while (loopSwitch)
            {
                threadCount++;
            }

            Console.WriteLine("{0} with {1,11} priority has a count = {2,13}",
                Thread.CurrentThread.Name,
                Thread.CurrentThread.Priority.ToString(),
                threadCount.ToString("N0"));
        }
    }
}
