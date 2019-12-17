using System;
using System.Collections.Generic;

namespace AnagramProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            //bool areAnagrams = AreAnagrams("xy", "yx");

            string inputString;
            int numberCharactersToChange;

            //inputString = "aaabbb";
            //numberCharactersToChange = Anagram(inputString);                                          // 3
            //Console.WriteLine($"numberCharactersToChange = {numberCharactersToChange}");

            //inputString = "ab";
            //numberCharactersToChange = Anagram(inputString);                                              // 1
            //Console.WriteLine($"numberCharactersToChange = {numberCharactersToChange}");

            //inputString = "abc";
            //numberCharactersToChange = Anagram(inputString);                                              // -1
            //Console.WriteLine($"numberCharactersToChange = {numberCharactersToChange}");

            //inputString = "mnop";
            //numberCharactersToChange = Anagram(inputString);                                              // 2
            //Console.WriteLine($"numberCharactersToChange = {numberCharactersToChange}");

            //inputString = "xyyx";
            //numberCharactersToChange = Anagram(inputString);                                              // 0
            //Console.WriteLine($"numberCharactersToChange = {numberCharactersToChange}");

            inputString = "xaxbbbxx";
            numberCharactersToChange = Anagram(inputString);                                              // -1
            Console.WriteLine($"numberCharactersToChange = {numberCharactersToChange}");
        }

        // todo not working for last test case
        private static int Anagram(string inputString)
        {
            int len = inputString.Length;
            bool oddLength = len % 2 != 0;

            if (oddLength)
            {
                return -1;
            }

            string part1 = inputString.Substring(0, len / 2);
            string part2 = inputString.Substring(len/2, len / 2);

            if (AreAnagrams(part1, part2))
            {
                return 0;
            }

            Dictionary<char, int> dictionary1 = GetOccurancesDictionary(part1);
            Dictionary<char, int> dictionary2 = GetOccurancesDictionary(part2);

            int numberChanges = GetNumberChanges(dictionary1, dictionary2);

            return numberChanges;
        }

        private static bool AreAnagrams(string part1, string part2)
        {
            // contain the same characters in dictionary and the respective occurance counts are equal

            Dictionary<char, int> dictionary1 = GetOccurancesDictionary(part1);
            Dictionary<char, int> dictionary2 = GetOccurancesDictionary(part2);

            if (dictionary1.Count != dictionary2.Count)
            {
                return false;
            }

            bool areAnagrams = true;

            foreach (char c in dictionary1.Keys)
            {
                bool condition = dictionary2.ContainsKey(c) && dictionary1[c] == dictionary2[c];

                if (!condition)
                {
                    areAnagrams = false;
                    break;
                }
            }

            return areAnagrams;
        }

        private static int GetNumberChanges(Dictionary<char, int> dictionary1, Dictionary<char, int> dictionary2)
        {
            int numberChanges = 0;

            while (true)
            {
                int count1 = dictionary1.Count;
                int count2 = dictionary2.Count;

                if (count1 == 0 && count2 == 0)
                {
                    break;
                }

                if (count1 != count2)
                {
                    numberChanges = -1;
                    break;
                }

                // removes maxOccurannce key/value
                int maxOccurannce1 = GetMaxOccurance(dictionary1);
                int maxOccurannce2 = GetMaxOccurance(dictionary2);

                if (maxOccurannce1 != maxOccurannce2)
                {
                    numberChanges = -1;
                    break;
                }

                numberChanges += maxOccurannce1;
            }

            return numberChanges;
        }

        private static int GetMaxOccurance(Dictionary<char, int> dictionary)
        {
            int maxOccurance = 0;
            char maxCharacter = char.MinValue;

            if (dictionary.Count == 0)
            {
                return -1;
            }

            foreach (char character in dictionary.Keys)
            {
                int occurance = dictionary[character];

                if (occurance > maxOccurance)
                {
                    maxOccurance = occurance;
                    maxCharacter = character;
                    break;
                }
            }

            // note destructive operation
            dictionary.Remove(maxCharacter);

            return maxOccurance;
        }

        private static Dictionary<char, int> GetOccurancesDictionary(string s)
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
