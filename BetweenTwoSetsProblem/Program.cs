using System;
using System.Collections.Generic;

namespace BetweenTwoSetsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            List<int> a = new List<int>{2, 6};
            List<int> b = new List<int>{24, 36};
            int betweenSetCount = GetBetweenSetCount(a, b);                     // 2
            Console.WriteLine($"betweenSetCount = {betweenSetCount}");

            a = new List<int>{2, 4};
            b = new List<int>{16, 32, 96};
            betweenSetCount = GetBetweenSetCount(a, b);                         // 3
            Console.WriteLine($"betweenSetCount = {betweenSetCount}");

            a = new List<int>{1};
            b = new List<int>{100};
            betweenSetCount = GetBetweenSetCount(a, b);                         // 9
            Console.WriteLine($"betweenSetCount = {betweenSetCount}");
        }

        private static int GetBetweenSetCount(List<int> aList, List<int> bList)
        {
            int maxItem = 0;
            List<int> divisorList = new List<int>();

            foreach (int item in bList)
            {
                if (item > maxItem)
                {
                    maxItem = item;
                }
            }

            for (int divisor = 1; divisor <= maxItem; divisor++)
            {
                bool trueForAll1 = aList.TrueForAll(item => divisor % item == 0);
                
                if (!trueForAll1)
                {
                    continue;
                }

                bool trueForAll2 = bList.TrueForAll(item => item % divisor == 0);

                if (!trueForAll2)
                {
                    continue;
                }

                divisorList.Add(divisor);
            }

            return divisorList.Count;
        }
    }
}
