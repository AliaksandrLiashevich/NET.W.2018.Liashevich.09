using System.Linq;

namespace JaggedArraySorts
{
    public interface ICriterion
    {
        int Calculate(int[] array);
    }

    public class SumRowValue: ICriterion
    {
        public int Calculate(int[] array)
        {
            return array.Sum();
        }
    }

    public class MinRowValue : ICriterion
    {
        public int Calculate(int[] array)
        {
            return array.Min();
        }
    }

    public class MaxRowValue : ICriterion
    {
        public int Calculate(int[] array)
        {
            return array.Max();
        }
    }
}