using System.Collections.Generic;
using static System.Console;

namespace SherlockAndDivisorsProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            int number = 6;
            int factorsDivisibleByTwo = GetNumberDivisorsDivisibleByTwo(number);
            WriteLine($"GetNumberDivisorsDivisibleByTwo({number}) = {factorsDivisibleByTwo}");

            number = 8;
            factorsDivisibleByTwo = GetNumberDivisorsDivisibleByTwo(number);
            WriteLine($"GetNumberDivisorsDivisibleByTwo({number}) = {factorsDivisibleByTwo}");

            number = 9;
            factorsDivisibleByTwo = GetNumberDivisorsDivisibleByTwo(number);
            WriteLine($"GetNumberDivisorsDivisibleByTwo({number}) = {factorsDivisibleByTwo}");

            WriteLine();
            Test1();
        }

        private static int GetNumberDivisorsDivisibleByTwo(int number)
        {
            int count = 0;

            if (number == 2)
            {
                return 1;
            }

            if (number % 2 == 0)
            {
                count += 2;     // 2 and number are divisors
            }

            for (int divisor = 3; divisor <= number / 2; divisor++)
            {
                if (number % divisor == 0 && divisor % 2 == 0)
                {
                    count++;
                }
            }

            return count;
        }

        //private static int GetNumberDivisorsDivisibleByTwo(int number)
        //{
        //    int count = 0;     

        //    for (int divisor = 2; divisor <= number; divisor++)
        //    {
        //        if (number % divisor == 0 && divisor % 2 == 0)
        //        {
        //            count++;
        //        }
        //    }

        //    return count;
        //}

        private static void Test1()
        {
            List<int> expectedList = new()
            {
                0,
                1,
                0,
                2,
                0,
                2,
                0,
                3,
                0,
                2,
                0,
                4,
                0,
                2,
                0,
                4,
                0,
                3,
                0,
                4,
                0,
                2,
                0,
                6,
                0,
                2,
                0,
                4,
                0,
                4,
                0,
                5,
                0,
                2,
                0,
                6,
                0,
                2,
                0,
                6,
                0,
                4,
                0,
                4,
                0,
                2,
                0,
                8,
                0,
                3,
                0,
                4,
                0,
                4,
                0,
                6,
                0,
                2,
                0,
                8,
                0,
                2,
                0,
                6,
                0,
                4,
                0,
                4,
                0,
                4,
                0,
                9,
                0,
                2,
                0,
                4,
                0,
                4,
                0,
                8,
                0,
                2,
                0,
                8,
                0,
                2,
                0,
                6,
                0,
                6,
                0,
                4,
                0,
                2,
                0,
                10,
                0,
                3,
                0,
                6
            };
            
            for (int number = 1; number <= 100; number++)
            {
                int actual = GetNumberDivisorsDivisibleByTwo(number);
                int expected = expectedList[number - 1];

                if (actual != expected)
                {
                    WriteLine($"Failed for {number, 3}: Actual = {actual}, Expected = {expected}");
                }
                else
                {
                    WriteLine($"Passed for {number, 3}");
                }
            }
        }
    }
}
