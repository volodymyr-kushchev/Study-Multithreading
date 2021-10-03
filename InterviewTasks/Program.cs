using System;
using System.Collections.Generic;

namespace InterviewTasks
{
    public static class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = new List<string>()
            {
                "ewjfrjeifjo1",
                "ewjfrjeifjo2",
                "ewjfrjeifjo3",
                "ewjfrjeifjo4",
                "ewjfrjeifjo5",
                "ewjfrjeifjo6",
                "ewjfrjeifjo7"
            };
            Console.WriteLine(String.Join("\n", numbers.MyExtention(0)));
        }

        public static IEnumerable<T> MyExtention<T>(this IEnumerable<T> collection, ushort eachNext = 3)
        {
            ushort innerCounter = eachNext;

            foreach (T record in collection)
            {
                if (innerCounter++ == eachNext)
                {
                    yield return record;
                    innerCounter = 1;
                }
            }
        }
    }


}
