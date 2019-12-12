using System;
using System.Collections.Generic;

namespace AlternatingCharactersProblem
{
    public class Program
    {
        public static void Main()
        {
            string inputString = "AAAA";
            int numberDeletions = AlternatingCharacters(inputString);
            Console.WriteLine($"numberDeletions = {numberDeletions}");      // 3

            inputString = "BBBBB";
            numberDeletions = AlternatingCharacters(inputString);
            Console.WriteLine($"numberDeletions = {numberDeletions}");      // 4

            inputString = "ABABABAB";
            numberDeletions = AlternatingCharacters(inputString);
            Console.WriteLine($"numberDeletions = {numberDeletions}");      // 0

            inputString = "BABABA";
            numberDeletions = AlternatingCharacters(inputString);
            Console.WriteLine($"numberDeletions = {numberDeletions}");      // 0

            inputString = "AAABBB";
            numberDeletions = AlternatingCharacters(inputString);
            Console.WriteLine($"numberDeletions = {numberDeletions}");      // 4
        }

        private static int AlternatingCharacters(string s)
        {
            int len = s.Length;
            List<char> sList = new List<char>(s);

            char previous = sList[0];

            for (int n = 1; n < len; n++)
            {
                char current = sList[n];

                if (current == previous)
                {
                    sList[n] = 'x';
                }
                else
                {
                    previous = current;
                }
            }

            int count = 0;

            foreach (char c in sList)
            {
                if (c == 'x')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
