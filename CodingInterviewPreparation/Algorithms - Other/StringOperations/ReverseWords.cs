using System;
using System.Text;
using NUnit.Framework;

namespace Algorithms.StringOperations
{
    // https://ankitsharmablogs.com/csharp-coding-questions-for-technical-interviews/
    public class ReverseWords
    {
        public static string ReverseTheWords(string str)
        {
            if (str == null || string.IsNullOrWhiteSpace(str)) return str;

            string[] words = str.Split(" ");
            StringBuilder reversedSentence = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--)
            {
                reversedSentence.Append(words[i] + " ");
            }

            return reversedSentence.ToString().Trim();
        }

        // public static void Main()
        [Test]
        public void ReverseString()
        {
            Console.WriteLine(ReverseTheWords("Welcome to Csharp corner").Equals("corner Csharp to Welcome"));
            Console.WriteLine(ReverseTheWords("").Equals(""));
            Console.WriteLine(ReverseTheWords(null) == null);
            Console.WriteLine(ReverseTheWords("a").Equals("a"));
            Console.WriteLine(ReverseTheWords("abc def").Equals("def abc"));
        }
    }
}