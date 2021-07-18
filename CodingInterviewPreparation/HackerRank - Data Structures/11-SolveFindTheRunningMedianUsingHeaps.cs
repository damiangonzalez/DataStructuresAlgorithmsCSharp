using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=VmogG01IjYc&list=PLI1t_8YX-Apv-UiRlnZwqqrRT8D1RhriX&index=11
    public class SolveFindTheRunningMedianUsingHeaps
    {
        public class Solution
        {
            // Min Heap
            private List<int> minHeapHighers = new List<int>();

            // Max Heap
            private List<int> maxHeapLowers = new List<int>();

            private void addToMaxHeapLowers(int value)
            {
                maxHeapLowers.Add(value);
                maxHeapLowers.Reverse();
            }

            private void addToMinHeapHighers(int value)
            {
                minHeapHighers.Add(value);
                minHeapHighers.Sort();
            }

            private int getFirstItemFromHeap(List<int> minOrMaxHeap)
            {
                int item = minOrMaxHeap.First();
                minOrMaxHeap.RemoveAt(0);
                return item;
            }

            public void addNumber(int number)
            {
                if (!this.maxHeapLowers.Any() || number < this.maxHeapLowers.First())
                {
                    addToMaxHeapLowers(number);
                }
                else
                {
                    addToMinHeapHighers(number);
                }
            }

            public void rebalance()
            {
                bool lowersIsLargerHeap = maxHeapLowers.Count > minHeapHighers.Count;
                if (lowersIsLargerHeap)
                {
                    while (maxHeapLowers.Count - minHeapHighers.Count > 1)
                    {
                        addToMinHeapHighers(getFirstItemFromHeap(maxHeapLowers));
                    }
                }
                else
                {
                    while (minHeapHighers.Count - maxHeapLowers.Count > 1)
                    {
                        addToMaxHeapLowers(getFirstItemFromHeap(minHeapHighers));
                    }
                }
            }

            public double getMedian()
            {
                rebalance();
                if (maxHeapLowers.Count == minHeapHighers.Count)
                {
                    int lowersMax = maxHeapLowers.First();
                    int highersMin = minHeapHighers.First();
                    return (double) (lowersMax + highersMin) / 2;
                }
                else if (maxHeapLowers.Count > minHeapHighers.Count)
                {
                    return (double) maxHeapLowers.First();
                }
                else
                {
                    return (double) minHeapHighers.First();
                }
            }
        }

        [Test]
        public void MainTest()
        {
            Solution solution = new Solution();
            solution.addNumber(1);
            Assert.AreEqual(1, solution.getMedian());
            solution.addNumber(2);
            solution.addNumber(3);
            solution.addNumber(4);
            Assert.AreEqual(2.5, solution.getMedian());
            solution.addNumber(5);
            Assert.AreEqual(3, solution.getMedian());
        }
    }
}