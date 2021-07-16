using System;
using NUnit.Framework;

namespace Algorithms
{
    public class LinkedLists
    {
        public class MyNode
        {
            public int data;
            public MyNode next;

            public MyNode(int data)
            {
                this.data = data;
                this.next = null;
            }
        }

        public class MyLinkedList
        {
            MyNode head;

            public void append(int data)
            {
                if (head == null)
                {
                    head = new MyNode(data);
                    return;
                }

                MyNode nodeToAppend = new MyNode(data);
                MyNode current = head;
                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = nodeToAppend;
            }

            public void prepend(int data)
            {
                MyNode newHeadNode = new MyNode(data);
                newHeadNode.next = head;
                head = newHeadNode;
            }

            public void traverse()
            {
                MyNode current = head;
                while (current != null)
                {
                    Console.WriteLine(current.data);
                    current = current.next;
                }
            }

            public void deleteFirstNodeWithValue(int data)
            {
                if (head == null) return;
                
                MyNode current = head;
                MyNode previous = head; // temp value

                while (current != null)
                {
                    if (current.data == data)
                    {
                        if (current == head)
                        {
                            head = current.next;
                            return;
                        }
                        else
                        {
                            previous.next = current.next;
                            return;
                        }
                    }

                    previous = current;
                    current = current.next;
                }
            }
        }

        [Test]
        public void MainTest()
        {
            MyLinkedList myLinkedList = new MyLinkedList();
            myLinkedList.append(1);
            myLinkedList.append(2);
            myLinkedList.append(3);
            myLinkedList.append(4);
            myLinkedList.traverse();
            myLinkedList.deleteFirstNodeWithValue(3);
            myLinkedList.traverse();
            myLinkedList.prepend(9);
            myLinkedList.prepend(8);
            myLinkedList.traverse();
        }
    }
}