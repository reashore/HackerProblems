using System;
using System.Collections.Generic;

namespace CommonSubstringProblem
{
    public class Program
    {
        public static void Main()
        {
            string s1 = "hello";
            string s2 = "world";
            bool hasCommonSubstring = HasCommonString(s1, s2);
            Console.WriteLine($"hasCommonSubstring = {hasCommonSubstring}");

            s1 = "hi";
            s2 = "world";
            hasCommonSubstring = HasCommonString(s1, s2);
            Console.WriteLine($"hasCommonSubstring = {hasCommonSubstring}");
        }

        public static bool HasCommonString(string s1, string s2)
        {
            Dictionary<char, int> s1Dict = new Dictionary<char, int>();
            Dictionary<char, int> s2Dict = new Dictionary<char, int>();

            foreach (char c in s1)
            {
                if (!s1Dict.ContainsKey(c))
                {
                    s1Dict[c] = 1;
                }
                else
                {
                    s1Dict[c]++;
                }
            }

            foreach (char c in s2)
            {
                if (!s2Dict.ContainsKey(c))
                {
                    s2Dict[c] = 1;
                }
                else
                {
                    s2Dict[c]++;
                }
            }

            bool found = false;

            foreach (char c in s1Dict.Keys)
            {
                if (s2Dict.ContainsKey(c))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}
