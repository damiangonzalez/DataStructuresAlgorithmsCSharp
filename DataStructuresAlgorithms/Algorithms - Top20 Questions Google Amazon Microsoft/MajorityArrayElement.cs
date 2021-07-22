using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
    public class MajorityArrayElement
    {
        // https://www.csharpstar.com/csharp-program-to-find-majority-element-in-an-unsorted-array/
        public static int GetMajorityElementInArray(int[] array)
        {
            Dictionary<int, int> elementsCount = new Dictionary<int, int>();

            foreach (int item in array)
            {
                if (elementsCount.ContainsKey(item))
                {
                    elementsCount[item]++;
                }
                else
                {
                    elementsCount.Add(item, 1);
                }
            }

            KeyValuePair<int, int> majorityElement = new KeyValuePair<int, int>(0,0);
            foreach (KeyValuePair<int,int> keyValuePair in elementsCount)
            {
                if (keyValuePair.Value > majorityElement.Value)
                {
                    majorityElement = keyValuePair;
                }
            }

            return majorityElement.Key;
        }
        
        [Test] // static void Main(string[] args)
        public void MainTest()
        {
            int[] array = new[] {1, 3, 2, 5, 6, 7, 8};
           Console.WriteLine(GetMajorityElementInArray(array));
           array = new[] {1, 3, 3, 5, 6, 7, 8};
           Console.WriteLine(GetMajorityElementInArray(array));
           array = new[] {1, 3, 3, 5, 5, 5, 8};
           Console.WriteLine(GetMajorityElementInArray(array));
        }
    }
}