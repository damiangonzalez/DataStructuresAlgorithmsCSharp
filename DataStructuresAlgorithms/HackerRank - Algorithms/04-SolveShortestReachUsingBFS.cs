using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=0XgVhsMOcQM&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=4
    /*
     * Breadth-First Search (BFS)
     * BFS is a bit less intuitive, and many interviewees struggle with the implementation
     * unless they are already familiar with it. The main tripping point is the (false)
     * assumption that BFS is recursive. It's not. Instead, it uses a queue. In BFS, node a
     * visits each of a's neighbors before visiting any of their neighbors.
     * You can think of this as searching level by level out from a.
     * An iterative solution involving a queue usually works best.
     */
    // https://www.hackerrank.com/challenges/ctci-bfs-shortest-reach/problem?h_r=internal-search
    // BFS also here: DataStructuresAlgorithms/DataStructuresAlgorithms/Algorithms - Cracking Coding Interview Book/BreadthFirstSearch.cs
    public class SolveShortestReachUsingBFS
    {
        public class Solution
        {
            public class Node
            {
                public int value;
                public List<int> neighbors;

                public Node(int value)
                {
                    this.value = value;
                    this.neighbors = new List<int>();
                }
            }

            public class Graph
            {
                private Node[] nodes;
                private static int EDGE_DISTANCE = 6;

                public Graph(int size)
                {
                    this.nodes = new Node[size];
                    for (int i = 0; i < size; i++)
                    {
                        nodes[i] = new Node(i);
                    }
                }

                public void addEdge(int first, int second)
                {
                    this.nodes[first].neighbors.Add(second);
                }

                public int[] shortestReach(int startId)
                {
                    Queue<int> queue = new Queue<int>();
                    queue.Enqueue(startId);

                    int[] distances = new int[nodes.Length];
                    Array.Fill(distances, -1);

                    distances[startId] = 0;

                    while (queue.Count > 0)
                    {
                        int current = queue.Dequeue();
                        foreach (var neighbor in nodes[current].neighbors)
                        {
                            if (distances[neighbor] == -1)
                            {
                                distances[neighbor] = distances[current] + EDGE_DISTANCE;
                                queue.Enqueue(neighbor);
                            }
                        }
                    }

                    return distances;
                }
            }

            [Test]
            public void MainTest()
            {
                Graph myGraph = new Graph(5);
                myGraph.addEdge(4, 2);
                myGraph.addEdge(1, 2);
                myGraph.addEdge(1, 3);
                Assert.AreEqual(new int[] {-1, 0, 6, 6, -1}, myGraph.shortestReach(1));

                Graph myGraph2 = new Graph(4);
                myGraph2.addEdge(3, 1);
                myGraph2.addEdge(2, 3);
                Assert.AreEqual(new int[] {-1, 12, 0, 6}, myGraph2.shortestReach(2));
            }
        }
    }
}