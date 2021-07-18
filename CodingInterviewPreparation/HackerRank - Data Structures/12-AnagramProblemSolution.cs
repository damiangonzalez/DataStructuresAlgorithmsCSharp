using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Algorithms
{
    public class AnagramProblemSolution
    {
        public int numberNeeded(string firstString, string secondString)
        {
            Dictionary<char, int> firstStringDict = new Dictionary<char, int>();
            Dictionary<char, int> secondStringDict = new Dictionary<char, int>();

            BuildDictionaryForString(firstString, firstStringDict);
            BuildDictionaryForString(secondString, secondStringDict);

            int changesNeeded = 0;
            // for each key that exists on only one side, increment by one
            int keysOnlyInFirst = firstStringDict.Where(x => !secondStringDict.ContainsKey((char) x.Key)).Select(x => x.Value).Sum();
            int keysOnlyInSecond = secondStringDict.Where(x => !firstStringDict.ContainsKey((char) x.Key)).Select(x => x.Value).Sum();
            // for each count that differs, increment by one
            changesNeeded = keysOnlyInFirst + keysOnlyInSecond;
            List<KeyValuePair<char, int>> keysInBoth =
                firstStringDict.Where(x => secondStringDict.ContainsKey(x.Key)).ToList();
            foreach (KeyValuePair<char, int> keyValuePair in keysInBoth)
            {
                if (firstStringDict[keyValuePair.Key] != secondStringDict[keyValuePair.Key])
                {
                    changesNeeded += Math.Abs(firstStringDict[keyValuePair.Key] - secondStringDict[keyValuePair.Key]);
                }
            }

            return changesNeeded;
        }

        private static void BuildDictionaryForString(string firstString, Dictionary<char, int> firstStringDict)
        {
            foreach (char character in firstString)
            {
                if (firstStringDict.ContainsKey(character))
                {
                    firstStringDict[character]++;
                }
                else
                {
                    firstStringDict.Add(character, 1);
                }
            }
        }

        [Test]
        public void MainTest()
        {
            Assert.AreEqual(6, numberNeeded("hello", "billion"));
            Assert.AreEqual(2, numberNeeded("glue", "legs"));
            Assert.AreEqual(2, numberNeeded("candy", "day"));
        }
    }
}