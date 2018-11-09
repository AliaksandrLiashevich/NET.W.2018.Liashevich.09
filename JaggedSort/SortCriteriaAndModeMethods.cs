namespace JaggedArraySorts
{
    /// <summary>
    /// Class for initializing sort criteria and mode delegates
    /// </summary>
    public static class SortCriteriaAndModeMethods
    {
        /// <summary>
        /// Sort criteria: sum elements of the row 
        /// </summary>
        /// <param name="array">One of the array row</param>
        /// <returns>Delegate that contains sort criteria method reference</returns>
        public static Criterion SumRowValue(int[] array)
        {
            return new SumRowValueSortRule().Calculate;
        }

        /// <summary>
        /// Sort criteria: min value of the row 
        /// </summary>
        /// <param name="array">One of the array row</param>
        /// <returns>Delegate that contains sort criteria method reference</returns>
        public static Criterion MinRowValue(int[] array)
        {
            return new MinRowValueSortRule().Calculate;
        }

        /// <summary>
        /// Sort criteria: max value of the row 
        /// </summary>
        /// <param name="array">One of the array row</param>
        /// <returns>Delegate that contains sort criteria method reference</returns>
        public static Criterion MaxRowValue(int[] array)
        {
            return new MaxRowValueSortRule().Calculate;
        }

        /// <summary>
        /// Criteria mode: ascending sort 
        /// </summary>
        /// <returns>Delegate that contains sort mode method reference</returns>
        public static Mode AscendingMode()
        {
            return new AscendingSortRule().Compare;
        }

        /// <summary>
        /// Criteria mode: descending sort 
        /// </summary>
        /// <returns>Delegate that contains sort mode method reference</returns>
        public static Mode DescendingMode()
        {
            return new DescendingSortRule().Compare;
        }
    }
}