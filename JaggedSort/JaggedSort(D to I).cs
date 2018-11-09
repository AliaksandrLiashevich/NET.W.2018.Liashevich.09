namespace JaggedArraySorts
{
    public class JaggedSortDToI
    {
        /// <summary>
        /// Method that sorts jagged array of integers.
        /// </summary>
        /// <param name="array">Jagged array of integers</param>
        /// <param name="criterion">Delegate of sort criteria</param>
        /// <param name="mode">Delegate of sort mode (ASC | DESC)</param>
        /// <remarks>Сlosure to method with interfaces ICriterion, IComparer </remarks>>
        public static void Sort(ref int[][] array, Criterion criterion, Mode mode)
        {
            Sort(ref array, (ICriterion)criterion.Target, (IComparer)mode.Target);
        }

        /// <summary>
        /// Method that sorts jagged array of integers.
        /// </summary>
        /// <param name="array">Jagged array of integers</param>
        /// <param name="criterion">Interface of sort criteria</param>
        /// <param name="compare">Interface of sort mode (ASC | DESC)</param>
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

        /// <summary>
        /// Custom swap for jagged array rows
        /// </summary>
        /// <param name="arr1">First row</param>
        /// <param name="arr2">Second row</param>
        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
    }
}
