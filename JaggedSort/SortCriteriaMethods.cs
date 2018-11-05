namespace JaggedArraySorts
{
    public static class SortCriteriaMethods
    {
        public static Criterion SumRowValue(int[] array)
        {
            return new SumRowValueSortRule().Calculate;
        }

        public static Criterion MinRowValue(int[] array)
        {
            return new MinRowValueSortRule().Calculate;
        }

        public static Criterion MaxRowValue(int[] array)
        {
            return new MaxRowValueSortRule().Calculate;
        }
    }
}