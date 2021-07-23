using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://ankitsharmablogs.com/merge-sort-algorithm-in-c-sharp/
    // https://www.csharpstar.com/merge-sort-csharp-program/
    // https://www.khanacademy.org/computing/computer-science/algorithms/merge-sort/a/overview-of-merge-sort

    // The below is from CTCI page 147
    // Merge Sort I Runtime: 0 ( n log ( n)) average and worst case. Memory: Depends.
    // Merge sort divides the array in half, sorts each of those halves, and then merges them back together.
    // Each of those halves has the same sorting algorithm applied to it. Eventually, you are merging just two
    // single­ element arrays. It is the "merge" part that does all the heavy lifting.
    // The merge method operates by copying all the elements from the target array segment into a helper array,
    // keeping track of where the start of the left and right halves should be (helperleft and helperRight).
    // We then iterate through helper, copying the smaller element from each half into the array. At the end,
    // we copy any remaining elements into the target array.
    // You may notice that only the remaining elements from the left half of the helper array are copied into the
    // target array. Why not the right half? The right half doesn't need to be copied because it's already there.
    // Consider, for example, an array like [ 1, 4, 5 11 2, 8, 9] (the"11"indicates the partition point).
    // Prior to merging the two halves, both the helper array and the target array segment will end with [ 8, 9].
    // Once wecopyoverfourelements(1, 4, 5,and2)intothetargetarray,the[8, 9]willstillbeinplaceinboth arrays.
    // There's no need to copy them over.
    // The space complexity of merge sort is 0(n) due to the auxiliary space used to merge parts of the array.
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