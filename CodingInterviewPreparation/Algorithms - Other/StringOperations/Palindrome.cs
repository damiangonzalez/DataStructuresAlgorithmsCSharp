using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms.StringOperations
{
    // https://ankitsharmablogs.com/csharp-coding-questions-for-technical-interviews/
    public class Palindrome
    {
        static bool IsPalindrome(string str)
        {
            if (str == null || string.IsNullOrEmpty(str)) return true;

            char[] input = str.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                int currentLeftCharIndex = i;
                int currentRightCharIndex = input.Length - i - 1;

                if (currentLeftCharIndex == currentRightCharIndex ||
                    currentLeftCharIndex > currentRightCharIndex)
                {
                    return true;
                }

                char currentLeftChar = input[currentLeftCharIndex];
                char currentRightChar = input[currentRightCharIndex];

                if (currentLeftChar != currentRightChar)
                {
                    return false;
                }
            }

            return false;
        }

        static bool IsPalindromeRecursive(string str)
        {
            if (str == null || string.IsNullOrEmpty(str)) return true;

            char[] charArray = str.ToCharArray();

            return CharsMatch(charArray, 0, charArray.Length - 1);
        }

        static bool CharsMatch(char[] charArray, int leftCharIndex, int rightCharIndex)
        {
            if (leftCharIndex == rightCharIndex || leftCharIndex > rightCharIndex)
            {
                return true;
            }

            if (charArray[leftCharIndex] != charArray[rightCharIndex])
            {
                return false;
            }

            return CharsMatch(charArray, leftCharIndex + 1, rightCharIndex - 1);
        }

        //     public static void Main()
        [Test]
        public void ReverseString()
        {
            Console.WriteLine(IsPalindrome(null).Equals(true));
            Console.WriteLine(IsPalindrome("").Equals(true));
            Console.WriteLine(IsPalindrome("a").Equals(true));
            Console.WriteLine(IsPalindrome("abc").Equals(false));
            Console.WriteLine(IsPalindrome("abccba").Equals(true));
            Console.WriteLine(IsPalindrome("abcba").Equals(true));

            Console.WriteLine(IsPalindromeRecursive(null).Equals(true));
            Console.WriteLine(IsPalindromeRecursive("").Equals(true));
            Console.WriteLine(IsPalindromeRecursive("a").Equals(true));
            Console.WriteLine(IsPalindromeRecursive("abc").Equals(false));
            Console.WriteLine(IsPalindromeRecursive("abccba").Equals(true));
            Console.WriteLine(IsPalindromeRecursive("abcba").Equals(true));
        }
    }
}