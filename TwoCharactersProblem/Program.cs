using System;
using System.Collections.Generic;
using System.Text;

namespace TwoCharactersProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string s = "abaacdabd";
            int maxStringLength = Alternate(s);
            Console.WriteLine($"maxStringLength = {maxStringLength}");      // 4

            s = "beabeefeab";
            maxStringLength = Alternate(s);                                 // 5
            Console.WriteLine($"maxStringLength = {maxStringLength}");
        }

        private static int Alternate(string s)
        {
            Dictionary<char, int> occurancesDictionary = GetOccurancesDictionary(s);
            string distinct = GetDistinctKeys(occurancesDictionary);
            char[] distinctArray = distinct.ToCharArray();
            int len = distinctArray.Length;
            int maxLength = 0;

            for (int n1 = 0; n1 < len; n1++)
            {
                for (int n2 = 0; n2 < len; n2++)
                {
                    if (n1 >= n2)
                    {
                        continue;
                    }

                    char c1 = distinctArray[n1];
                    char c2 = distinctArray[n2];

                    int occurances1 = occurancesDictionary[c1];
                    int occurances2 = occurancesDictionary[c2];

                    int difference = Math.Abs(occurances1 - occurances2);

                    if (difference > 1)
                    {
                        continue;
                    }

                    string candidate = RemoveOtherCharacters(s, c1, c2);

                    if (!IsAlternating(candidate))
                    {
                        continue;
                    }

                    int length = candidate.Length;

                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }
            }

            return maxLength;
        }

        private static Dictionary<char, int> GetOccurancesDictionary(string s)
        {
            Dictionary<char, int> occurancesDictionary = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (!occurancesDictionary.ContainsKey(c))
                {
                    occurancesDictionary[c] = 1;
                }
                else
                {
                    occurancesDictionary[c]++;
                }
            }

            return occurancesDictionary;
        }

        private static string GetDistinctKeys(Dictionary<char, int> occurancesDictionary)
        {
            string distinct = "";

            foreach (char c in occurancesDictionary.Keys)
            {
                distinct += c;
            }

            return distinct;
        }

        private static bool IsAlternating(string s)
        {
            int len = s.Length;
            char first = s[0];
            char second = s[1];
            bool even = true;

            if (first == second)
            {
                return false;
            }

            for (int n = 2; n < len; n++)
            {
                char c = s[n];

                if (even && c != first)
                {
                    return false;
                }
                
                if (!even && c != second)
                {
                    return false;
                }

                even = !even;
            }

            return true;
        }

        private static string RemoveOtherCharacters(string s, char c1, char c2)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in s)
            {
                if (c != c1 && c != c2)
                {
                    continue;
                }

                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
