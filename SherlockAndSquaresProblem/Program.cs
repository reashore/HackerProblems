using System;

namespace SherlockAndSquaresProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int low = 3;
            int high = 9;
            int numSquares = Squares(low, high);                            // 2
            Console.WriteLine($"numSquares = {numSquares}");

            low = 17;
            high = 24;
            numSquares = Squares(low, high);                                // 0
            Console.WriteLine($"numSquares = {numSquares}");
        }

        private static int Squares(int low, int high)
        {
            int floor = (int) Math.Floor(Math.Sqrt(high));
            int ceiling = (int) Math.Ceiling(Math.Sqrt(low));
            int diff = floor - ceiling + 1;

            return diff;
        }

        private static int Squares3(int low, int high)
        {
            int count = 0;

            for (int i = low; i <= high; i++)
            {
                for (int j = 1; j * j <= i; j++)
                {
                    if (j * j == i)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static int Squares2(int low, int high)
        {
            int numSquares = 0;

            for (int number = low; number <= high; number++)
            {
                if (IsSquare(number))
                {
                    numSquares++;
                }
            }

            return numSquares;
        }

        private static bool IsSquare(int number)
        {
            double root = Math.Sqrt(number);

            double rootCeiling = Math.Ceiling(root);
            double rootFloor = Math.Ceiling(root);

            int rootCeilingInt = Convert.ToInt32(rootCeiling);
            int rootFloorInt = Convert.ToInt32(rootFloor);

            bool condition1 = rootCeilingInt * rootCeilingInt == number;
            bool condition2 = rootFloorInt * rootFloorInt == number;

            return condition1 || condition2;
        }
    }
}
