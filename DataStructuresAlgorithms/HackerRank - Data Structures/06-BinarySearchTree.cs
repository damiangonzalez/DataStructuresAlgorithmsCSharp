using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=i_Q0v_Ct5lY&list=PLI1t_8YX-Apv-UiRlnZwqqrRT8D1RhriX&index=6
    public class BinarySearchTree
    {
        public class NodeBST
        {
            public int data;
            public NodeBST left;
            public NodeBST right;

            public NodeBST(int data)
            {
                this.data = data;
            }
        }

        public static class myBinarySearchTree
        {
            public static bool checkBST(NodeBST nodeBst)
            {
                bool leftOk = checkBST(nodeBst.left, Int32.MinValue, nodeBst.data);
                bool rightOk = checkBST(nodeBst.right, nodeBst.data, Int32.MaxValue);

                return leftOk && rightOk;
            }

            public static bool checkBST(NodeBST nodeBst, int min, int max)
            {
                if (nodeBst == null) return true;
                
                bool currentOk = nodeBst.data >= min && nodeBst.data <= max;
                bool leftOk = checkBST(nodeBst.left, min, nodeBst.data);
                bool rightOk = checkBST(nodeBst.right, nodeBst.data, max);

                Console.WriteLine($"{nodeBst.data} {min} {max} {currentOk} {leftOk} {rightOk}");
                return currentOk && leftOk && rightOk;
            }
        }

        [Test]
        public void MainTest()
        {
            NodeBST root = new NodeBST(50);
            
            root.left = new NodeBST(10);
            root.right = new NodeBST(80);
            
            root.left.left = new NodeBST(5);
            root.left.right = new NodeBST(30);

            root.right.left = new NodeBST(70);
            root.right.right = new NodeBST(90);

            root.left.right.left = new NodeBST(20);
            root.left.right.right = new NodeBST(40);

            root.right.right.left = new NodeBST(85);
            
            Assert.IsTrue(myBinarySearchTree.checkBST(root));
            
            root.left.right.right = new NodeBST(29);
            
            Assert.IsFalse(myBinarySearchTree.checkBST(root));
        }
    }
}