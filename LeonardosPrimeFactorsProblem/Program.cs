using System.Collections.Generic;
using static System.Console;

namespace LeonardosPrimeFactorsProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            List<long> numberList = new()
            {
                1,
                2,
                3,
                100,
                500,
                5000,
                10_000_000_000
            };

            foreach (long number in numberList)
            {
                int primeCount = PrimeCount(number);
                WriteLine($"PrimeCount({number}) = {primeCount}");
            }
        }

        #region Fast solution

        private static int PrimeCount(long number)
        {
            if (number < 2)
            {
                return 0;
            }

            ulong product = 2;
            ulong prime;
            int count = 1;

            for (prime = 3; product * prime <= (ulong)number; prime += 2)
            {
                if (Gcd(product, prime) == 1)
                {
                    product *= prime;
                    count++;
                }
            }

            return count;
        }

        private static ulong Gcd(ulong n1, ulong n2)
        {
            while (n2 > 0)
            {
                ulong temp = n2;

                n2 = n1 % n2;
                n1 = temp;
            }

            return n1;
        }

        #endregion

        #region Slow Solution

        //private static int PrimeCountSlow(long number)
        //{
        //    int maximumPrimeFactors = 0;

        //    for (int n = 2; n <= number; n++)
        //    {
        //        int numberPrimeFactors = GetPrimeFactorsCount(n);

        //        if (numberPrimeFactors > maximumPrimeFactors)
        //        {
        //            maximumPrimeFactors = numberPrimeFactors;
        //            WriteLine($"n = {n}, maximumPrimeFactors = {maximumPrimeFactors}");
        //        }
        //    }

        //    return maximumPrimeFactors;
        //}

        //private static int GetPrimeFactorsCount(long number)
        //{
        //    if (number == 1)
        //    {
        //        return 0;
        //    }

        //    List<int> primeFactors = new();

        //    for (int divisor = 2; divisor <= number; divisor++)
        //    {
        //        while (number % divisor == 0)
        //        {
        //            if (!primeFactors.Contains(divisor))
        //            {
        //                primeFactors.Add(divisor);
        //            }

        //            number /= divisor;
        //        }
        //    }

        //    return primeFactors.Count;
        //}

        #endregion
    }
}
