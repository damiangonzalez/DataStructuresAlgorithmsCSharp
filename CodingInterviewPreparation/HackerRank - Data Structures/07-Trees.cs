using System;
using System.ComponentModel;
using NUnit.Framework;

namespace Algorithms
{
    public class Trees
    {
        public class BstNode
        {
            public BstNode left, right;
            public int data;

            public BstNode(int data)
            {
                this.data = data;
            }

            public void insert(int data)
            {
                BstNode newNode = new BstNode(data);
                if (this.data > data)
                {
                    if (this.left == null)
                    {
                        this.left = newNode;
                    }
                    else
                    {
                        this.left.insert(data);
                    }
                }
                else
                {
                    if (this.right == null)
                    {
                        this.right = newNode;
                    }
                    else
                    {
                        this.right.insert(data);
                    }
                }
            }

            public bool contains(int data)
            {
                if (this.data == data)
                {
                    return true;
                }
                else
                {
                    if (data < this.data && this.left != null)
                    {
                        return this.left.contains(data);
                    }
                    else if (data > this.data && this.right != null)
                    {
                        return this.right.contains(data);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public void printInOrderSimple()
            {
                if (this.left != null)
                {
                    this.left.printInOrderSimple();
                }
                Console.WriteLine(this.data);
                if (this.right != null)
                {
                    this.right.printInOrderSimple();
                }
            }

            public void printInOrderMine(BstNode root)
            {
                if (root.left == null)
                {
                    Console.WriteLine(root.data);
                    if (root.right != null)
                    {
                        printInOrderMine(root.right);
                    }
                }
                else
                {
                    printInOrderMine(root.left);
                    Console.WriteLine(root.data);
                    if (root.right != null)
                    {
                        printInOrderMine(root.right);
                    }
                }
            }
        }

        [Test]
        public void MainTest()
        {
            BstNode root = new BstNode(50);
            root.insert(10);
            root.insert(80);
            root.insert(5);
            root.insert(30);
            root.insert(70);
            root.insert(90);
            root.insert(20);
            root.insert(40);
            root.insert(85);
            Assert.IsTrue(root.contains(30));
            Assert.IsTrue(root.contains(20));
            Assert.IsFalse(root.contains(21));
            
            root.printInOrderSimple();
            
            root.printInOrderMine(root);
        }
    }
}