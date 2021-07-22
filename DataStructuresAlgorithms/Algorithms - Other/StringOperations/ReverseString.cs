using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms.StringOperations
{
    // https://ankitsharmablogs.com/csharp-coding-questions-for-technical-interviews/
    public class Reverse
    {
        static string ReverseString(string str)
        {
            if (str == null) return null;

            char[] input = str.ToCharArray();
            List<char> outputChars = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[input.Length - i - 1];
                outputChars.Add(currentChar);
            }

            return new string(outputChars.ToArray());
        }
        
        //     public static void Main()
        [Test]
        public void ReverseString()
        {
            Console.WriteLine(ReverseString(null) == null);
            Console.WriteLine(ReverseString("").Equals(""));
            Console.WriteLine(ReverseString("a").Equals("a"));
            Console.WriteLine(ReverseString("abc").Equals("cba"));
        }
    }
}