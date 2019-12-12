using System;

namespace MinMaxProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array = {-4, 3, -9, 0, 4, 1};
            PlusMinus(array);
            Console.WriteLine();
        }

        private static void PlusMinus(int[] array)
        {
            int numItems = 0;
            int numPositive = 0;
            int numZeros = 0;
            int numNegative = 0;

            foreach (int item in array)
            {
                numItems++;

                if (item > 0)
                {
                    numPositive++;
                }
                else if (item == 0)
                {
                    numZeros++;
                }
                else if (item < 0)
                {
                    numNegative++;
                }
            }

            double fractionPositive = (double) numPositive / numItems;
            double fractionNegative = (double) numNegative / numItems;
            double fractionZero = (double) numZeros / numItems;

            Console.WriteLine($"{fractionPositive}");
            Console.WriteLine($"{fractionNegative}");
            Console.WriteLine($"{fractionZero}");
        }
    }
}
