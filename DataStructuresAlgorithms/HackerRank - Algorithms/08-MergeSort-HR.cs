using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=KF2j-9iSf4Q&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=8
    public class MergeSortHR
    {
        public void mergeSort(int[] array)
        {
            int[] temp = new int[array.Length];
            mergeSort(array, temp, 0, array.Length - 1);
        }

        private void mergeSort(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            if (leftStart < rightEnd)
            {
                int middlePoint = (leftStart + rightEnd) / 2;

                mergeSort(array, temp, leftStart, middlePoint);
                mergeSort(array, temp, middlePoint + 1, rightEnd);

                mergeHalves(array, temp, leftStart, rightEnd);
            }
        }

        public static void mergeHalves(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            int leftEnd = (leftStart + rightEnd) / 2;
            int rightStart = leftEnd + 1;
            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStart;
            int index = leftStart;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (array[left] <= array[right])
                {
                    temp[index] = array[left];
                    left++;
                }
                else
                {
                    temp[index] = array[right];
                    right++;
                }

                index++;
            }

            int remainingLeft = leftEnd - left;
            for (int i = 0; i <= remainingLeft; i++)
            {
                temp[index + i] = array[left + i];
            }

            int remainingRight = rightEnd - right;
            for (int i = 0; i <= remainingRight; i++)
            {
                temp[index + i] = array[right + i];
            }

            for (int i = leftStart; i <= rightEnd; i++)
            {
                array[i] = temp[i];
            }
        }

        [TestCase(new int[] {2, 1, 4, 3}, new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {2, 1, 3}, new int[] {1, 2, 3})]
        [TestCase(new int[] {2, 1}, new int[] {1, 2})]
        [TestCase(new int[] {2}, new int[] {2})]
        [TestCase(new int[] { }, new int[] { })]
        public void MainTest(int[] input, int[] expectedOutput)
        {
            mergeSort(input);
            Assert.AreEqual(expectedOutput, input);
        }
    }
}