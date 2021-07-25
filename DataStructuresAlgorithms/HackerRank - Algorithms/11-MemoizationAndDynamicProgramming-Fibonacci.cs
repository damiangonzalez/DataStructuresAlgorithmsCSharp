using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
    public class MemoizationAndDynamicProgrammingFibonacci
    {
        // https://www.youtube.com/watch?v=P8Xa2BitN3I&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=11
        public class Solution
        {
            // todo tbd
            public int paths(int[][] grid, int row, int col)
            {
                if (!IsValidCell(row, col))
                    return 0;
                if (IsEndCell(row, col))
                    return 1;

                return paths(grid, row - 1, col) +
                       paths(grid, row, col + 1);
            }

            private bool IsEndCell(int row, int col)
            {
                return true;
            }

            public bool IsValidCell(int row, int col)
            {
                // todo temp
                return true;
            }
            // 
            // paths(down) + paths(right)
        }

        [TestCase(8, 21)]
        public void TestMain(int n, int result)
        {
            // Assert.AreEqual(result, Solution.fibonacci(n));
        }
    }
}