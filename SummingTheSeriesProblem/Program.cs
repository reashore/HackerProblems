using System;
using static System.Console;

namespace SummingTheSeriesProblem
{
    internal class Program
    {
        internal static void Main()
        {
            long n = 2;
            int result = SummingSeries(n);                  // 4
            WriteLine($"result = {result}");

            n = 1;
            result = SummingSeries(n);                      // 1
            WriteLine($"result = {result}");

            Test1();
            Test2();
            Test3();
            Test4();
        }

        //private static int SummingSeries(long n)
        //{
        //    long result = 0;

        //    try
        //    {
        //        // (a * b) % c = ((a % c) * (b % c)) % c
        //        const long modulo = 1_000_000_007;
        //        result = n % modulo;
        //        result *= result;
        //        result %= modulo;
        //    }
        //    catch (Exception exception)
        //    {
        //        WriteLine("Exception");
        //    }

        //    return (int)result;
        //}

        private static int SummingSeries(long n)
        {
            checked
            {
                // (a * b) % c = ((a % c) * (b % c)) % c
                const long modulo = 1_000_000_007;
                long result = n % modulo;
                result *= result;
                result %= modulo;
                return (int)result;
            }
        }

        //private static int SummingSeries(long n)
        //{
        //    checked
        //    {
        //        // (a * b) % c = ((a % c) * (b % c)) % c
        //        const ulong modulo = 1_000_000_007;
        //        ulong result = ((ulong)n) % modulo;
        //        result *= result;
        //        result %= modulo;
        //        return (int)result;
        //    }
        //}

        private static void CheckTestResult(int expected, int actual)
        {
            var message = actual == expected ? "Passed" : $"Failed: Expected = {expected}, Actual = {actual}";
            WriteLine(message);
        }

        private static void Test1()
        {
            // Arrange
            long[] array = {
                5351871996120528,
                2248813659738258,
                2494359640703601,
                6044763399160734,
                3271269997212342,
                4276346434761561,
                2372239019637533,
                5624204919070546,
                9493965694520825,
                8629828692375133
            };
            int[] expected = {
                578351320,
                404664464,
                20752136,
                999516029,
                743537718,
                323730244,
                174995256,
                593331567,
                136582381,
                305527433
            };

            WriteLine();

            for (int m = 0; m < array.Length; m++)
            {
                // Act
                int actual = SummingSeries(array[m]);

                // Assert
                CheckTestResult(expected[m], actual);
            }
        }

        private static void Test2()
        {
            // Arrange
            long[] array = {
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
            int[] expected = {
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

            WriteLine();

            for (int m = 0; m < array.Length; m++)
            {
                // Act
                int actual = SummingSeries(array[m]);

                //Assert
                CheckTestResult(expected[m], actual);
            }
        }

        private static void Test3()
        {
            // Arrange
            long[] array = {
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
            int[] expected = {
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

            WriteLine();

            for (int m = 0; m < array.Length; m++)
            {
                // Act
                int actual = SummingSeries(array[m]);

                // Assert
                CheckTestResult(expected[m], actual);
            }
        }

        private static void Test4()
        {
            // Arrange
            long[] array = {
                5773408242017850,
                5025554062339313,
                9803332417649065,
                4529826640896246,
                7633499047094366,
                4614556128541569,
                8200111660324493,
                9428242699249167,
                3888311265122983,
                2400440231598721
            };
            int[] expected = {
                112242846,
                224225402,
                27866312,
                696985755,
                210094750,
                364229804,
                770629628,
                249617754,
                321706764,
                69640712
            };

            WriteLine();

            for (int m = 0; m < array.Length; m++)
            {
                // Act
                int actual = SummingSeries(array[m]);

                // Assert
                CheckTestResult(expected[m], actual);
            }
        }
    }
}
