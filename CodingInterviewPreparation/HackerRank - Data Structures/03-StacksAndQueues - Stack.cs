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

            private Node top; // remove and add here

            public bool isEmpty()
            {
                return top == null;
            }

            public int peek()
            {
                // check for null
                return top.data;
            }

            public void push(int data)
            {
                Node node = new Node(data);
                if (top != null)
                {
                    Node oldHead = top;
                    top = node;
                    top.next = oldHead;
                }
                else
                {
                    top = node;
                }
            }

            public int pop()
            {
                if (top != null)
                {
                    int returnValue = top.data;
                    top = top.next; // assign new top
                    
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