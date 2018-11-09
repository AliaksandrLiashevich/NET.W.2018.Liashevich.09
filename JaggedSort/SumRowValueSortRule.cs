using System.Linq;

namespace JaggedArraySorts
{
    /// <summary>
    /// General interface for creation sort criteria classes
    /// </summary>
    public interface ICriterion
    {
        int Calculate(int[] array);
    }

    /// <summary>
    /// Sort criteria: max value in the row
    /// </summary>
    public class SumRowValueSortRule : ICriterion
    {
        public int Calculate(int[] array)
        {
            return array.Sum();
        }
    }
}