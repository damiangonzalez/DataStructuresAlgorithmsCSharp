using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=Ifwf3DBN1sc&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=3
    public class SolveIceCreamParlorUsingBinarySearch
    {
        public class Solution
        {
            public static int[] findChoices(int[] menu, int money)
            {
                int[] sortedMenu = (int[]) menu.Clone();
                Array.Sort(sortedMenu);
                for (int i = 0; i < sortedMenu.Length; i++)
                {
                    int complement = money - sortedMenu[i];
                    int location = Array.BinarySearch(sortedMenu, i + 1, sortedMenu.Length - i - 1, complement);
                    if (location >= 0 && location < sortedMenu.Length && sortedMenu[location] == complement)
                    {
                        int[] indices = getIndicesFromValues(menu, sortedMenu[i], complement);
                        return indices;
                    }
                }

                return null;
            }

            private static int[] getIndicesFromValues(int[] menu, int value1, int value2)
            {
                int index1 = GetIndexOf(menu, value1, -1);
                int index2 = GetIndexOf(menu, value2, index1);

                return new[] {Math.Min(index1, index2), Math.Max(index1, index2)};
            }

            private static int GetIndexOf(int[] menu, int value1, int exceptThisIndex)
            {
                for (int i = 0; i < menu.Length; i++)
                {
                    if (menu[i] == value1 && i != exceptThisIndex)
                    {
                        return i;
                    }
                }

                return -1;
            }
        }

        [Test]
        public void MainTest()
        {
            int[] setOfPrices = new[] {2, 7, 13, 5, 4, 13, 5};
            Assert.AreEqual(new[] {3, 6}, Solution.findChoices(setOfPrices, 10));
            int[] setOfPrices2 = new[] {2, 7, 13, 5, 4, 8, 5};
            Assert.AreEqual(new[] {0, 5}, Solution.findChoices(setOfPrices2, 10));
        }
    }
}