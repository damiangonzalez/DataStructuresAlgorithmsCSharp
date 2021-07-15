using NUnit.Framework;

namespace Algorithms
{
    public class StacksAndQueues
    {
        // https://www.youtube.com/watch?v=wjI1WNcIntg&list=PLI1t_8YX-Apv-UiRlnZwqqrRT8D1RhriX&index=3
        public class MyQueue
        {
            private class Node
            {
                public int data;
                public Node next;

                public Node(int data)
                {
                    this.data = data;
                    this.next = null;
                }
            }

            private Node head; // remove here
            private Node tail; // add here

            public bool isEmpty()
            {
                return head == null;
            }

            public int peek()
            {
                // check for null
                return head.data;
            }

            public void enqueue(int data)
            {
                Node node = new Node(data);
                if (tail != null)
                {
                    tail.next = node;
                }

                tail = node;

                if (head == null)
                {
                    head = node;
                }
            }

            public int dequeue()
            {
                if (head != null)
                {
                    int returnValue = head.data;
                    head = head.next;
                    if (head == null)
                    {
                        tail = null;
                    }
                    
                    return returnValue;
                }

                return 0;
            }
        }

        [Test]
        public void TestMain()
        {
            MyQueue myQueueWithTwoStacks = new MyQueue();
            myQueueWithTwoStacks.enqueue(1);
            Assert.AreEqual(1, myQueueWithTwoStacks.peek());
            Assert.AreEqual(1, myQueueWithTwoStacks.peek());
            Assert.AreEqual(1, myQueueWithTwoStacks.dequeue());
            Assert.Throws<System.NullReferenceException>(() => myQueueWithTwoStacks.peek());
            myQueueWithTwoStacks.enqueue(1);
            myQueueWithTwoStacks.enqueue(2);
            myQueueWithTwoStacks.enqueue(3);
            myQueueWithTwoStacks.enqueue(4);
            myQueueWithTwoStacks.enqueue(5);
            Assert.AreEqual(1, myQueueWithTwoStacks.dequeue());
            Assert.AreEqual(2, myQueueWithTwoStacks.dequeue());
            Assert.AreEqual(3, myQueueWithTwoStacks.dequeue());
            Assert.AreEqual(4, myQueueWithTwoStacks.dequeue());
            Assert.AreEqual(5, myQueueWithTwoStacks.dequeue());        }
    }
}