using System.Linq;

namespace JaggedArraySorts
{
    public interface ICriterion
    {
        int Calculate(int[] array);
    }

    public class SumRowValueSortRule : ICriterion
    {
        public int Calculate(int[] array)
        {
            return array.Sum();
        }
    }
}