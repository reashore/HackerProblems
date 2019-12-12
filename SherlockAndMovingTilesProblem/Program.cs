using System;
using System.Collections.Generic;

namespace SherlockAndMovingTilesProblem
{
    internal class Program
    {
        internal static void Main()
        {
            int l = 10;
            int s1 = 1;
            int s2 = 2;
            int[] queries = {50, 100};
            double[] results = MovingTiles(l, s1, s2, queries);
            Console.WriteLine();

            l = 1_000_000;
            s1 = 1_000_004;
            s2 = 1_000_003;
            long[] queries2 = { 258385599125 , 248989464296 };
            results = MovingTiles(l, s1, s2, queries);
            Console.WriteLine();
        }

        private static double[] MovingTiles(int l, int s1, int s2, int[] queries)
        {
            List<double> results = new List<double>();

            if (s1 > s2)
            {
                int temp = s1;
                s1 = s2;
                s2 = temp;
            }

            int diff = s2 - s1;
            double factor = Math.Sqrt(2) / diff;

            foreach (int query in queries)
            {
                double result = factor * (Math.Sqrt(query) - l);

                if (result < 0)
                {
                    result = -result;
                }

                results.Add(result);
            }

            return results.ToArray();
        }
    }
}
