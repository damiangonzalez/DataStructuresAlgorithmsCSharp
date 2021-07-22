using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
    // https://betterprogramming.pub/crack-the-top-40-c-data-structure-questions-5a71608f33ec
    public class RemoveEvenIntegers
    {
        public static int[] RemoveEven(int[] array)
        {
            List<int> resultList = new List<int>();
            foreach (int item in array)
            {
                if (item % 2 != 0)
                {
                    resultList.Add(item);
                }
            }

            return resultList.ToArray();
        }

        // public static void Main()
        [Test]
        public void Main()
        {
            int[] array = new[] {1, 2, 3, 5, 6, 7, 8, 8, 10};
            int[] result = RemoveEven(array);
            foreach (int item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine((1 == array[0]) ? "true" : "false");
        }
    }
}