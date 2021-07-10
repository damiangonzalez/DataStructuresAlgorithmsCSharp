using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://ankitsharmablogs.com/merge-sort-algorithm-in-c-sharp/
    // https://www.csharpstar.com/merge-sort-csharp-program/
    // https://www.khanacademy.org/computing/computer-science/algorithms/merge-sort/a/overview-of-merge-sort
    // The below is from CTCI page 147
    public class MergeSort
    {
        public void mergeSort(int[] array)
        {
            int[] helper = new int[array.Length];
            mergeSort(array, helper, 0, array.Length - 1);
        }

        public void mergeSort(int[] array, int[] helper, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                mergeSort(array, helper, low, middle);
                mergeSort(array, helper, middle + 1, high);
                merge(array, helper, low, middle, high);
            }
        }

        public void merge(int[] array, int[] helper, int low, int middle, int high)
        {
            for (int i = low; i <= high; i++)
            {
                helper[i] = array[i];
            }

            int helperLeft = low;
            int helperRight = middle + 1;
            int current = low;

            while (helperLeft <= middle && helperRight <= high)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    array[current] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    array[current] = helper[helperRight];
                    helperRight++;
                }

                current++;
            }

            int remainingLeft = middle - helperLeft;
            for (int i = 0; i <= remainingLeft; i++)
            {
                array[current + i] = helper[helperLeft + i];
            }
        }

        [Test] // static void Main(string[] args)
        public void MainTest()
        {
            int[] array = new[] {2, 1, 3};
            mergeSort(array);
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}