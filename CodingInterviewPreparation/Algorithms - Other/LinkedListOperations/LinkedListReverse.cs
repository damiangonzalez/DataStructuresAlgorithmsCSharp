using System;
using System.Xml;
using NUnit.Framework;

namespace Algorithms.LinkedListOperations
{
    // https://www.csharpstar.com/reverse-linked-list-in-c/
    // https://www.programcreek.com/2012/11/top-10-algorithms-for-coding-interview/
    public class LinkedListReverse
    {
        public class SingleLinkedListRev
        {
            private int data;
            private SingleLinkedListRev next;

            public SingleLinkedListRev(int data)
            {
                this.data = data;
                this.next = null;
            }

            public SingleLinkedListRev InsertNext(int data)
            {
                SingleLinkedListRev node = new SingleLinkedListRev(data);
                if (this.next == null)
                {
                    this.next = node;
                    node.next = null;
                }
                else
                {
                    SingleLinkedListRev temp = this.next;
                    this.next = node;
                    node.next = temp;
                }

                return node;
            }

            public int DeleteNext()
            {
                if (this.next == null)
                {
                    return 0;
                }
                else
                {
                    SingleLinkedListRev temp = this.next.next;
                    this.next = temp;
                    return 1;
                }
            }

            public void Traverse()
            {
                SingleLinkedListRev current = this;
                while (current != null)
                {
                    Console.WriteLine(current.data);
                    current = current.next;
                }
            }

            public SingleLinkedListRev Reverse()
            {
                if (this.next == null)
                {
                    return this;
                }
                
                SingleLinkedListRev p1 = this;
                SingleLinkedListRev p2 = p1.next;
                p1.next = null;
                while (p2 != null)
                {
                    SingleLinkedListRev p3 = p2.next;
                    p2.next = p1;
                    p1 = p2;
                    p2 = p3;
                }

                return p1;
            }
        }

        [Test] // static void Main(string[] args)
        public void MainTest()
        {
            Console.WriteLine("Starting Linked List...");
            SingleLinkedListRev node1 = new SingleLinkedListRev(100);
            SingleLinkedListRev node2 = node1.InsertNext(200);
            SingleLinkedListRev node3 = node2.InsertNext(300);
            SingleLinkedListRev node4 = node3.InsertNext(400);
            SingleLinkedListRev node5 = node4.InsertNext(500);
            Console.WriteLine("Traversing Linked List...");
            node1.Traverse();
            Console.WriteLine("Reversing Linked List...");
            SingleLinkedListRev reverseHead = node1.Reverse();
            reverseHead.Traverse();
        }
    }
}