using System;
using System.Collections.Generic;

namespace NonDivisbleSubsetProblem
{
    // todo not finished
    internal static class Program
    {
        internal static void Main()
        {
            int value;
            int count = 0;

            value = 3;
            List<int> set = new List<int> {1, 7, 2, 4};
            count = NonDivisibleSubset(count, set);
            Console.WriteLine($"count = {count}");
        }

        private class Pair
        {
            public int X1;
            public int X2;
        }

        private static int NonDivisibleSubset(int value, List<int> set)
        {
            List<Pair> pairList = new List<Pair>();
            int len = set.Count;

            for (int n1 = 0; n1 < len; n1++)
            {
                for (int n2 = 0; n2 < len; n2++)
                {
                    bool condition = n1 < n2;

                    if (!condition)
                    {
                        continue;
                    }

                    bool isDivisible = (n1 + n2) % value == 0;

                    if (isDivisible)
                    {
                        continue;
                    }

                    Pair pair = new Pair
                    {
                        X1 = n1, 
                        X2 = n2
                    };

                    pairList.Add(pair);
                }
            }

            return 0;
        }
    }
}
