namespace Algorithms
{
    // https://ankitsharmablogs.com/merge-sort-algorithm-in-c-sharp/
    // https://www.csharpstar.com/merge-sort-csharp-program/
    // https://www.khanacademy.org/computing/computer-science/algorithms/merge-sort/a/overview-of-merge-sort
    // The below is from CTCI page 147
    public class MergeSort
    {
        public void mergeSort(int[] array)
        {
            int[] helper = new int[array.Length];
            mergeSort(array, helper, 0, array.Length - 1);
        }

        public void mergeSort(int[] array, int[] helper, int start, int end)
        {
            
        }
    }
}