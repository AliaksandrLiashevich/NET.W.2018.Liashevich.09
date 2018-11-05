namespace JaggedArraySorts
{
    public class DescendingSortRule : IComparer
    {
        public bool Compare(int a, int b)
        {
            return a < b;
        }
    }
}