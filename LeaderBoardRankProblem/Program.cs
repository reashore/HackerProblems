using System;
using System.Collections.Generic;

namespace LeaderBoardRankProblem
{
    internal static class Program
    {
        public static void Main()
        {
            int[] leaderBoard;
            int[] scores;
            List<int> rankList;

            leaderBoard = new[] {100, 80, 80, 50, 25, 10};
            scores = new[] {5, 20, 50, 90, 120, 50};
            rankList = GetRanking(leaderBoard, scores);
            Print(rankList);

            leaderBoard = new[] {100, 90, 80, 70, 60, 50};
            scores = new[] {40, 50, 60, 70, 80, 90, 110};
            rankList = GetRanking(leaderBoard, scores);
            Print(rankList);
        }

        private static List<int> GetRanking(int[] leaderBoard, int[] scores)
        {
            int len1 = scores.Length;
            int len2 = leaderBoard.Length;
            List<int> result = new List<int>();

            for (int n = 0; n < len1; n++)
            {
                int score = scores[n];
                bool found = false;

                for (int i = len2 - 1; 0 < i; i--)
                {
                    if (score <= leaderBoard[i])
                    {
                        result.Add(i + 2);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    result.Add(1);
                }
            }

            return result;
        }

        private static void Print(List<int> list)
        {
            Console.Write("[");

            foreach (int item in list)
            {
                Console.Write($"{item}, ");
            }

            Console.Write("]");
            Console.WriteLine();
        }
    }
}