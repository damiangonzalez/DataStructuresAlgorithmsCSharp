using System;
using System.Collections.Generic;
using System.Net.Sockets;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=vlYZb68kAY0&list=PLI1t_8YX-Apv-UiRlnZwqqrRT8D1RhriX&index=8
    public class SolveContactsUsingTries
    {
        public class TriesNode
        {
            private static int numberOfLetters = 26; 
            TriesNode[] children = new TriesNode[numberOfLetters];
            private int count = 0;

            private int getAlphaIndexOf(char c)
            {
                return c - 'a';
            }
            
            private TriesNode getNode(char c)
            {
                return children[getAlphaIndexOf(c)];
            }

            private void setNode(char c, TriesNode node)
            {
                if (getNode(c) == null)
                {
                    Console.WriteLine($"New setNode: {c} {node.count}");

                    children[getAlphaIndexOf(c)] = node;
                }
                else
                {
                    Console.WriteLine($"Already exists setNode: {c} {node.count}");
                }
            }

            public void add(string s)
            {
                add(s, 0);
            }
            
            public void add(string s, int indexInString)
            {
                if (s.Length == indexInString) return;
                count++;
                
                char currentChar = s[indexInString];
                Console.WriteLine($"New char add: {currentChar} {indexInString}");

                TriesNode node = getNode(currentChar);
                if (node == null)
                {
                    node = new TriesNode();
                    setNode(currentChar, node);
                }
                else
                {
                    Console.WriteLine($"Node exists: {currentChar} {node.count}");
                }

                node.add(s, indexInString + 1);
            }

            public int findCount(string s)
            {
                return findCount(s, 0);
            }
            
            public int findCount(string s, int index)
            {
                if (s.Length == index)
                    return count;
                
                TriesNode node = getNode(s[index]);
                if (node == null)
                {
                    return 0;
                }
                
                return node.findCount(s, index + 1);
            }
        }

        [Test]
        public void MainTest()
        {
            TriesNode main = new TriesNode();
            main.add("damian");
            main.add("david");
            main.add("dog");
            
            Assert.AreEqual(3, main.findCount("d"));
            Assert.AreEqual(2, main.findCount("da"));
            Assert.AreEqual(1, main.findCount("dav"));
        }
    }
}