using System;

namespace LoveLetterMysteryProblem
{
    internal class Program
    {
        private static void Main()
        {
            string word = "abc";
            int numberOperations = SolveLoveLetterMystery(word);
            Console.WriteLine($"numberOperations = {numberOperations}");        // 2

            word = "abcba";
            numberOperations = SolveLoveLetterMystery(word);
            Console.WriteLine($"numberOperations = {numberOperations}");        // 0

            word = "abcd";
            numberOperations = SolveLoveLetterMystery(word);
            Console.WriteLine($"numberOperations = {numberOperations}");        // 4

            word = "cba";
            numberOperations = SolveLoveLetterMystery(word);
            Console.WriteLine($"numberOperations = {numberOperations}");        // 2
        }

        private static int SolveLoveLetterMystery(string word)
        {
            int wordLen = word.Length;
            int endIndex = wordLen / 2;
            int count = 0;

            for (int lowerIndex = 0; lowerIndex < endIndex; lowerIndex ++)
            {
                int upperIndex = wordLen - 1 - lowerIndex;

                char lowerChar = word[lowerIndex];
                char upperChar = word[upperIndex];

                int diff = upperChar - lowerChar;

                if (diff < 0)
                {
                    diff = -diff;
                }

                count += diff;
            }

            return count;
        }
    }
}
