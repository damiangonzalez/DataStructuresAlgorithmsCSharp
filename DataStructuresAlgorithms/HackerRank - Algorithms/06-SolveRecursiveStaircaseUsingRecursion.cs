using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=eREiwuvzaUM&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=6
    public class SolveRecursiveStaircaseUsingRecursion
    {
        public class Solution
        {
            public static int countPathsRecursive(int steps)
            {
                if (steps < 0)
                {
                    return 0;
                }

                if (steps == 0)
                {
                    return 1;
                }

                int paths = 0;

                paths += countPathsRecursive(steps - 1) +
                         countPathsRecursive(steps - 2) +
                         countPathsRecursive(steps - 3);

                return paths;
            }

            public static int countPathsMemo(int steps)
            {
                return countPathsMemo(steps, new int[steps + 1]);
            }

            public static int countPathsMemo(int steps, int[] memoTable)
            {
                if (steps < 0)
                {
                    return 0;
                }

                if (steps == 0)
                {
                    return 1;
                }

                if (memoTable[steps] != 0)
                {
                    return memoTable[steps];
                }

                int paths = 0;
                paths += countPathsMemo(steps - 1, memoTable) +
                         countPathsMemo(steps - 2, memoTable) +
                         countPathsMemo(steps - 3, memoTable);
                memoTable[steps] = paths;
                return paths;
            }
        }

        [TestCase(3, 4)]
        [TestCase(4, 7)]
        public void MainTest(int steps, int expectedPaths)
        {
            Assert.AreEqual(expectedPaths, Solution.countPathsRecursive(steps));
            Assert.AreEqual(expectedPaths, Solution.countPathsMemo(steps));
        }
    }
}