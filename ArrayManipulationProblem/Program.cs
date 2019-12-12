using System;
using System.Diagnostics;

namespace ArrayManipulationProblem
{
    internal class Program
    {
        internal static void Main()
        {
            int[][] queries = 
            {
                new[] {1, 2, 100},
                new[] {2, 5, 100},
                new[] {3, 4, 100}
            };
            const int n = 5;
            Stopwatch stopwatch = new Stopwatch();
            long maxItem = ArrayManipulation1(n, queries);                   // 200
            long ticks = stopwatch.ElapsedTicks;
            Console.WriteLine($"maxItem = {maxItem}, ticks = {ticks}");

            stopwatch = new Stopwatch();
            maxItem = ArrayManipulation2(n, queries);                       // 200
            ticks = stopwatch.ElapsedTicks;
            Console.WriteLine($"maxItem = {maxItem}, ticks = {ticks}");
        }

        private static long ArrayManipulation1(int n, int[][] queries)
        {
            long[] array = new long[n + 1];
            long maxItem = long.MinValue;

            foreach (int[] query in queries)
            {
                int index1 = query[0];
                int index2 = query[1];
                int value = query[2];

                for (int i = index1; i <= index2; i++)
                {
                    array[i] += value;

                    if (array[i] > maxItem)
                    {
                        maxItem = array[i];
                    }
                }
            }

            return maxItem;
        }

        private static long ArrayManipulation2(int n, int[][] queries)
        {
            long[] array = new long[n + 1];
            long maxItem = long.MinValue;

            foreach (int[] query in queries)
            {
                int index1 = query[0];
                int index2 = query[1];
                int value = query[2];

                for (int i = index1; i <= index2; i++)
                {
                    array[i] += value;
                }
            }

            foreach (long value in array)
            {
                if (value > maxItem)
                {
                    maxItem = value;
                }
            }

            return maxItem;
        }
    }
}
