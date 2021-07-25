using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
    public class MemoizationAndDynamicProgramming
    {
        public class Solution
        {
            public static int fibonacci(int n)
            {
                return fibonacci(n, new Dictionary<int, int>());
            }

            public static int fibonacci(int n, Dictionary<int, int> memo)
            {
                if (n == 0)
                    return 0;
                if (n == 1)
                    return 1;

                if (memo.ContainsKey(n))
                    return memo[n];

                int i = fibonacci(n - 1, memo) + fibonacci(n - 2, memo);
                memo.Add(n, i);
                return i;
            }
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 8)]
        [TestCase(7, 13)]
        [TestCase(8, 21)]
        public void TestMain(int n, int result)
        {
            Assert.AreEqual(result, Solution.fibonacci(n));
        }
    }
}