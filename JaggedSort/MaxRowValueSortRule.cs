using System.Linq;

namespace JaggedArraySorts
{
    public class MaxRowValueSortRule : ICriterion
    {
        public int Calculate(int[] array)
        {
            return array.Max();
        }
    }
}