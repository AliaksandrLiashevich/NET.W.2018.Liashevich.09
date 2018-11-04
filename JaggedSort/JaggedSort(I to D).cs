
namespace JaggedArraySorts
{
    public delegate bool Mode(int arg1, int arg2);
    public delegate int Criterion(int[] array);

    class JaggedSort
    {
        public static void Sort(ref int[][] array, ICriterion criterion, IComparer compare)
        {
            Sort(ref array, criterion.Calculate, compare.Compare);
        }

        public static void Sort(ref int[][] array, Criterion criterion, Mode mode)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (mode(criterion(array[j]), criterion(array[j + 1])))
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
