
namespace JaggedArraySorts
{
    class JaggedSortDToI
    {
        public static void Sort(ref int[][] array, Criterion criterion, Mode mode)
        {
            Sort(ref array, (ICriterion)criterion.Target, (IComparer)mode.Target);
        }

        public static void Sort(ref int[][] array, ICriterion criterion, IComparer compare)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (compare.Compare(criterion.Calculate(array[j]), criterion.Calculate(array[j + 1])))
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
    }
}
