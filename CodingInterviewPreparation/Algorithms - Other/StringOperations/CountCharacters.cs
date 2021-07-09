using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

// https://ankitsharmablogs.com/csharp-coding-questions-for-technical-interviews/
namespace Algorithms.StringOperations
{
    public class CountCharacters
    {
        public string CharacterCount(string str)
        {
            Dictionary<char, int> charCountDictionary = new Dictionary<char, int>();
            StringBuilder outputString = new StringBuilder();
            if (str == null || string.IsNullOrWhiteSpace(str)) return str;

            foreach (char character in str)
            {
                if (charCountDictionary.ContainsKey(character))
                {
                    charCountDictionary[character]++;
                }
                else
                {
                    charCountDictionary.Add(character, 1);
                }
            }

            foreach (KeyValuePair<char,int> keyValuePair in charCountDictionary)
            {
                outputString.Append($"{keyValuePair.Key} - {keyValuePair.Value},");
            }

            return outputString.ToString();
        }

        // public static void Main()
        [Test]
        public void Main()
        {
            Console.WriteLine(CharacterCount("abaacbbc").Equals("a - 3,b - 3,c - 2,"));
            Console.WriteLine(CharacterCount("").Equals(""));
            Console.WriteLine(CharacterCount(null) == null);
            Console.WriteLine(CharacterCount("a").Equals("a - 1,"));
        }
    }
}