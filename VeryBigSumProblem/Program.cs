using System;
using System.Numerics;

namespace VeryBigSumProblem
{
    internal class Program
    {
        internal static void Main()
        {
            long[] array = {1000000001, 1000000002, 1000000003, 1000000004, 1000000005};
            long sum = GetVeryBigSum(array);                    // 5000000015
            Console.WriteLine($"sum = {sum}");
        }

        private static long GetVeryBigSum(long[] ar)
        {
            BigInteger sum = 0;

            foreach (long number in ar)
            {
                BigInteger bigNumber = new BigInteger(number);
                sum += bigNumber;
            }

            string sumString = sum.ToString();
            long sumLong = Convert.ToInt64(sumString);

            return sumLong;
        }

    }
}
