using System;
using System.Linq;

namespace GridChallengeProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string[] grid =
            {
                "ebacd",
                "fghij",
                "olmkn",
                "trpqs",
                "xywuv"
            };
            string result = GridChallenge(grid);                    // YES
            Console.WriteLine($"result = {result}");

            grid = new[]
            {
                "mpxz",
                "abcd",
                "wlmf"
            };
            result = GridChallenge(grid);                           // NO
            Console.WriteLine($"result = {result}");
        }

        private static string GridChallenge(string[] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            char[,] array = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string rowString = grid[row];
                string sortedRowString = Sort(rowString);

                for (int col = 0; col < cols; col++)
                {
                    array[row, col] = sortedRowString[col];
                }
            }

            Print(array);
            bool isSorted = true;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    isSorted = array[row, col] <= array[row + 1, col];

                    if (!isSorted)
                    {
                        goto done;
                    }
                }
            }

            done:

            return isSorted ? "YES" : "NO";
        }

        private static string Sort(string inputString)
        {
            return new string(inputString.OrderBy(c => c).ToArray());
        }

        private static void Print(char[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{array[row, col],2} ");
                }

                Console.WriteLine();
            }
        }
    }
}
