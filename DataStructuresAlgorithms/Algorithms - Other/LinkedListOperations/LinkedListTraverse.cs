using System;
using NUnit.Framework;

namespace Algorithms.LinkedListOperations
{
    // https://www.csharpstar.com/csharp-singly-linkedlist-traversal/
    public class LinkedListTraverse
    {
        public class SingleLinkedList
        {
            private int data;
            private SingleLinkedList next;

            public SingleLinkedList(int data)
            {
                this.data = data;
                this.next = null;
            }

            public SingleLinkedList InsertNext(int data)
            {
                SingleLinkedList nextNode = new SingleLinkedList(data);
                if (this.next == null)
                {
                    nextNode.next = null;
                    this.next = nextNode;
                }
                else
                {
                    SingleLinkedList temp = this.next;
                    nextNode.next = temp;
                    this.next = nextNode;
                }

                return nextNode;
            }

            public int DeleteNext()
            {
                if (this.next == null)
                {
                    return 0;
                }
                else
                {
                    SingleLinkedList node = this.next;
                    this.next = this.next.next;
                    node = null;
                    return 1;
                }
            }

            public void Traverse(SingleLinkedList node)
            {
                var startingNode = node ?? this;
                while (startingNode != null)
                {
                    Console.WriteLine(startingNode.data);
                    startingNode = startingNode.next;
                }
            }
        }

        [Test] 
        public void MainTest()
        {
            Console.WriteLine("Starting Linked List...");
            SingleLinkedList node1 = new SingleLinkedList(100);
            SingleLinkedList node2 = node1.InsertNext(200);
            SingleLinkedList node3 = node2.InsertNext(300);
            SingleLinkedList node4 = node3.InsertNext(400);
            SingleLinkedList node5 = node4.InsertNext(500);
            Console.WriteLine("Traversing Linked List...");
            node1.Traverse(null);
            Console.WriteLine("Deleting from Linked List...");
            node3.DeleteNext();
            node2.Traverse(null);
        }
    }
}