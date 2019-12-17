using System;
using System.Collections.Generic;

namespace ClosestNumbersProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array = {-20, -3916237, -357920, -3620601, 7374819 - 7330761, 30, 6246457, -6461594, 266854};
            int[] closestNumbers = ClosestNumbers(array);
            Print(closestNumbers);
            Console.WriteLine();

            array = new[] { -20, -3916237, -357920, -3620601, 7374819, -7330761, 30, 6246457, -6461594, 266854, -520, -470 };
            closestNumbers = ClosestNumbers(array);
            Print(closestNumbers);
            Console.WriteLine();

            array = new[] {5, 4, 3, 2};
            closestNumbers = ClosestNumbers(array);
            Print(closestNumbers);
            Console.WriteLine();
        }

        private static void Print(IEnumerable<int> array)
        {
            Console.Write("[");

            foreach (int item in array)
            {
                Console.Write($"{item}, ");
            }

            Console.Write("]");
            Console.WriteLine();
        }

        private static int[] ClosestNumbers(int[] array)
        {
            Array.Sort(array);
            int len = array.Length;
            int minDifference = int.MaxValue;
            List<int> resultList = new List<int>();

            for (int n = 0; n < len - 1; n++)
            {
                int first = array[n];
                int second = array[n + 1];
                int difference = Math.Abs(first - second);

                if (difference > minDifference)
                {
                    continue;
                }

                if (difference < minDifference)
                {
                    minDifference = difference;
                    resultList.Clear();
                }

                resultList.Add(first);
                resultList.Add(second);
            }

            return resultList.ToArray();
        }
    }
}
