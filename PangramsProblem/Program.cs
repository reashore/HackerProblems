using System;
using System.Collections.Generic;

namespace PangramsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string inputString = "We promptly judged antique ivory buckles for the next prize";
            string result = Pangrams(inputString);                                                      //pangram
            Console.WriteLine($"result = {result}");

            inputString = "We promptly judged antique ivory buckles for the prize";
            result = Pangrams(inputString);                                                             //pangram
            Console.WriteLine($"result = {result}");
        }

        private static string Pangrams(string inputString)
        {
            inputString = inputString.ToLower();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (char c in inputString)
            {
                if (!char.IsLower(c))
                {
                    continue;
                }

                if (!dictionary.ContainsKey(c))
                {
                    dictionary[c] = 1;
                }
                else
                {
                    dictionary[c]++;
                }
            }

            return dictionary.Count == 26 ? "pangram" : "not pangram";
        }
    }
}
