using System;
using System.Drawing;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=t0Cq6tVNRBA&list=PLI1t_8YX-Apv-UiRlnZwqqrRT8D1RhriX&index=10
    public class Heaps
    {
        private int numItems = 0;
        private int capacity = 10;
        private int[] items = new int[10];

        private int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int getParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private bool hasLeftChild(int index)
        {
            return getLeftChildIndex(index) < numItems;
        }

        private bool hasRightChild(int index)
        {
            return getRightChildIndex(index) < numItems;
        }

        private bool hasParent(int index)
        {
            return getParentIndex(index) >= 0;
        }

        private int leftChild(int index)
        {
            return items[getLeftChildIndex(index)];
        }

        private int rightChild(int index)
        {
            return items[getRightChildIndex(index)];
        }

        private int parent(int index)
        {
            return items[getParentIndex(index)];
        }

        private void swap(int firstIndex, int secondIndex)
        {
            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        private void ensureExtraCapacity()
        {
            if (numItems == capacity)
            {
                capacity = capacity * 2;
                Array.Resize(ref items, capacity);
            }
        }

        public int peek()
        {
            if (numItems == 0)
            {
                throw new Exception();
            }

            return items[0];
        }

        public int poll()
        {
            if (numItems == 0)
            {
                throw new Exception();
            }

            int item = items[0];
            items[0] = items[numItems - 1];
            numItems--;
            heapifyDown();
            return item;
        }

        private void heapifyDown()
        {
            int currentIndex = 0;
            while (hasLeftChild(currentIndex))
            {
                int smallerIndex = getLeftChildIndex(currentIndex);
                if (hasRightChild(currentIndex) && rightChild(currentIndex) < leftChild(currentIndex))
                {
                    smallerIndex = getRightChildIndex(currentIndex);
                }

                if (items[currentIndex] > items[smallerIndex])
                {
                    swap(currentIndex, smallerIndex);
                    currentIndex = smallerIndex;
                }
                else
                {
                    return;
                }
            }
        }

        private void heapifyUp()
        {
            int currentIndex = numItems - 1;
            while (hasParent(currentIndex) &&
                   items[currentIndex] < parent(currentIndex))
            {
                swap(currentIndex, getParentIndex(currentIndex));
                currentIndex = getParentIndex(currentIndex);
            }
        }

        public void PrintHeap()
        {
            for (int i = 0; i < numItems; i++)
            {
                Console.Write($"{items[i]} ");
            }

            Console.WriteLine();
        }

        public void add(int item)
        {
            ensureExtraCapacity();
            items[numItems] = item;
            numItems++;
            heapifyUp();
        }

        [Test]
        public void MainTest()
        {
            Heaps myHeap = new Heaps();
            myHeap.add(10);
            myHeap.add(5);
            myHeap.add(100);
            myHeap.add(65);
            myHeap.add(88);
            myHeap.add(12);
            myHeap.add(34);
            myHeap.add(87);

            myHeap.PrintHeap();
            Console.WriteLine(myHeap.peek());
            Console.WriteLine(myHeap.poll());
            
            myHeap.PrintHeap();

        }
    }
}