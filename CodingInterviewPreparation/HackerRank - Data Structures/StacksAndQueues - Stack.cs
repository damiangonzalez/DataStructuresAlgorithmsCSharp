using NUnit.Framework;

namespace Algorithms
{
    public class StacksAndQueuesStack
    {
        // https://www.youtube.com/watch?v=wjI1WNcIntg&list=PLI1t_8YX-Apv-UiRlnZwqqrRT8D1RhriX&index=3
        public class MyStack
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

            private Node head; // remove and add here

            public bool isEmpty()
            {
                return head == null;
            }

            public int peek()
            {
                // check for null
                return head.data;
            }

            public void push(int data)
            {
                Node node = new Node(data);
                if (head != null)
                {
                    Node oldHead = head;
                    head = node;
                    head.next = oldHead;
                }
                else
                {
                    head = node;
                }
            }

            public int pop()
            {
                if (head != null)
                {
                    int returnValue = head.data;
                    head = head.next; // assign new head
                    
                    return returnValue;
                }

                return 0;
            }
        }

        [Test]
        public void TestMain()
        {
            MyStack myStack = new MyStack();
            myStack.push(1);
            Assert.AreEqual(1, myStack.peek());
            myStack.push(2);
            Assert.AreEqual(2, myStack.peek());
            myStack.push(3);
            Assert.AreEqual(3, myStack.peek());
            Assert.AreEqual(3, myStack.pop());
            Assert.AreEqual(2, myStack.pop());
            Assert.AreEqual(1, myStack.pop());
        }
    }
}