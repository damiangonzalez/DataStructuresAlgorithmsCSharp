using NUnit.Framework;

namespace Algorithms
{
    public class SolveLonleyIntegerUsingBitManipulation
    {
        public class Solution
        {
            public static int lonelyInteger(int[] array)
            {
                int result = 0;
                foreach (int item in array)
                {
                    result ^= item;
                }

                return result;
            }
        }

        [TestCase(new[] {1, 2, 1}, 2)]
        [TestCase(new[] {1, 2, 1, 2, 4, 5, 4, 6, 7, 6, 8, 7, 8}, 5)]
        public void MainTest(int[] array, int result)
        {
            Assert.AreEqual(result, Solution.lonelyInteger(array));
        }
    }
}