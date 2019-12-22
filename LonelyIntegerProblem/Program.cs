using System;
using System.Collections.Generic;

namespace LonelyIntegerProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array = {1};
            int lonelyInteger = Lonelyinteger(array);                           // 1
            Console.WriteLine($"lonelyInteger = {lonelyInteger}");

            array = new[] {1, 1, 2};
            lonelyInteger = Lonelyinteger(array);                               // 2
            Console.WriteLine($"lonelyInteger = {lonelyInteger}");

            array = new[] {0, 0, 1, 2, 1};
            lonelyInteger = Lonelyinteger(array);                               // 2
            Console.WriteLine($"lonelyInteger = {lonelyInteger}");
        }

        private static int Lonelyinteger(int[] array)
        {
            Dictionary<int, int> occurancesDictionary = GetOccurances(array);
            int uniqueKey = 0;

            foreach (var kvp in occurancesDictionary)
            {
                int key = kvp.Key;
                int occurrances = kvp.Value;

                if (occurrances == 1)
                {
                    uniqueKey = key;
                    break;
                }
            }

            return uniqueKey;
        }

        private static Dictionary<int, int> GetOccurances(int[] array)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (int element in array)
            {
                if (!dictionary.ContainsKey(element))
                {
                    dictionary[element] = 1;
                }
                else
                {
                    dictionary[element]++;
                }
            }

            return dictionary;
        }
    }
}
