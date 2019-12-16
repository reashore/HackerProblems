#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeightedUniformStringsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string inputString = "abccddde";
            int[] queries = { 1, 3, 12, 5, 9, 10 };
            string[] results = WeightedUniformStrings(inputString, queries);    // Yes Yes Yes Yes No No
            Print(results);

            inputString = "aaabbbbcccddd";
            queries = new[] { 9, 7, 8, 12, 5 };
            results = WeightedUniformStrings(inputString, queries);             // Yes No Yes Yes No
            Print(results);
        }

        private static void Print(string[] list)
        {
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        private static string[] WeightedUniformStrings(string inputString, int[] queries)
        {
            inputString = inputString.ToLower();
            string distinct = GetDistinctChars(inputString);
            int[] substringLengthArray = new int[27];
            List<string> resultList = new List<string>();

            foreach (char c in distinct)
            {
                int charWeight = GetCharWeight(c);
                substringLengthArray[charWeight] = GetMaxLengthSubstring(inputString, c);
            }
            
            foreach (int query in queries)
            {
                bool passes = false;

                foreach (char c in distinct)
                {
                    int charWeight = GetCharWeight(c);
                    int maxLengthSubstring = substringLengthArray[charWeight];

                    bool dividesEvenly = query % charWeight == 0;
                    int quotient = query / charWeight;
                    passes = dividesEvenly && quotient <= maxLengthSubstring;

                    if (passes)
                    {
                        break;
                    }
                }

                string message = passes ? "Yes" : "No";
                resultList.Add(message);
            }

            return resultList.ToArray();
        }

        private static int GetMaxLengthSubstring(string inputString, char character)
        {
            int maxStringlength = 0;
            int stringLength = 0;
            bool inString = false;

            foreach (char c in inputString)
            {
                if (!inString)
                {
                    if (c == character)
                    {
                        inString = true;
                        stringLength = 1;

                        if (stringLength > maxStringlength)
                        {
                            maxStringlength = stringLength;
                        }
                    }
                }
                else
                {
                    if (c == character)
                    {
                        stringLength++;

                        if (stringLength > maxStringlength)
                        {
                            maxStringlength = stringLength;
                        }
                    }
                    else
                    {
                        inString = false;
                    }
                }
            }

            return maxStringlength;
        }

        private static string GetDistinctChars(string inputString)
        {
            return new string(inputString.Distinct().ToArray());
        }

        private static int GetCharWeight(char c)
        {
            return c - 'a' + 1;
        }
    }
}
