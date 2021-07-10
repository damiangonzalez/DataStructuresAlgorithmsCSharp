using System;
using System.Collections.Concurrent;
using NUnit.Framework;

namespace Algorithms
{
    // https://ankitsharmablogs.com/quick-sort-algorithm-in-c-sharp/
    // CTCI page 148
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