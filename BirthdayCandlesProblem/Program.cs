using System;

namespace BirthdayCandlesProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array = {3, 2, 1, 3};
            int maxCandles = BirthdayCakeCandles(array);                    // 2
            Console.WriteLine($"maxCandles = {maxCandles}");
        }

        private static int BirthdayCakeCandles(int[] array)
        {
            int maxCandleHeight = 0;
            int numCandles = 0;

            foreach (int item in array)
            {
                if (item > maxCandleHeight)
                {
                    maxCandleHeight = item;
                    numCandles = 1;
                }
                else if (item == maxCandleHeight)
                {
                    numCandles++;
                }
            }

            return numCandles;
        }
    }
}
