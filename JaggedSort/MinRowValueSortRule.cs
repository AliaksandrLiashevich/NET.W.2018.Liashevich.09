using System.Linq;

namespace JaggedArraySorts
{
    public class MinRowValueSortRule : ICriterion
    {
        public int Calculate(int[] array)
        {
            return array.Min();
        }
    }
}