using System;

namespace KangarooProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            const int x1 = 0;
            const int v1 = 3;
            const int x2 = 4;
            const int v2 = 2;
            string result = Kangaroo(x1, v1, x2, v2);
            Console.WriteLine($"result = {result}");
        }

        private static string Kangaroo(int x1, int v1, int x2, int v2)
        {
            if (x1 == x2 && v1 == v2)
            {
                return "YES";
            }

            if (x1 != x2 && v1 == v2)
            {
                return "NO";
            }

            double ratio = (double)(x2 - x1) / (v1 - v2);

            if (ratio < 0)
            {
                return "NO";
            }

            bool dividesEvenly = (x2 - x1) % (v1 - v2) == 0;
            
            return dividesEvenly ? "YES" : "NO";
        }
    }
}
