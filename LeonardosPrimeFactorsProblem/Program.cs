using System.Collections.Generic;
using static System.Console;

namespace LeonardosPrimeFactorsProblem
{
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

        private static int PrimeCount(long number)
        {
            int maximumPrimeFactors = 0;

            for (int n = 2; n <= number; n++)
            {
                int numberPrimeFactors = GetPrimeFactorsCount(n);

                if (numberPrimeFactors > maximumPrimeFactors)
                {
                    maximumPrimeFactors = numberPrimeFactors;
                    WriteLine($"n = {n}, maximumPrimeFactors = {maximumPrimeFactors}");
                }
            }

            return maximumPrimeFactors;
        }

        private static int GetPrimeFactorsCount(long number)
        {
            if (number == 1)
            {
                return 0;
            }

            List<int> primeFactors = new List<int>();

            for (int divisor = 2; divisor <= number; divisor++)
            {
                while (number % divisor == 0)
                {
                    if (!primeFactors.Contains(divisor))
                    {
                        primeFactors.Add(divisor);
                    }

                    number /= divisor;
                }
            }

            return primeFactors.Count;
        }
    }
}
