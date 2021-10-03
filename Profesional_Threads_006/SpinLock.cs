using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Profesional_Threads_006
{
    public class SpinLock
    {
        // флаг: 0 - блок свободен, 1 - блок занят
        int block;

        int wait;

        public SpinLock(int wait)
        {
            this.wait = wait;
        }


        public void Enter()
        {
            int result = Interlocked.CompareExchange(ref block, 1, 0);

            while (result == 1)
            {
                Thread.Sleep(wait);
                result = Interlocked.CompareExchange(ref block, 1, 0);
            }
        }

        public void Exit()
        {
            Interlocked.Exchange(ref block, 0);
        }
    }

    public class SpinLockManager: IDisposable
    {
        SpinLock block;

        public SpinLockManager(SpinLock block)
        {
            this.block = block;
            this.block.Enter();
        }

        public void Dispose()
        {
            block.Exit();
        }
    }
}
