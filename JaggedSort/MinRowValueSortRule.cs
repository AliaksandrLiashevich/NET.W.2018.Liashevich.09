using System.Linq;

namespace JaggedArraySorts
{
    /// <summary>
    /// Sort criteria: min value in the row
    /// </summary>
    public class MinRowValueSortRule : ICriterion
    {
        public int Calculate(int[] array)
        {
            return array.Min();
        }
    }
}