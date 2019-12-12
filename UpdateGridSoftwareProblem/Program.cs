using System;

namespace UpdateGridSoftwareProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[,] grid;
            int days;

            grid = new[,]
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}
            };
            days = GetDaysToUpdateSoftwareGrid(grid);
            Console.WriteLine($"days = {days}");
            Console.WriteLine("**********************************************");

            grid = new[,]
            {
                {1, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}
            };
            days = GetDaysToUpdateSoftwareGrid(grid);
            Console.WriteLine($"days = {days}");
            Console.WriteLine("**********************************************");

            grid = new[,]
            {
                {0, 0, 0, 0, 1},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}
            };
            days = GetDaysToUpdateSoftwareGrid(grid);
            Console.WriteLine($"days = {days}");
            Console.WriteLine("**********************************************");

            grid = new[,]
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {1, 0, 0, 0, 0}
            };
            days = GetDaysToUpdateSoftwareGrid(grid);
            Console.WriteLine($"days = {days}");
            Console.WriteLine("**********************************************");

            grid = new[,]
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 1}
            };
            days = GetDaysToUpdateSoftwareGrid(grid);
            Console.WriteLine($"days = {days}");
            Console.WriteLine("**********************************************");
        }

        private static int GetDaysToUpdateSoftwareGrid(int[,] initialGrid)
        {
            int numDays = 0;
            int[,] grid = CopyGrid(initialGrid);

            while (true)
            {
                int[,] nextGrid = UpdateGrid(grid);
                PrintGrid(nextGrid);
                bool isGridUpdated = IsGridUpdated(nextGrid);
                numDays++;

                if (isGridUpdated)
                {
                    break;
                }

                grid = nextGrid;
            }

            return numDays;
        }

        private static int[,] CopyGrid(int[,] grid)
        {
            int len1 = grid.GetLength(0);
            int len2 = grid.GetLength(1);

            int[,] newGrid = new int[len1, len2];

            for (int row = 0; row < len1; row++)
            {
                for (int col = 0; col < len2; col++)
                {
                    newGrid[row, col] = grid[row, col];
                }
            }

            return newGrid;
        }

        private static int[,] UpdateGrid(int[,] grid)
        {
            int len1 = grid.GetLength(0);
            int len2 = grid.GetLength(1);
            int[,] nextGrid = new int[len1, len2];

            for (int row = 0; row < len1; row++)
            {
                for (int col = 0; col < len2; col++)
                {
                    bool isUpdated = grid[row, col] == 1;

                    if (isUpdated)
                    {
                        UpdateGridCells(nextGrid, row, col, len1, len2);
                    }
                }
            }

            return nextGrid;
        }

        private static void UpdateGridCells(int[,] nextGrid, int row, int col, int len1, int len2)
        {
            bool leftTopCorner = row == 0 && col == 0;
            bool rightTopCorner = row == 0 && col == len2 - 1;
            bool leftBottomCorner = row == len1 - 1 && col == 0;
            bool rightBottomCorner = row == len1 - 1 && col == len2 - 1;

            bool topRow = row == 0;
            bool bottomRow = row == len1 - 1;
            bool leftCol = col == 0;
            bool rightCol = col == len2 - 1;

            if (leftTopCorner)
            {
                //nextGrid[row - 1, col] = 1;
                //nextGrid[row, col - 1] = 1;
                nextGrid[row, col] = 1;
                nextGrid[row, col + 1] = 1;
                nextGrid[row + 1, col] = 1;
            }
            else if (rightTopCorner)
            {
                //nextGrid[row - 1, col] = 1;
                nextGrid[row, col - 1] = 1;
                nextGrid[row, col] = 1;
                //nextGrid[row, col + 1] = 1;
                nextGrid[row + 1, col] = 1;
            }
            else if (leftBottomCorner)
            {
                nextGrid[row - 1, col] = 1;
                //nextGrid[row, col - 1] = 1;
                nextGrid[row, col] = 1;
                nextGrid[row, col + 1] = 1;
                //nextGrid[row + 1, col] = 1;
            }
            else if (rightBottomCorner)
            {
                nextGrid[row - 1, col] = 1;
                nextGrid[row, col - 1] = 1;
                nextGrid[row, col] = 1;
                //nextGrid[row, col + 1] = 1;
                //nextGrid[row + 1, col] = 1;
            }
            else if (topRow)
            {
                //nextGrid[row - 1, col] = 1;
                nextGrid[row, col - 1] = 1;
                nextGrid[row, col] = 1;
                nextGrid[row, col + 1] = 1;
                nextGrid[row + 1, col] = 1;
            }
            else if (bottomRow)
            {
                nextGrid[row - 1, col] = 1;
                nextGrid[row, col - 1] = 1;
                nextGrid[row, col] = 1;
                nextGrid[row, col + 1] = 1;
                //nextGrid[row + 1, col] = 1;
            }
            else if (leftCol)
            {
                nextGrid[row - 1, col] = 1;
                //nextGrid[row, col - 1] = 1;
                nextGrid[row, col] = 1;
                nextGrid[row, col + 1] = 1;
                nextGrid[row + 1, col] = 1;
            }
            else if (rightCol)
            {
                nextGrid[row - 1, col] = 1;
                nextGrid[row, col - 1] = 1;
                nextGrid[row, col] = 1;
                //nextGrid[row, col + 1] = 1;
                nextGrid[row + 1, col] = 1;
            }
            else
            {
                nextGrid[row - 1, col] = 1;
                nextGrid[row, col - 1] = 1;
                nextGrid[row, col] = 1;
                nextGrid[row, col + 1] = 1;
                nextGrid[row + 1, col] = 1;
            }
        }

        private static bool IsGridUpdated(int[,] grid)
        {
            int len1 = grid.GetLength(0);
            int len2 = grid.GetLength(1);

            for (int row = 0; row < len1; row++)
            {
                for (int col = 0; col < len2; col++)
                {
                    bool notFullyUpdated = grid[row, col] == 0;

                    if (notFullyUpdated)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void PrintGrid(int[,] grid)
        {
            int len1 = grid.GetLength(0);
            int len2 = grid.GetLength(1);

            for (int row = 0; row < len1; row++)
            {
                for (int col = 0; col < len2; col++)
                {
                    int value = grid[row, col];
                    Console.Write($"{value}, ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
