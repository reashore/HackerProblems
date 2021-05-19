using System;
using System.Collections.Generic;

namespace FormingMagicSquare
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            int[][] magicSquare = new []
            {
                new[] {5, 3, 4},
                new[] {1, 5, 8},
                new[] {6, 4, 2}
            };
            int cost = FormingMagicSquare(magicSquare);                 // 7
            Console.WriteLine($"cost = {cost}");

            magicSquare = new[]
            {
                new[] {4, 9, 2},
                new[] {3, 5, 7},
                new[] {8, 1, 5}
            };
            cost = FormingMagicSquare(magicSquare);                     // 1
            Console.WriteLine($"cost = {cost}");

            magicSquare = new[]
            {
                new[] {4, 8, 2},
                new[] {4, 5, 7},
                new[] {6, 1, 6}
            };
            cost = FormingMagicSquare(magicSquare);                     // 4
            Console.WriteLine($"cost = {cost}");
        }

        private static int FormingMagicSquare(int[][] square)
        {
            int minCost = int.MaxValue;
            List<int[][]> magicSquareList = GetMagicSquares();

            for (int n = 0; n < 8; n++)
            {
                int[][] magicSquare = magicSquareList[n];
                int cost = GetMagicSquareCost(magicSquare, square);

                if (cost < minCost)
                {
                    minCost = cost;
                }
            }

            return minCost;
        }

        private static int GetMagicSquareCost(int[][] magicSquare1, int[][] magicSquare2)
        {
            int cost = 0;

            for (int n1 = 0; n1 < 3; n1++)
            {
                for (int n2 = 0; n2 < 3; n2++)
                {
                    int cell1 = magicSquare1[n1][n2];
                    int cell2 = magicSquare2[n1][n2];
                    cost += Abs(cell1 - cell2);
                }
            }

            return cost;
        }

        private static int Abs(int n)
        {
            if (n < 0)
            {
                return -n;
            }

            return n;
        }

        private static List<int[][]> GetMagicSquares()
        {
            // 4 9 2 | 2 9 4
            // 3 5 7 | 7 5 3
            // 8 1 6 | 6 1 8

            // 8 1 6 | 6 1 8
            // 3 5 7 | 7 5 3
            // 4 9 2 | 2 9 4

            // 8 3 4 | 4 3 8
            // 1 5 9 | 9 5 1
            // 6 7 2 | 2 7 6

            // 6 7 2 | 2 7 6
            // 1 5 9 | 9 5 1
            // 8 3 4 | 4 3 8

            int[][] magicSquare1 = new[]
            {
                new[] {4, 9, 2},
                new[] {3, 5, 7},
                new[] {8, 1, 6}
            };

            int[][] magicSquare2 = new[]
            {
                new[] {2, 9, 4},
                new[] {7, 5, 3},
                new[] {6, 1, 8}
            };

            int[][] magicSquare3 = new[]
            {
                new[] {8, 1, 6},
                new[] {3, 5, 7},
                new[] {4, 9, 2}
            };

            int[][] magicSquare4 = new[]
            {
                new[] {6, 1, 8},
                new[] {7, 5, 3},
                new[] {2, 9, 4}
            };

            int[][] magicSquare5 = new[]
            {
                new[] {8, 3, 4},
                new[] {1, 5, 9},
                new[] {6, 7, 2}
            };

            int[][] magicSquare6 = new[]
            {
                new[] {4, 3, 8},
                new[] {9, 5, 1},
                new[] {2, 7, 6}
            };

            int[][] magicSquare7 = new[]
            {
                new[] {6, 7, 2},
                new[] {1, 5, 9},
                new[] {8, 3, 4}
            };

            int[][] magicSquare8 = new[]
            {
                new[] {2, 7, 6},
                new[] {9, 5, 1},
                new[] {4, 3, 8}
            };

            List<int[][]> magicSquares = new List<int[][]>
            {
                magicSquare1,
                magicSquare2,
                magicSquare3,
                magicSquare4,
                magicSquare5,
                magicSquare6,
                magicSquare7,
                magicSquare8
            };

            return magicSquares;
        }
    }
}
