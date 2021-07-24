using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=SLauY6PpjW4&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=7
    public class Quicksort
    {
        public class Solution
        {
            public static int[] quickSort(int[] arrayInput)
            {
                if (arrayInput.Length == 0)
                    return arrayInput;
                
                quickSort(arrayInput, 0, arrayInput.Length - 1);
                return arrayInput;
            }

            private static void quickSort(int[] arrayInput, int left, int right)
            {
                int index = processSwaps(arrayInput, left, right);
                Console.WriteLine($"{left} {right} {index}");

                if (index - 1 > left)
                {
                    quickSort(arrayInput, left, index - 1);
                }

                if (index < right)
                {
                    quickSort(arrayInput, index, right);
                }
            }

            private static int processSwaps(int[] arrayInput, int left, int right)
            {
                int pivot = arrayInput[(left + right) / 2];

                while (left < right)
                {
                    while (left < arrayInput.Length && arrayInput[left] < pivot) left++;
                    while (right >= 0 && arrayInput[right] > pivot) right--;

                    if (left <= right)
                    {
                        int temp = arrayInput[left];
                        arrayInput[left] = arrayInput[right];
                        arrayInput[right] = temp;
                        left++;
                        right--;
                    }
                }

                return left;
            }
        }

        [TestCase(new int[] {2, 1, 4, 3}, new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {2, 1, 3}, new int[] {1, 2, 3})]
        [TestCase(new int[] {2, 1}, new int[] {1, 2})]
        [TestCase(new int[] {2}, new int[] {2})]
        [TestCase(new int[] { }, new int[] { })]
        public void MainTest(int[] input, int[] expectedOutput)
        {
            Assert.AreEqual(expectedOutput, Solution.quickSort(input));
        }
    }
}