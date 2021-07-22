using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=R4Nh-EgWjyQ&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=6
    public class SolveConnectedCellsUsingDFS
    {
        public class Solution
        {
            // find the largest region of connected ones
            public static int getBiggestRegion(int[,] matrix)
            {
                int maxRegion = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int column = 0; column < matrix.GetLength(1); column++)
                    {
                        if (matrix[row,column] == 1)
                        {
                            maxRegion = Math.Max(maxRegion, getRegionSize(matrix, row, column));
                        }
                    }
                }

                return maxRegion;
            }

            private static int getRegionSize(int[,] matrix, int row, int column)
            {
                if (row < 0 ||
                    column < 0 ||
                    row >= matrix.GetLength(0) ||
                    column >= matrix.GetLength(1) ||
                    matrix[row,column] != 1)
                {
                    return 0;
                }

                int regionSize = 1;
                matrix[row,column] = 2; // unique value to indicate that this cell has been traversed

                for (int newRow = row - 1; newRow <= row + 1; newRow++)
                {
                    for (int newColumn = column - 1; newColumn <= column + 1; newColumn++)
                    {
                        if (newRow != row || newColumn != column)
                        {
                            regionSize += getRegionSize(matrix, newRow, newColumn);
                        }
                    }
                }

                return regionSize;
            }
        }

        [Test]
        public void MainTest()
        {
            int[,] matrix =
            {
                {0, 0, 0, 1, 1, 0, 0},
                {0, 1, 0, 0, 1, 1, 0},
                {1, 1, 0, 1, 0, 0, 1},
                {0, 0, 0, 0, 0, 1, 0},
                {1, 1, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 0, 0, 0},
            };
            
            Assert.AreEqual(7, Solution.getBiggestRegion(matrix));
            
            int[,] matrix2 =
            {
                {0, 0, 0, 1, 1, 0, 0},
                {0, 1, 0, 0, 1, 1, 0},
                {1, 1, 1, 1, 0, 0, 1},
                {0, 0, 0, 0, 0, 1, 0},
                {1, 1, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 0, 0, 0},
            };
            
            Assert.AreEqual(11, Solution.getBiggestRegion(matrix2));

        }
    }
}