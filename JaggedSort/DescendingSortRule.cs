namespace JaggedArraySorts
{
    /// <summary>
    /// Sets the descending sort mode
    /// </summary>
    public class DescendingSortRule : IComparer
    {
        public bool Compare(int a, int b)
        {
            return a < b;
        }
    }
}