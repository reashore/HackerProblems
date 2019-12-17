using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace GemstonesProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string[] array = {"abcdde", "baccd", "eeabg"};
            int numberGemstones = Gemstones(array);
            Console.WriteLine($"numberGemstones = {numberGemstones}");
        }

        private static int Gemstones(string[] array)
        {
            int len = array.Length;
            List<string> distinctList = new List<string>();
            int numberGemstones = 0;

            foreach (string s in array)
            {
                string distinct = Utilities.GetDistinctChars(s);
                distinctList.Add(distinct);
            }

            string[] sortedDistinctArray = distinctList.OrderBy(s => s.Length).ToArray();
            string shortestString = sortedDistinctArray[0];

            foreach (char c in shortestString)
            {
                bool hasGemstone = true;

                for (int n = 1; n < len; n++)
                {
                    hasGemstone = sortedDistinctArray[n].Contains(c.ToString());

                    if (!hasGemstone)
                    {
                        break;
                    }
                }

                if (hasGemstone)
                {
                    numberGemstones++;
                }
            }

            return numberGemstones;
        }
    }
}
