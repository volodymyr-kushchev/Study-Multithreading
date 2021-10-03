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
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7"
            };
            Console.WriteLine(String.Join(Environment.NewLine, numbers.MyExtention()));
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
