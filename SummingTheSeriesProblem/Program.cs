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
        }

        private static int SummingSeries(long n)
        {
            // (a * b) % c = ((a % c) * (b % c)) % c
            const ulong modulo = 1_000_000_007;
            ulong result = (ulong)n % modulo;
            result *= result;
            result %= modulo;
            return (int)result;
        }

        private static void CheckTestResult(int expected, int actual)
        {
            var message = actual == expected ? "Passed" : $"Expected = {expected}, Actual = {actual}";
            WriteLine(message);
        }

        private static void Test1()
        {
            // Arrange
            long[] array = new long[]
            {
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
            int[] expected = new int[]
            {
                578351320,
                404664464,
                20752136,
                999516029,
                743537718,
                323730244,
                174995256,
                593331567,
                136582381,
                305527433,
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
            long[] array = new long[]
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
            int[] expected = new[]
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
            long[] array = new long[]
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
            int[] expected = new[]
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
