using System;

namespace DivisibleSumPairsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int n = 6;
            int k = 3;
            int[] array = {1, 3, 2, 6, 1, 2};
            int count = DivisibleSumPairs(n, k, array);                 // 5
            Console.WriteLine($"count = {count}");

            n = 6;
            k = 5;
            array = new[] {1, 2, 3, 4, 5, 6};
            count = DivisibleSumPairs(n, k, array);                     // 3
            Console.WriteLine($"count = {count}");
        }

        private static int DivisibleSumPairs(int n, int k, int[] array)
        {
            int len = array.Length;
            int count = 0;

            for (int n1 = 0; n1 < len; n1++)
            {
                for (int n2 = 0; n2 < len; n2++)
                {
                    if (n1 >= n2)
                    {
                        continue;
                    }

                    bool dividesEvenly = (array[n1] + array[n2]) % k == 0;

                    if (dividesEvenly)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
