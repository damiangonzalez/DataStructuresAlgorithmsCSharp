using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://ankitsharmablogs.com/searching-algorithms-in-c-sharp/
    // https://www.csharpstar.com/binary-search-csharp/
    public class BinarySearch
    {
        public static int BinarySearchRecursive(int[] inputArray, int key, int min, int max)
        {
            if (min > max)
            {
                return -1;
            }

            int mid = min + ((max - min) / 2);
            if (inputArray[mid] == key)
            {
                return mid + 1;
            }
            else if (key < inputArray[mid])
            {
                return BinarySearchRecursive(inputArray, key, min, mid - 1);
            }
            else
            {
                return BinarySearchRecursive(inputArray, key, mid + 1, max);
            }
        }

        public static int BinarySearchIterative(int[] inputArray, int key, int min, int max)
        {
            if (min > max)
            {
                return -1;
            }

            while (min <= max)
            {
                int mid = min + ((max - min) / 2);
                if (inputArray[mid] == key)
                {
                    return mid + 1;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else if (key > inputArray[mid])
                {
                    min = mid + 1;
                }
                else
                {
                    return -1;
                }
            }

            return -1;
        }

        [Test] // static void Main(string[] args)
        public void MainTest()
        {
            int[] array = new[] {1, 3, 4, 5, 6, 7, 8};
            Console.WriteLine(BinarySearchRecursive(array, 7, 0, array.Length - 1));
            Console.WriteLine(BinarySearchRecursive(array, 1, 0, array.Length - 1));
            Console.WriteLine(BinarySearchRecursive(array, 8, 0, array.Length - 1));
            Console.WriteLine(BinarySearchRecursive(array, 9, 0, array.Length - 1));

            Console.WriteLine(BinarySearchIterative(array, 7, 0, array.Length - 1));
            Console.WriteLine(BinarySearchIterative(array, 1, 0, array.Length - 1));
            Console.WriteLine(BinarySearchIterative(array, 8, 0, array.Length - 1));
            Console.WriteLine(BinarySearchIterative(array, 9, 0, array.Length - 1));
        }
    }
}