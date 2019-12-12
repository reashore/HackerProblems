using System;
using System.Collections.Generic;

namespace RestaurantProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int l = 2;
            int b = 2;
            int maxNumberSquares = Restaurant(l, b);                            // 1
            Console.WriteLine($"maxNumberSquares = {maxNumberSquares}");

            l = 6;
            b = 9;
            maxNumberSquares = Restaurant(l, b);                                // 6
            Console.WriteLine($"maxNumberSquares = {maxNumberSquares}");

            l = 9;
            b = 10;
            maxNumberSquares = Restaurant(l, b);                                // 90
            Console.WriteLine($"maxNumberSquares = {maxNumberSquares}");

            l = 38;
            b = 751;
            maxNumberSquares = Restaurant(l, b);                                // 28538
            Console.WriteLine($"maxNumberSquares = {maxNumberSquares}");
        }

        private static int Restaurant(int l, int b)
        {
            int longSide;
            int shortSide;

            if (l > b)
            {
                longSide = l;
                shortSide = b;
            }
            else
            {
                longSide = b;
                shortSide = l;
            }

            int remainder = longSide % shortSide;
            List<int> divisors = GetAllDivisors(shortSide);
            divisors.Sort();
            int maxWidth = 0;

            foreach (int divisor in divisors)
            {
                int width = shortSide / divisor;

                if (remainder % width == 0 && width > maxWidth)
                {
                    maxWidth = width;
                }
            }

            int area = shortSide * longSide;
            int smallSquare = maxWidth * maxWidth;
            int maxSquares = area/smallSquare;

            return maxSquares;
        }

        private static List<int> GetAllDivisors(int n)
        {
            List<int> divisors = new List<int>();

            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    if (n / i == i)
                    {
                        divisors.Add(i);
                    }
                    else
                    {
                        divisors.Add(i);
                        divisors.Add(n / i);
                    }
                }
            }

            return divisors;
        }
    }
}
