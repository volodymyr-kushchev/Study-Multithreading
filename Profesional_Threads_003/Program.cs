using System;
using System.Threading;

namespace Profesional_Threads_003
{
    class Program
    {
        [ThreadStatic] // TLS - Thread Local Storage for save
        public static int counter;

        [ThreadStatic]
        static string greeting = "Greetings from the current thread";

        public static void Method()
        {
            if (counter < 50)
            {
                counter++;
                Console.WriteLine(counter + " - START --- " + Thread.CurrentThread.GetHashCode());

                Thread thread = new Thread(Method);
                thread.Start();
                thread.Join();
            }

            Console.WriteLine("Thread {0} is completed", Thread.CurrentThread.GetHashCode());
        }

        static void Main(string[] args)
        {
            //Thread thread = new Thread(Method);
            //thread.Start();
            //thread.Join();

            Console.WriteLine(greeting); // prints initial value  
            greeting = "Goodbye from the main thread";
            Thread t = new Thread(ThreadMethod);
            t.Start();
            t.Join();
            Console.WriteLine(greeting); // prints the main thread's copy  
            Console.ReadKey();
        }

        static void ThreadMethod()
        {
            Console.WriteLine(greeting); // prints nothing as greeting initialized on main thread  
            greeting = "Hello from the second thread"; // only affects the second thread's copy  
            Console.WriteLine(greeting);
        }
    }
}
