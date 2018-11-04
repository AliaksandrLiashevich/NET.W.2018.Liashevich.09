namespace JaggedArraySorts
{
    public static class SortCriteriaMethods
    {
        public static Criterion SumRowValue(int[] array)
        {
            return new SumRowValue().Calculate;
        }

        public static Criterion MinRowValue(int[] array)
        {
            return new MinRowValue().Calculate;
        }

        public static Criterion MaxRowValue(int[] array)
        {
            return new MaxRowValue().Calculate;
        }

    }
}