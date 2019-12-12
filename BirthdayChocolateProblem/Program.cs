using System;
using System.Collections.Generic;

namespace BirthdayChocolateProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            List<int> s = new List<int> {2, 2, 1, 3, 2};
            int d = 4;
            int m = 2;
            int count = BirthdayChocolate(s, d, m);                         // 2
            Console.WriteLine($"count = {count}");

            s = new List<int> {1, 2, 1, 3, 4};
            d = 3;
            m = 2;
            count = BirthdayChocolate(s, d, m);                             // 2
            Console.WriteLine($"count = {count}");

            s = new List<int> {1, 1, 1, 1, 1, 1};
            d = 3;
            m = 2;
            count = BirthdayChocolate(s, d, m);                             // 0
            Console.WriteLine($"count = {count}");
        }

        private static int BirthdayChocolate(List<int> s, int d, int m)
        {
            int len = s.Count;
            int count = 0;

            for (int n = 0; n < len; n++)
            {
                int sum = 0;

                for (int l = 0; n + l < len; l++)
                {
                    sum += s[n + l];

                    if (sum == d && l + 1 == m)
                    {
                        count++;
                        break;
                    }
                }
            }

            return count;
        }
    }
}
