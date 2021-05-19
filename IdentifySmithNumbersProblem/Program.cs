using System;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

namespace IdentifySmithNumbersProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            int number = 378;
            int result = Solve(number);                                         // 1
            WriteLine($"IsSmithNumber({number}) = {result == 1}");

            number = 4937775;
            result = Solve(number);                                             // 1
            WriteLine($"IsSmithNumber({number}) = {result == 1}");

            number = 2050918644;
            result = Solve(number);                                             // 1
            WriteLine($"IsSmithNumber({number}) = {result == 1}");

            number = 73615;
            result = Solve(number);                                             // 1
            WriteLine($"IsSmithNumber({number}) = {result == 1}");

            number = 666;
            result = Solve(number);                                             // 1
            WriteLine($"IsSmithNumber({number}) = {result == 1}");
        }

        private static int Solve(int number)
        {
            List<int> primeFactorList = GetPrimeFactors(number);
            List<int> digitList = GetDigits(number);

            long sumPrimeFactors = 0;
            long sumDigits = 0;

            foreach (int primeFactor in primeFactorList)
            {
                if (primeFactor > 9)
                {
                    List<int> primeFactorDigitList = GetDigits(primeFactor);
                    int sumPrimeFactorDigitList = SumDigits(primeFactorDigitList);
                    sumPrimeFactors += sumPrimeFactorDigitList;
                }
                else
                {
                    sumPrimeFactors += primeFactor;
                }
            }

            foreach (int digit in digitList)
            {
                sumDigits += digit;
            }

            bool isSmithNumber = sumPrimeFactors == sumDigits;
            return isSmithNumber ? 1 : 0;
        }

        private static List<int> GetPrimeFactors(int number)
        {
            // https://www.thecsengineer.com/2020/11/efficient-algorithm-to-find-all-prime-factors-of-number.html

            List<int> primeFactors = new List<int>();

            while (number % 2 == 0)
            {
                primeFactors.Add(2);
                number /= 2;
            }

            for (int n = 3; n <= Math.Sqrt(number); n += 2)
            {
                while (number % n == 0)
                {
                    primeFactors.Add(n);
                    number /= n;
                }
            }

            if (number > 1)
            {
                primeFactors.Add(number);
            }

            return primeFactors;
        }

        private static List<int> GetDigits(int number)
        {
            List<int> digitList = new List<int>();

            while (number > 0)
            {
                int digit = number % 10;
                digitList.Add(digit);
                number /= 10;
            }

            digitList.Reverse();

            return digitList;
        }

        private static int SumDigits(List<int> digitList)
        {
            int sum = 0;

            foreach (var digit in digitList)
            {
                sum += digit;
            }

            return sum;
        }

        private static void Print(IEnumerable<int> array)
        {
            Write("[");

            foreach (int item in array)
            {
                Write($"{item}, ");
            }

            Write("]");
        }
    }
}
