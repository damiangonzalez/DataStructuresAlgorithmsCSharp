using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=1uIwiIjw1fw&list=PLI1t_8YX-Apv-UiRlnZwqqrRT8D1RhriX&index=14
    public class SolveRansomNoteUsingHashTables
    {
        public static bool canBuildRansomNote(string[] magazineWords, string[] noteWords)
        {
            Dictionary<string, int> magazineHash = getStringHash(magazineWords);
            Dictionary<string, int> noteHash = getStringHash(noteWords);
            return hasEnough(magazineHash, noteHash);
        }

        private static bool hasEnough(Dictionary<string, int> magazineHash, Dictionary<string, int> noteHash)
        {
            foreach (KeyValuePair<string, int> keyValuePair in noteHash)
            {
                if (!magazineHash.ContainsKey(keyValuePair.Key) ||
                    magazineHash[keyValuePair.Key] < noteHash[keyValuePair.Key])
                {
                    return false;
                }
            }

            return true;
        }

        private static Dictionary<string, int> getStringHash(string[] strings)
        {
            Dictionary<string, int> hashResult = new Dictionary<string, int>();
            foreach (string str in strings)
            {
                if (hashResult.ContainsKey(str))
                {
                    hashResult[str]++;
                }
                else
                {
                    hashResult.Add(str, 1);
                }
            }

            return hashResult;
        }

        [Test]
        public void MainTest()
        {
            string[] magazine = new[] {"hello", "world", "blah"};
            string[] note = new[] {"hello", "world", "world"};
            Assert.IsFalse(canBuildRansomNote(magazine, note));
            
            string[] magazine2 = new[] {"hello", "world", "world", "something"};
            string[] note2 = new[] {"hello", "world", "world"};
            Assert.IsTrue(canBuildRansomNote(magazine2, note2));
        }
    }
}