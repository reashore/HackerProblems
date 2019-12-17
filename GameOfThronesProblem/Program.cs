using System;
using System.Collections.Generic;

namespace GameOfThronesProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string s = "aaabbbb";
            string result = GameOfThrones(s);
            Console.WriteLine($"result = {result}");            // YES
        }

        private static string GameOfThrones(string s)
        {
            int len = s.Length;
            bool lengthIsEven = len % 2 == 0;
            Dictionary<char, int> dictionary = GetOccurances(s);
            List<int> occuranceList = new List<int>();
            bool isPalindrone;

            // even -> all occurance counts must be even
            // odd  -> only one occurance count can be odd

            foreach (int value in dictionary.Values)
            {
                occuranceList.Add(value);
            }

            if (lengthIsEven)
            {
                isPalindrone = occuranceList.TrueForAll(value => value % 2 == 0);
            }
            else
            {
                int oddOccurances = 0;

                foreach (int value in occuranceList)
                {
                    if (value % 2 != 0)
                    {
                        oddOccurances++;
                    }
                }

                isPalindrone = oddOccurances == 1;
            }

            return isPalindrone ? "YES" : "NO";
        }

        private static Dictionary<char, int> GetOccurances(string s)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (!dictionary.ContainsKey(c))
                {
                    dictionary[c] = 1;
                }
                else
                {
                    dictionary[c]++;
                }
            }

            return dictionary;
        }
    }
}
