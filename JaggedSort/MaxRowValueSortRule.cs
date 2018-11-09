using System.Linq;

namespace JaggedArraySorts
{
    /// <summary>
    /// Sort criteria: max value in the row
    /// </summary>
    public class MaxRowValueSortRule : ICriterion
    {
        public int Calculate(int[] array)
        {
            return array.Max();
        }
    }
}