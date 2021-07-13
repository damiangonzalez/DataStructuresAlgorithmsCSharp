using System.Collections.Generic;
using Algorithms.Data_Structures;

namespace Algorithms
{
    // https://www.csharpstar.com/csharp-program-to-detect-a-cycle-in-a-linkedlist/
    // This can be visualized by thinking of a Monopoly board game. Let’s have a look at the implementation in C#.
    // Write a function to detect a cycle in a linked list
    // The problem can be visualized by thinking of a Monopoly board game.  The squares the players land
    // on are like the nodes and the players are like the lag and lead pointers.  If you move the 
    // players at constant varying speeds (one player moves up one square and another player moves up
    // two squares) they will eventually land on the same square proving they are traveling in a circle.
    public class DetectCycleInLinkedlist
    {
        public class LinkedListForCycle
        {
            private LinkedList.Node head;
            private HashSet<LinkedList.Node> visitedNodes = new HashSet<LinkedList.Node>();

            public bool HasCycle()
            {
                return false;
            }
        }
    }
}