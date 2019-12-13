using System;
using System.Collections.Generic;

namespace ServiceLaneProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] widthArray = { 2, 3, 1, 2, 3, 2, 3, 3 };
            int[][] cases =
            {
                new [] {0, 3},
                new [] {4, 6},
                new [] {6, 7},
                new [] {3, 5},
                new [] {0, 7}
            };
            int[] minWidthArray = ServiceLane(widthArray, cases);
            Print(minWidthArray);
            Console.WriteLine();
        }

        private static int[] ServiceLane(int[] widthArray, int[][] cases)
        {
            List<int> minWidthArray = new List<int>();

            foreach (int[] item in cases)
            {
                int startIndex = item[0];
                int endIndex = item[1];

                int minWidth = GetMinWidth(widthArray, startIndex, endIndex);

                minWidthArray.Add(minWidth);
            }

            return minWidthArray.ToArray();
        }

        private static int GetMinWidth(int[] widthArray, int startIndex, int endIndex)
        {
            int minWidth = int.MaxValue;

            for (int n = startIndex; n <= endIndex; n++)
            {
                int width = widthArray[n];

                if (width < minWidth)
                {
                    minWidth = width;
                }
            }

            return minWidth;
        }

        private static void Print(int[] array)
        {
            string line = string.Join(", ", array);

            Console.Write("[");
            Console.Write(line);
            Console.Write("]");
            Console.WriteLine();
        }
    }
}