namespace JaggedArraySorts
{
    /// <summary>
    /// Custom interface instead of internal IComparer 
    /// </summary>
    public interface IComparer
    {
        bool Compare(int a, int b);
    }

    /// <summary>
    /// Sets the ascending sort mode
    /// </summary>
    public class AscendingSortRule : IComparer 
    {
        public bool Compare(int a, int b)
        {
            return a > b;
        }
    }
}