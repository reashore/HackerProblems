using System;

namespace HourGlassArrayProblem
{
    internal class Program
    {
        internal static void Main()
        {
            //int[][] array =
            //{
            //    new[] {1, 2, 3, 4, 5, 6},
            //    new[] {2, 2, 3, 4, 5, 6},
            //    new[] {3, 2, 3, 4, 5, 6},
            //    new[] {4, 2, 3, 4, 5, 6},
            //    new[] {5, 2, 3, 4, 5, 6},
            //    new[] {6, 2, 3, 4, 5, 6}
            //};
            int[][] array =
            {
                new[] {-9, -9, -9, 1, 1, 1},
                new[] {0, -9, 0, 4, 3, 2},
                new[] {-9, -9, -9, 1, 2, 3},
                new[] {0, 0, 8, 6, 6, 0},
                new[] {0, 0, 0, -2, 0, 0},
                new[] {0, 0, 1, 2, 4, 0}
            };
            int maxHourGlassSum = HourglassSum(array);              // 28

            Console.WriteLine($"maxHourGlassSum = {maxHourGlassSum}");
        }

        private static int HourglassSum(int[][] arr)
        {
            int[,] array = new int[6, 6];

            int row = 0;
            foreach (int[] rowArray in arr)
            {
                int col = 0;
                foreach (int value in rowArray)
                {
                    array[row, col] = value;
                    col++;
                }

                row++;
            }

            int maxHourglassSum = int.MinValue;

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    int r0 = r;
                    int r1 = r0 + 1;
                    int r2 = r0 + 2;

                    int c0 = c;
                    int c1 = c0 + 1;
                    int c2 = c0 + 2;

                    int hourglassSum = array[r0, c0] + array[r0, c1] + array[r0, c2] +
                                                       array[r1, c1] +
                                       array[r2, c0] + array[r2, c1] + array[r2, c2];

                    if (hourglassSum > maxHourglassSum)
                    {
                        maxHourglassSum = hourglassSum;
                    }
                }
            }

            return maxHourglassSum;
        }
    }
}
