using System;

namespace BreakingRecordsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] scores = {10, 5, 20, 20, 4, 5, 2, 25, 1};
            int[] minMaxArray = BreakingRecords(scores);                // 2 4
            PrintArray(minMaxArray);

            scores = new []{ 3, 4, 21, 36, 10, 28, 35, 5, 24, 42 };
            minMaxArray = BreakingRecords(scores);                      // 4 0
            PrintArray(minMaxArray);
        }

        private static void PrintArray(int[] array)
        {
            Console.Write(string.Join(", ", array));
            Console.WriteLine();
        }

        private static int[] BreakingRecords(int[] scores)
        {
            int maxScore = scores[0];
            int minScore = scores[0];
            int maxCount = 0;
            int minCount = 0;

            foreach (int score in scores)
            {
                if (score > maxScore)
                {
                    maxScore = score;
                    maxCount++;
                }
                else if (score < minScore)
                {
                    minScore = score;
                    minCount++;
                }
            }

            return new[]{ maxCount, minCount};
        }
    }
}
