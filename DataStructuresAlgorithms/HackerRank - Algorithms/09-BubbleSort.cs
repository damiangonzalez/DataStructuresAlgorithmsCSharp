using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=6Gv8vg0kcHc&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=9
    public class BubbleSort
    {
        public class Solution
        {
            public static void bubbleSort(int[] array)
            {
                bool swapOccurred = true;

                while (swapOccurred)
                {
                    swapOccurred = false;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            int temp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = temp;
                            swapOccurred = true;
                        }
                    }
                }
            }
        }

        [TestCase(new int[] {2, 1, 4, 3}, new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {2, 1, 3}, new int[] {1, 2, 3})]
        [TestCase(new int[] {2, 1}, new int[] {1, 2})]
        [TestCase(new int[] {2}, new int[] {2})]
        [TestCase(new int[] { }, new int[] { })]
        public void MainTest(int[] input, int[] expectedOutput)
        {
            BubbleSort.Solution.bubbleSort(input);
            Assert.AreEqual(expectedOutput, input);
        }
    }
}