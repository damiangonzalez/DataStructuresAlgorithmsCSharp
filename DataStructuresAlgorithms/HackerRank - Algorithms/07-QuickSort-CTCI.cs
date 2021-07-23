using System;
using System.Collections.Concurrent;
using NUnit.Framework;

namespace Algorithms
{
    // https://ankitsharmablogs.com/quick-sort-algorithm-in-c-sharp/
    // CTCI page 148
    // Quick Sort I Runtime: O(n log(n)) average, O(n2 ) worst case. Memory: 0( log(n)).
    // In quick sort we pick a random element and partition the array, such that
    // all numbers that are less than the partitioning element come before all elements that are greater than it.
    // The partitioning can be performed efficiently through a series of swaps (see below).
    // If we repeatedly partition the array (and its sub-arrays) around an element,
    // the array will eventually become sorted. However, as the partitioned element is not guaranteed to be the median
    // (or anywhere near the median), our sorting could be very slow.
    // This is the reason for the 0(n2) worst case runtime.
    public class QuickSort
    {
        public void quickSort(int[] array, int left, int right)
        {
            int index = partition(array, left, right);
            if (index - 1 > left)
            {
                quickSort(array, left, index - 1);
            }

            if (index < right)
            {
                quickSort(array, index, right);
            }
        }

        private int partition(int[] array, int left, int right)
        {
            // In this case we choose a pivot value in the middle
            int pivot = array[(left + right) / 2];

            while (left <= right)
            {
                // find item on left that needs to be swapped
                while (array[left] < pivot) left++;
                // find item on right that needs to be swapped
                while (array[right] > pivot) right--;

                if (left <= right)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                    right--;
                }
            }

            return left;
        }


        [Test] // static void Main(string[] args)
        public void MainTest()
        {
            int[] array = new[] {2, 1, 3};
            quickSort(array, 0, array.Length - 1);
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}