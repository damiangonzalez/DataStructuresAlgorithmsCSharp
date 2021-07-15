using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=IhJGJG-9Dx8&list=PLI1t_8YX-Apv-UiRlnZwqqrRT8D1RhriX&index=1
    public class BalancedParenthesesInExpression
    {
        static char[] curlyPair = new[] {'{', '}'};
        static char[] parensPair = new[] {'(', ')'};
        static char[] squarePair = new[] {'[', ']'};

        public static bool IsBalanced(string expression)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char ch in expression)
            {
                if (IsOpenChar(ch))
                {
                    stack.Push(ch);
                }
                else if (IsMatchingCloseForTopOfStack(ch, stack))
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }

            return (stack.Count == 0);
        }

        private static bool IsMatchingCloseForTopOfStack(char ch, Stack<char> stack)
        {
            if (stack.Count == 0)
                return false;
            char topOfStack = stack.Peek();
            return (ch == curlyPair[1] && topOfStack == curlyPair[0]) ||
                   (ch == parensPair[1] && topOfStack == parensPair[0]) ||
                   (ch == squarePair[1] && topOfStack == squarePair[0]);
        }

        private static bool IsOpenChar(char ch)
        {
            return ch == curlyPair[0] ||
                   ch == parensPair[0] ||
                   ch == squarePair[0];
        }

        [TestCase("()", true)]
        [TestCase("[]", true)]
        [TestCase("{}", true)]
        [TestCase("{[()]}", true)]
        [TestCase("{[(]}", false)]
        [TestCase("{[()]}}", false)]
        [TestCase("(", false)]
        [TestCase(")", false)]
        [TestCase("", true)]
        [TestCase("abc", false)]
        public void MainTest(string testExpression, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, IsBalanced(testExpression));
        }
    }
}