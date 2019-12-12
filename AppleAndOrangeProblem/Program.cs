using System;

namespace AppleAndOrangeProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            const int s = 7;
            const int t = 11;
            const int a = 5;
            const int b = 15;
            int[] apples = {-2, 2, 1};
            int[] oranges = {5, -6};
            CountApplesAndOranges(s, t, a, b, apples, oranges);
            Console.WriteLine();
        }

        private static void CountApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int lenApples = apples.Length;
            int lenOranges = oranges.Length;
            int appleCount = 0;
            int orangeCount = 0;
            int position;

            for (int n = 0; n < lenApples; n++)
            {
                position = a + apples[n];

                if (s <= position && position <= t)
                {
                    appleCount++;
                }
            }

            for (int n = 0; n < lenOranges; n++)
            {
                position = b + oranges[n];

                if (s <= position && position <= t)
                {
                    orangeCount++;
                }
            }

            Console.WriteLine($"{appleCount}");
            Console.WriteLine($"{orangeCount}");
        }
    }
}
