using System;
using System.Collections.Generic;

namespace SpecialSubstringProblem
{
    public class Program
    {
        public static void Main()
        {
            string s = "mnonopoo";
            int n = s.Length;
            long numSubstrings = SubstrCount(n, s);
            Console.WriteLine($"numSubstrings = {numSubstrings}");
        }

        private static long SubstrCount(int n, string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            List<string> len1SubstringList = new List<string>();
            List<string> longerSubstringList = new List<string>();

            len1SubstringList.ToArray();

            foreach (char c in s)
            {
                if (!dict.ContainsKey(c))
                {
                    dict[c] = 1;
                }
                else
                {
                    dict[c]++;
                }
            }

            // add all single character substrings
            foreach (char c in dict.Keys)
            {
                if (dict[c] == 1)
                {
                    len1SubstringList.Add(c.ToString());
                }
            }

            foreach (char c in dict.Keys)
            {
                if (dict[c] > 1)
                {
                    for (int m = 2; m <= dict[c]; m++)
                    {
                        string substring = new string(c, m);
                        int index = s.IndexOf(substring, StringComparison.Ordinal);

                        if (index == -1)
                        {
                            continue;
                        }

                        longerSubstringList.Add(substring);
                    }
                }
            }

            return 0;
        }
    }
}
