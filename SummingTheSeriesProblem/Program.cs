using System;
using System.Numerics;

namespace SummingTheSeriesProblem
{
    internal class Program
    {
        internal static void Main()
        {
            //const long MaxValue = 9223372036854775807;

            long n = 2;
            int result = SummingSeries(n);                  // 4
            Console.WriteLine($"result = {result}");

            n = 1;
            result = SummingSeries(n);                      // 1
            Console.WriteLine($"result = {result}");

            //-------------------------------------------------------------

            long[] array =
            {
                229137999, 
                344936985, 
                681519110, 
                494844394, 
                767088309, 
                307062702, 
                306074554, 
                555026606, 
                4762607, 
                231677104
            };
            long[] expected =
            {
                218194447,
                788019571,
                43914042,
                559130432,
                685508198,
                299528290,
                950527499,
                211497519,
                425277675,
                142106856
            };

            for (int m = 0; m < array.Length; m++)
            {
                long value = SummingSeries(array[m]);

                if (value == expected[m])
                {
                    Console.WriteLine($"Passed {m}");
                }
            }

            //-------------------------------------------------------------

            array = new long[]
            {
                23918572,
                697437974,
                605819664,
                966409256,
                973431103,
                658927364,
                454510570,
                729129860,
                786555238,
                30180035
            };
            expected = new long[]
            {
                82514498,
                172286608,
                719950662,
                544845635,
                654819874,
                988691627,
                795665908,
                22207157,
                94552678,
                506225387
            };

            for (int m = 0; m < array.Length; m++)
            {
                long value = SummingSeries(array[m]);

                if (value == expected[m])
                {
                    Console.WriteLine($"Passed {m}");
                }
            }
        }

        private static int SummingSeries(long n)
        {
            BigInteger bigN = n;
            BigInteger bigFactor = 1_000_000_007;

            BigInteger result = bigN * bigN;
            result %= bigFactor;

            return (int) result;
        }

        private static int SummingSeries3(long n)
        {
            const long factor = 1_000_000_007;
            long result = n * n % factor;

            return (int) result;
        }

        private static int SummingSeries2(long n)
        {
            long sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum += 2 * i - 1;
            }

            const long factor = 1_000_000_007;
            long result = sum % factor;

            return (int) result;
        }
    }
}
