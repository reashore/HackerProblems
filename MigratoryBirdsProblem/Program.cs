using System;
using System.Collections.Generic;

namespace MigratoryBirdsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            List<int> array = new List<int> {1, 1, 2, 2, 3};
            int birdType = MigratoryBirds(array);                           // 1
            Console.WriteLine($"birdType = {birdType}");

            array = new List<int> {1, 4, 4, 4, 5, 3};
            birdType = MigratoryBirds(array);                               // 4
            Console.WriteLine($"birdType = {birdType}");

            array = new List<int> {1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4};
            birdType = MigratoryBirds(array);                               // 3
            Console.WriteLine($"birdType = {birdType}");
        }

        private static int MigratoryBirds(List<int> array)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (int birdType in array)
            {
                if (!dictionary.ContainsKey(birdType))
                {
                    dictionary[birdType] = 1;
                }
                else
                {
                    dictionary[birdType]++;
                }
            }

            int maxCount = 0;

            foreach (int count in dictionary.Values)
            {
                if (count > maxCount)
                {
                    maxCount = count;
                }
            }

            int minBirdType = int.MaxValue;

            foreach (KeyValuePair<int, int> keyValuePair in dictionary)
            {
                int birdType = keyValuePair.Key;
                int count = keyValuePair.Value;

                if (count == maxCount)
                {
                    if (birdType < minBirdType)
                    {
                        minBirdType = birdType;
                    }
                }
            }

            return minBirdType;
        }
    }
}
