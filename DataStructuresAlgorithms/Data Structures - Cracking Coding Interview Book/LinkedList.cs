namespace Algorithms
{
    public class LinkedList
    {
        public class Node
        {
            internal int data;
            public Node next;

            public Node(int d)
            {
                data = d;
                next = null;
            }

            public int getData()
            {
                return data;
            }
        }
    }
}