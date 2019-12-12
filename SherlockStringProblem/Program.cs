using System;
using System.Collections.Generic;

namespace SherlockStringProblem
{
    public class Program
    {
        public static void Main()
        {
            string s = "aabbcd";
            string result = IsValid(s);
            Console.WriteLine($"result = {result}");        // NO

            s = "aabbccddeefghi";
            result = IsValid(s);
            Console.WriteLine($"result = {result}");        // NO

            s = "abcdefghhgfedecba";
            result = IsValid(s);
            Console.WriteLine($"result = {result}");        // YES

            s = "aaaabbcc";
            result = IsValid(s);
            Console.WriteLine($"result = {result}");        // NO
        }

        private static string IsValid(string s)
        {
            Dictionary<char, int> dict1 = new Dictionary<char, int>();
            Dictionary<int, int> dict2 = new Dictionary<int, int>();

            // create dictionary of key occurances
            foreach (char c in s)
            {
                if (!dict1.ContainsKey(c))
                {
                    dict1[c] = 1;
                }
                else
                {
                    dict1[c]++;
                }
            }

            // create dictionary of value occurances
            foreach (int value in dict1.Values)
            {
                if (!dict2.ContainsKey(value))
                {
                    dict2[value] = 1;
                }
                else
                {
                    dict2[value]++;
                }
            }

            List<int> valueList = new List<int>();

            foreach (int value in dict2.Values)
            {
                valueList.Add(value);
            }

            if (valueList.Count == 1)
            {
                return "YES";
            }

            if (valueList.Count == 2)
            {
                int value1 = valueList[0];
                int value2 = valueList[1];

                bool condition1 = value1 >= 1 && value2 == 1;
                bool condition2 = value2 >= 1 && value1 == 1;


                if (condition1 || condition2)
                {
                    return "YES";
                }
            }

            return "NO";
        }
    }
}
