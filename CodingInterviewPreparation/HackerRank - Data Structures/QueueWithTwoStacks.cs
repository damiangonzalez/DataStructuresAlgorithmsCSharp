using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=7ArHz8jPglw&list=PLI1t_8YX-Apv-UiRlnZwqqrRT8D1RhriX&index=2
    public class QueueWithTwoStacks
    {
        public class MyQueueWithTwoStacks<T>
        {
            private Stack<T> stackNewestOnTop = new Stack<T>();
            private Stack<T> stackOldestOnTop = new Stack<T>();

            public void enqueue(T item) // add item to start of queue
            {
                stackNewestOnTop.Push(item);
            }

            public T peek() // return (but do not remove) oldest item in queue
            {
                shiftStacks(); // move elements from stack newest to oldest
                return stackOldestOnTop.Peek();
            }

            private void shiftStacks()
            {
                if (stackOldestOnTop.Count == 0)
                {
                    while (stackNewestOnTop.Count > 0)
                    {
                        stackOldestOnTop.Push(stackNewestOnTop.Pop());
                    }
                }
            }

            public T dequeue() // return and remove oldest item in queue
            {
                shiftStacks(); // move elements from stack newest to oldest
                return stackOldestOnTop.Pop();
            }
        }

        [Test]
        public void MainTest()
        {
            MyQueueWithTwoStacks<int> myQueueWithTwoStacks = new MyQueueWithTwoStacks<int>();
            myQueueWithTwoStacks.enqueue(1);
            Assert.AreEqual(1, myQueueWithTwoStacks.peek());
            Assert.AreEqual(1, myQueueWithTwoStacks.peek());
            Assert.AreEqual(1, myQueueWithTwoStacks.dequeue());
            Assert.Throws<System.InvalidOperationException>(() => myQueueWithTwoStacks.peek());
            myQueueWithTwoStacks.enqueue(1);
            myQueueWithTwoStacks.enqueue(2);
            myQueueWithTwoStacks.enqueue(3);
            myQueueWithTwoStacks.enqueue(4);
            myQueueWithTwoStacks.enqueue(5);
            Assert.AreEqual(1, myQueueWithTwoStacks.dequeue());
            Assert.AreEqual(2, myQueueWithTwoStacks.dequeue());
            Assert.AreEqual(3, myQueueWithTwoStacks.dequeue());
            Assert.AreEqual(4, myQueueWithTwoStacks.dequeue());
            Assert.AreEqual(5, myQueueWithTwoStacks.dequeue());
        }
    }
}