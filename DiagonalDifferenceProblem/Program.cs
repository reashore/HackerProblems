using System;
using System.Collections.Generic;

namespace DiagonalDifferenceProblem
{
    internal class Program
    {
        internal static void Main()
        {
            List<List<int>> array = new List<List<int>>
            {
                new List<int>{1, 2, 3},
                new List<int>{4, 5, 6},
                new List<int>{9, 8, 9}
            };
            int diagonalDifference = DiagonalDifference2(array);                     // 12
            Console.WriteLine($"diagonalDifference = {diagonalDifference}");            

            array = new List<List<int>>
            {
                new List<int>{11, 2, 4},
                new List<int>{4, 5, 6},
                new List<int>{10, 8, -12}
            };
            diagonalDifference = DiagonalDifference2(array);                         // 15
            Console.WriteLine($"diagonalDifference = {diagonalDifference}");
        }

        private static int DiagonalDifference1(List<List<int>> array)
        {
            int row = 0;
            int len = array.Count;
            int[,] matrix = new int[len, len];

            foreach (List<int> arrayRow in array)
            {
                int col = 0;

                foreach (int value in arrayRow)
                {
                    matrix[row, col] = value;
                    col++;
                }

                row++;
            }

            int diagonalSum1 = 0;
            int diagonalSum2 = 0;

            for (int n = 0; n < len; n++)
            {
                diagonalSum1 += matrix[n, n];
            }

            for (int n = 0; n < len; n++)
            {
                diagonalSum2 += matrix[n, len - 1 - n];
            }

            int diff = diagonalSum1 - diagonalSum2;

            if (diff < 0)
            {
                diff = -diff;
            }

            return diff;
        }

        private static int DiagonalDifference2(List<List<int>> array)
        {
            int len = array.Count;
            int diagonalSum1 = 0;
            int diagonalSum2 = 0;

            for (int n = 0; n < len; n++)
            {
                diagonalSum1 += array[n][n];
            }

            for (int n = 0; n < len; n++)
            {
                diagonalSum2 += array[n][len - 1 - n];
            }

            int diff = diagonalSum1 - diagonalSum2;

            if (diff < 0)
            {
                diff = -diff;
            }

            return diff;
        }
    }
}
