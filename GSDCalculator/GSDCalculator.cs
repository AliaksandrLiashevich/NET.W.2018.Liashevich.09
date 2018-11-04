using System;
using System.Diagnostics;


namespace GSDSearch
{
    internal delegate int GSDDelegate(int a, int b);

    public static class GSDCalculator
    {
        private static GSDDelegate GSDOfArrayNumbers;

        public static int EuclideanAlgorithm(int a, int b)
        {
            NumbersValidation(ref a, ref b);

            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }

            return a > b ? a : b;
        }

        public static int BinaryEuclideanAlgorithm(int a, int b)
        {
            NumbersValidation(ref a, ref b);

            int power = 2;

            while (a != 0 && b != 0)
            {
                if ((a & 1) == 0 && (b & 1) == 0)
                {
                    a >>= 1;
                    b >>= 1;
                    power <<= 1;
                }
                else if ((a & 1) == 0)
                {
                    a >>= 1;
                }
                else if ((b & 1) == 0)
                {
                    b >>= 1;
                }
                else
                {
                    if (a > b) a -= b;
                    else b -= a;
                }
            }

            return (a > b ? a : b) * (power >>= 1);
        }

        public static int EuclideanAlgorithm(int[] numbers, Stopwatch time)
        {
            GSDOfArrayNumbers = EuclideanAlgorithm;

            return GSDOfSeveralNumbers(numbers, time);
        }

        public static int BinaryEuclideanAlgorithm(int[] numbers, Stopwatch time)
        {
            GSDOfArrayNumbers = BinaryEuclideanAlgorithm;

            return GSDOfSeveralNumbers(numbers, time);
        }

        private static int GSDOfSeveralNumbers(int[] numbers, Stopwatch time)
        {
            if (numbers == null)
                throw new ArgumentNullException("Object cannot be null");

            if (numbers.Length == 1)
                return numbers[0];

            time.Start();

            int divider = GSDOfArrayNumbers(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
            {
                divider = GSDOfArrayNumbers(divider, numbers[i]);
            }

            time.Stop();

            return divider;
        }      

        private static void NumbersValidation(ref int a, ref int b)
        {
            if (a == int.MinValue && b == int.MinValue)
            {
                throw new ArgumentException("Int32 cannot represent int.MinValue as a positive number");
            }

            if ((a == 0 && b == int.MinValue) || (b == 0 && a == int.MinValue))
            {
                throw new ArgumentException("Int32 cannot represent int.MinValue as a positive number");
            }

            AbsValue(ref a, ref b);
        }

        private static void AbsValue(ref int a, ref int b)
        {
            ref int smaller = ref a, bigger = ref b;

            if (smaller > bigger)
            {
                bigger = a;
                smaller = b;
            }

            smaller %= bigger;

            smaller = Math.Abs(smaller);
            bigger = Math.Abs(bigger);
        }
    }
}
