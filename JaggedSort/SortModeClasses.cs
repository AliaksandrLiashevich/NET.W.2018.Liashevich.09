
namespace JaggedArraySorts
{
    public interface IComparer
    {
        bool Compare(int a, int b);
    }

    public class AscendingSortMode: IComparer 
    {
        public bool Compare(int a, int b)
        {
            return a > b;
        }
    }

    public class DescendingSortMode : IComparer
    {
        public bool Compare(int a, int b)
        {
            return a < b;
        }
    }
}