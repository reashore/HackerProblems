using System;

namespace MinimumDistanceProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array = {7, 1, 3, 4, 1, 7};
            int minDistance = MinimumDistances(array);                  // 3
            Console.WriteLine($"minDistance = {minDistance}");

            array = new[] {1, 2, 3, 4, 10};
            minDistance = MinimumDistances(array);                  // -1
            Console.WriteLine($"minDistance = {minDistance}");
        }

        private static int MinimumDistances(int[] array)
        {
            int len = array.Length;
            int minDistance = int.MaxValue;
            bool found = false;

            for (int n1 = 0; n1 < len; n1++)
            {
                for (int n2 = 0; n2 < len; n2++)
                {
                    if (n1 >= n2)
                    {
                        continue;
                    }

                    if (array[n1] != array[n2])
                    {
                        continue;
                    }

                    int distance = n2 - n1;

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        found = true;
                    }
                }
            }

            return found ? minDistance : -1;
        }
    }
}
