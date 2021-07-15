using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=MFOAbpfrJ8g&list=PLI1t_8YX-Apv-UiRlnZwqqrRT8D1RhriX&index=4
    public class CyclesInALinkedList
    {
        public class Node
        {
            int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }

        public bool hasCycle(Node head)
        {
            if (head == null) return false;

            Node slowPointer = head;
            Node fastPointer = head.next;

            while (fastPointer != null &&
                   slowPointer != null)
            {
                if (fastPointer == slowPointer)
                {
                    return true;
                }

                fastPointer = fastPointer.next?.next;
                slowPointer = slowPointer.next;
            }

            return false;
        }

        [Test]
        public void MainTest()
        {
            Node head = new Node(1);
            head.next = new Node(2);
            head.next.next = new Node(3);
            head.next.next.next = new Node(3);
            Assert.AreEqual(false, hasCycle(head));

            head.next.next.next.next = head.next;
            Assert.AreEqual(true, hasCycle(head));
        }
    }
}