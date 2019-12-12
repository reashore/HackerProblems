using System;
using System.Collections.Generic;

namespace MakingAnagramsProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        // https://www.hackerrank.com/challenges/ctci-making-anagrams/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=strings

        public static void Main()
        {
            string value1 = "cde";
            string value2 = "abc";
            int numDels = MakeAnagram(value1, value2);
            Console.WriteLine($"numDels = {numDels}");          // 4

            value1 = "ccddee";
            value2 = "aabbcc";
            numDels = MakeAnagram(value1, value2);
            Console.WriteLine($"numDels = {numDels}");          // 8
        }

        private static int MakeAnagram(string value1, string value2)
        {
            Dictionary<char, int> dict1 = CreateDict(value1);
            Dictionary<char, int> dict2 = CreateDict(value2);
            List<char> keysToDeleteList = new List<char>();
            int numDeletions = 0;

            // delete from dict1
            foreach (char key in dict1.Keys)
            {
                if (!dict2.ContainsKey(key))
                {
                    numDeletions += dict1[key];
                    keysToDeleteList.Add(key);
                }
            }

            foreach (char key in keysToDeleteList)
            {
                dict1.Remove(key);
            }

            keysToDeleteList.Clear();

            // delete from dict2
            foreach (char key in dict2.Keys)
            {
                if (!dict1.ContainsKey(key))
                {
                    numDeletions += dict2[key];
                    keysToDeleteList.Add(key);
                }
            }

            foreach (char key in keysToDeleteList)
            {
                dict2.Remove(key);
            }

            // both dictionaries have the same keys, but possibly different counts
            foreach (char key in dict1.Keys)
            {
                int count1 = dict1[key];
                int count2 = dict2[key];

                int diff = count1 - count2;

                if (diff == 0)
                {
                    continue;
                }

                if (diff < 0)
                {
                    diff = -diff;
                }

                numDeletions += diff;
            }

            Console.WriteLine(numDeletions);

            return numDeletions;
        }

        private static Dictionary<char, int> CreateDict(string value)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char c in value)
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

            return dict;
        }
    }
}
