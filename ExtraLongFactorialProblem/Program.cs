using System;
using System.Numerics;

namespace ExtraLongFactorialProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int n = 4;
            ExtraLongFactorials(n);

            n = 25;
            ExtraLongFactorials(n);
        }

        private static void ExtraLongFactorials(int n)
        {
            BigInteger factorial = 1;

            for (int m = 1; m < n; m++)
            {
                factorial *= new BigInteger(m + 1);
            }

            Console.WriteLine(factorial);
        }
    }
}
