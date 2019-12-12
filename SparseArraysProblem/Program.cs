using System;
using System.Collections.Generic;

namespace SparseArraysProblem
{
    internal class Program
    {
        internal static void Main()
        {
            string[] strings =
            {
                "aba",
                "baba",
                "aba",
                "xzxb"
            };
            string[] queries =
            {
                "aba",
                "xzxb",
                "ab"
            };
            int[] result = MatchingStrings(strings, queries);       // 2, 1, 0
        }

        private static int[] MatchingStrings(string[] strings, string[] queries)
        {
            List<int> result = new List<int>();

            foreach (string query in queries)
            {
                int stringCount = 0;

                foreach (string item in strings)
                {
                    if (query == item)
                    {
                        stringCount++;
                    }
                }

                result.Add(stringCount);
            }

            return result.ToArray();
        }
    }
}
