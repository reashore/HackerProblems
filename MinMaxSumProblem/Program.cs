using System;

namespace MinMaxSumProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array = {1, 2, 3, 4, 5};
            PrintMiniMaxSum(array);                 // 10 14
        }

        private static void PrintMiniMaxSum(int[] array)
        {
            long sum = 0;
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (int item in array)
            {
                sum += item;

                if (item < min)
                {
                    min = item;
                }

                if (item > max)
                {
                    max = item;
                }
            }

            long minSum = sum - max;
            long maxSum = sum - min;

            Console.WriteLine($"{minSum} {maxSum}");
        }
    }
}
