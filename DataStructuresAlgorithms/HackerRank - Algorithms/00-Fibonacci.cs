using NUnit.Framework;

namespace Algorithms
{
    public class Fibonacci {

        public class Solution
        {
            public static int fibonacci(int n)
            {
                if (n == 0)
                    return 0;
                if (n == 1)
                    return 1;
                return fibonacci(n - 1) + fibonacci(n - 2);
            }
        }

        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(2,1)]
        [TestCase(3,2)]
        [TestCase(4,3)]
        [TestCase(5,5)]
        [TestCase(6,8)]
        [TestCase(7,13)]
        [TestCase(8,21)]
        public void TestMain(int n, int result)
        {
            Assert.AreEqual(result, Fibonacci.Solution.fibonacci(n));
        }
    }
}