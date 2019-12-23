using System;
using System.Numerics;

namespace SumVersusXorProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            long number = 0;
            long count = SumXor(number);
            Console.WriteLine($"count = {count}");

            number = 4;
            count = SumXor(number);                         // 4
            Console.WriteLine($"count = {count}");

            number = 5;
            count = SumXor(number);                         // 2
            Console.WriteLine($"count = {count}");

            number = 10;
            count = SumXor(number);                         // 4
            Console.WriteLine($"count = {count}");

            number = 1_000_000_000_000_000;
            count = SumXor(number);                         // 1073741824
            Console.WriteLine($"count = {count}");
        }

        private static long SumXor(long number)
        {
            // The justification is that the xor simulates binary addition without the carry over to the next digit.
            // For the zero digits of n you can either add a 1 or 0 without getting a carry which implies xor = +
            // whereas if a digit in n is 1 then the matching digit in x is forced to be 0 on order to avoid carry.
            // For each 0 in n in the matching digit in x can either being a 1 or 0 with a total combination count of 2 ^ (num of zero).

            long zeroCount = 0;

            while (number > 0)
            {
                bool isEven = number % 2 == 0;

                if (isEven)
                {
                    zeroCount++;
                }

                number /= 2;
            }

            long count = (long) Math.Pow(2, zeroCount);

            return count;
        }

        private static long SumXor2(long number)
        {
            int count = 0;
            BigInteger bigNumber = new BigInteger(number);

            for (BigInteger n = 0; n <= bigNumber; n++)
            {
                BigInteger sum = bigNumber + n;
                BigInteger xor = bigNumber ^ n;

                if (sum == xor)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
