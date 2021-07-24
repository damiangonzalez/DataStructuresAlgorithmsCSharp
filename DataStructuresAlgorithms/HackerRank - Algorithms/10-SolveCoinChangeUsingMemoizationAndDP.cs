using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=sn0DWI-JdNA&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=10
    public class SolveCoinChangeUsingMemoizationAndDP {
        public class Solution
        {
            public static long makeChange(int[] coins, int money)
            {
                return makeChange(coins, money, 0, new Dictionary<string, long>());
            }

            public static long makeChange(int[] coins, int money, int index, Dictionary<string, long> memo)
            {
                if (money == 0)
                {
                    return 1;
                }

                if (index >= coins.Length)
                {
                    return 0;
                }

                string key = money + "_" + index;
                if (memo.ContainsKey(key))
                {
                    return memo[key];
                }
                
                int amountProvidedByThisCoin = 0;
                long ways = 0;
                while (amountProvidedByThisCoin <= money)
                {
                    int remaining = money - amountProvidedByThisCoin;
                    ways += makeChange(coins, remaining, index + 1, memo);
                    amountProvidedByThisCoin += coins[index];
                }

                memo.Add(key, ways);
                return ways;
            }
        }

        [TestCase(new int[] {1,2,3}, 1, 1)]
        [TestCase(new int[] {1,2,3}, 2, 2)]
        [TestCase(new int[] {1,2,3}, 6, 7)] // 33 321 3111 222 2211 111111 11121
        public void MainTest(int[] coins, int money, long expected)
        {
            Assert.AreEqual(expected, Solution.makeChange(coins, money));
        }
    }
}