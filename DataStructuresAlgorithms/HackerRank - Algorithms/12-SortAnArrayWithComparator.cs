namespace Algorithms
{
    // https://www.youtube.com/watch?v=SzzSwvQfKyk&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=12
    public class SortAnArrayWithComparator {

        public class Solution
        {
            public int compare(Player a, Player b)
            {
                if (a.score == b.score)
                {
                    // use the names
                    return a.name.CompareTo(b.name);
                }

                if (a.score > b.score)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            
            // simpler implementation
            public int compare2(Player a, Player b)
            {
                if (a.score == b.score)
                {
                    // use the names
                }

                return b.score - a.score;
            }
        }
    }

    public class Player
    {
        public int score;
        public string name;
    }
}