using System;
using System.Diagnostics;

namespace GCDSearch
{
    internal delegate int GСDDelegate(int a, int b);

    public static class GСDCalculator
    {
        private static GСDDelegate gсdOfArrayNumbers;

        /// <summary>
        /// Method realizes Euclidean Algorithm of GSD search
        /// for two integer numbers
        /// </summary>
        /// <param name="a">First integer number</param>
        /// <param name="b">Second integer number</param>
        /// <returns>Integer number that represents GCD</returns>
        public static int EuclideanAlgorithm(int a, int b)
        {
            NumbersValidation(ref a, ref b);

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a + b;
        }

        /// <summary>
        /// Method realizes Binary Euclidean Algorithm of GSD search
        /// for two integer numbers
        /// </summary>
        /// <param name="a">First integer number</param>
        /// <param name="b">Second integer number</param>
        /// <returns>Integer number that represents GCD</returns>
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
                    if (a > b)
                    {
                        a -= b;
                    }
                    else
                    {
                        b -= a;
                    }
                }
            }

            return (a + b) * (power >>= 1);
        }

        /// <summary>
        /// Method realizes Euclidean Algorithm of GSD search
        /// for array of integer numbers and calculates elapsed time
        /// </summary>
        /// <param name="numbers">array of integer numbers</param>
        /// <param name="time">instance of diagnostic class for calculation elapsed time</param>
        /// <returns>Integer number that represents GCD</returns>
        public static int EuclideanAlgorithm(int[] numbers, Stopwatch time)
        {
            gсdOfArrayNumbers = EuclideanAlgorithm;

            return GSDOfSeveralNumbers(numbers, time);
        }

        /// <summary>
        /// Method realizes Binary Euclidean Algorithm of GSD search
        /// for array of integer numbers and calculates elapsed time
        /// </summary>
        /// <param name="numbers">array of integer numbers</param>
        /// <param name="time">instance of diagnostic class for calculation elapsed time</param>
        /// <returns>Integer number that represents GCD</returns>
        public static int BinaryEuclideanAlgorithm(int[] numbers, Stopwatch time)
        {
            gсdOfArrayNumbers = BinaryEuclideanAlgorithm;

            return GSDOfSeveralNumbers(numbers, time);
        }

        /// <summary>
        /// General method that contains common logics for calculation GCD of integer array.
        /// Used by EuclideanAlgorithm and BinaryEuclideanAlgorithm
        /// </summary>
        /// <param name="numbers">array of integer numbers</param>
        /// <param name="time">instance of diagnostic class for calculation elapsed time</param>
        /// <returns>Integer number that represents GCD</returns>
        /// <remarks>Used by EuclideanAlgorithm and BinaryEuclideanAlgorithm</ remarks>
        private static int GCDOfSeveralNumbers(int[] numbers, Stopwatch time)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Object cannot be null");
            }

            if (numbers.Length == 1)
            {
                return numbers[0];
            }

            time.Start();

            int divider = gсdOfArrayNumbers(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
            {
                divider = gсdOfArrayNumbers(divider, numbers[i]);
            }

            time.Stop();

            return divider;
        }

        /// <summary>
        /// Method validates input paremeters for some constraints
        /// </summary>
        /// <param name="a">First integer number</param>
        /// <param name="b">Second integer number</param>
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

        /// <summary>
        /// Method gets abs value of integer numbers
        /// </summary>
        /// <param name="a">First integer number</param>
        /// <param name="b">Second integer number</param>
        /// <remarks>Helper for method NumbersValidation</remarks>
        /// <remarks>This method is created instead of internal Math.Abs
        /// to avoid exception and handle the situation when one of 
        /// the arguments = int.MinValue. Because -int.MinValue = int.MaxValue + 1 
        /// and so in this case Math.Abs(int.MinValue) give an exception.
        /// </remarks>>
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
