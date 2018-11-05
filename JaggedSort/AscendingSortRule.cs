namespace JaggedArraySorts
{
    public interface IComparer
    {
        bool Compare(int a, int b);
    }

    public class AscendingSortRule : IComparer 
    {
        public bool Compare(int a, int b)
        {
            return a > b;
        }
    }
}