using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=zaBhtODEL0w&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=14
    public class GraphSearchDfsAndBfs
    {
        public class Graph
        {
            private Dictionary<int, Node> nodeLookup = new Dictionary<int, Node>();

            public class Node
            {
                public int id;
                public List<Node> adjacent = new List<Node>();

                private Node(int id)
                {
                    this.id = id;
                }
            }

            private Node getNode(int id)
            {
                return nodeLookup[id];
            }

            public void addEdge(int source, int destination)
            {
                Node sourceNode = getNode(source);
                Node destNode = getNode(destination);
                sourceNode.adjacent.Add(destNode);
            }

            public bool hasPathDfs(int source, int destination)
            {
                Node sourceNode = getNode(source);
                Node destNode = getNode(destination);
                HashSet<int> visited = new HashSet<int>();
                return hasPathDfs(source, destination, visited);
            }

            public bool hasPathDfs(int source, int destination, HashSet<int> visited)
            {
                if (source == destination) return true;
                
                if (!visited.Contains(source))
                {
                    Node current = getNode(source);
                    visited.Add(source);
                    foreach (Node node in current.adjacent)
                    {
                        return hasPathDfs(node.id, destination, visited);
                    }
                }

                return false;
            }

            public bool hasPathBfs(int source, int destination)
            {
                Node sourceNode = getNode(source);
                Node destNode = getNode(destination);
                Queue<Node> nextToVisit = new Queue<Node>();
                HashSet<int> visited = new HashSet<int>();
                nextToVisit.Enqueue(sourceNode);
                while (nextToVisit.Any())
                {
                    Node current = nextToVisit.Dequeue();
                    if (!visited.Contains(current.id))
                    {
                        visited.Add(current.id);
                        if (current.id == destination)
                        {
                            return true;
                        }

                        foreach (Node node in current.adjacent)
                        {
                            nextToVisit.Enqueue(node);
                        }
                    }
                }

                return false;
            }
        }

        [Test]
        public void MainTest()
        {
            // todo implement tests
        }
    }
}