using NUnit.Framework;

namespace Algorithms
{
    public class BinarySearchHr
    {
        public class Solution
        {
            public static bool binarySearchRecursive(int[] array, int value, int startIndex, int endIndex)
            {
                if (startIndex > endIndex)
                {
                    return false;
                }

                int midpoint = (startIndex + endIndex) / 2;

                if (value == array[midpoint])
                {
                    return true;
                }
                else if (value < array[midpoint])
                {
                    return binarySearchRecursive(array, value, startIndex, midpoint - 1);
                }
                else
                {
                    return binarySearchRecursive(array, value, midpoint + 1, endIndex);
                }
            }

            public static bool binarySearchRecursive(int[] array, int value)
            {
                return binarySearchRecursive(array, value, 0, array.Length);
            }
        }

        [Test]
        public void MainTest()
        {
            int[] array = new[] {1, 2, 3, 4, 6, 7, 8, 9};
            Assert.IsTrue(Solution.binarySearchRecursive(array, 2));
            Assert.IsFalse(Solution.binarySearchRecursive(array, 5));
        }
    }
}