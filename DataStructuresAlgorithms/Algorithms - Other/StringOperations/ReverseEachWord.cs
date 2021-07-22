using System;
using System.Text;
using NUnit.Framework;

// https://ankitsharmablogs.com/csharp-coding-questions-for-technical-interviews/
namespace Algorithms.StringOperations
{
    public class ReverseEachWord
    {
        public string ReverseEachOfTheWords(string str)
        {
            if (str == null || string.IsNullOrWhiteSpace(str)) return str;

            string[] words = str.Split(" ");
            StringBuilder reversedSentence = new StringBuilder();
            foreach (string word in words)
            {
                reversedSentence.Append(ReverseTheLetters(word) + " ");
            }

            return reversedSentence.ToString().Trim();
        }

        public string ReverseTheLetters(string str)
        {
            if (str == null || string.IsNullOrWhiteSpace(str)) return str;
            StringBuilder reversedLetters = new StringBuilder();
            char[] charsInString = str.ToCharArray();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversedLetters.Append(charsInString[i].ToString());
            }

            return reversedLetters.ToString();
        }

        // public static void Main()
        [Test]
        public void ReverseString()
        {
            Console.WriteLine(ReverseEachOfTheWords("Welcome to Csharp corner").Equals("emocleW ot prahsC renroc"));
            Console.WriteLine(ReverseEachOfTheWords("").Equals(""));
            Console.WriteLine(ReverseEachOfTheWords(null) == null);
            Console.WriteLine(ReverseEachOfTheWords("a").Equals("a"));
            Console.WriteLine(ReverseEachOfTheWords("abc def").Equals("cba fed"));
        }
    }
}