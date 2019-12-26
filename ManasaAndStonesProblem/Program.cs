using System;
using System.Collections.Generic;

namespace ManasaAndStonesProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            var totalNumberStones = 3;
            var diff1 = 1;
            var diff2 = 2;
            int[] lastStonesArray = Stones(totalNumberStones, diff1, diff2);        // 2 3 4
            Print(lastStonesArray);

            totalNumberStones = 3;
            diff1 = 1;
            diff2 = 1;
            lastStonesArray = Stones(totalNumberStones, diff1, diff2);              // 2
            Print(lastStonesArray);

            totalNumberStones = 4;
            diff1 = 10;
            diff2 = 100;
            lastStonesArray = Stones(totalNumberStones, diff1, diff2);              // 30 120 210 300
            Print(lastStonesArray);
        }

        private static void Print(IEnumerable<int> array)
        {
            string line = string.Join(", ", array);
            Console.WriteLine(line);
            Console.WriteLine();
        }

        private static int[] Stones(int totalNumberStones, int diff1, int diff2)
        {
            if (totalNumberStones < 2)
            {
                throw new ArgumentException("totalNumberStones must be at least 2");
            }

            int diff = diff2 - diff1;
            totalNumberStones--;

            if (diff == 0)
            {
                int lastStone = totalNumberStones * diff1;
                return new[] {lastStone};
            }

            if (diff < 0)
            {
                Swap(ref diff1, ref diff2);
                diff = diff2 - diff1;
            }

            int minLastStone = totalNumberStones * diff1;
            int maxLastStone = totalNumberStones * diff2;

            List<int> lastStonesList = new List<int>();

            for (int n = minLastStone; n <= maxLastStone; n += diff)
            {
                lastStonesList.Add(n);
            }

            return lastStonesList.ToArray();
        }

        private static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}

