using System;
using System.Collections.Generic;

namespace BestDivisorProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int n = 12;
            int bestDivisor = GetBestDivisor(n);                        // 6
            Console.WriteLine($"bestDivisor = {bestDivisor}");

            n = 239;
            bestDivisor = GetBestDivisor(n);                            // 239
            Console.WriteLine($"bestDivisor = {bestDivisor}");
        }

        private static int GetBestDivisor(int n)
        {
            List<int> divisors = GetAllDivisors(n);
            int bestDivisor = 1;

            foreach (int divisor in divisors)
            {
                bestDivisor = GetBestDivisor(bestDivisor, divisor);
            }

            return bestDivisor;
        }

        private static int GetBestDivisor(int divisor1, int divisor2)
        {
            int divisorDigitSum1 = SumDigits(divisor1);
            int divisorDigitSum2 = SumDigits(divisor2);

            if (divisorDigitSum1 == divisorDigitSum2)
            {
                return Math.Min(divisor1, divisor2);
            }

            if (divisorDigitSum1 > divisorDigitSum2)
            {
                return divisor1;
            }

            return divisor2;
        }

        private static int SumDigits(int n)
        {
            string digitString = n.ToString();
            int digitSum = 0;

            foreach (char digit in digitString)
            {
                string d = digit.ToString();
                digitSum += Convert.ToInt32(d);
            }

            return digitSum;
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
