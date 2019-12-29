using System;
using System.Collections.Generic;
using System.Linq;

namespace LuckBalanceProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int k = 3;
            int[][] contestArray = new[]
            {
                new[] {5, 1},
                new[] {2, 1},
                new[] {1, 1},
                new[] {8, 1},
                new[] {10, 0},
                new[] {5, 0}
            };
            int luckBalance = LuckBalance(k, contestArray);             // 29
            Console.WriteLine($"luckBalance = {luckBalance}");

            k = 2;
            contestArray = new[]
            {
                new[] {5, 1},
                new[] {1, 1},
                new[] {4, 0},
            };
            luckBalance = LuckBalance(k, contestArray);                 // 10
            Console.WriteLine($"luckBalance = {luckBalance}");
        }

        private class Contest
        {
            public int Luck { get; set; }
            public int Importance { get; set; }
        }

        private static int LuckBalance(int k, int[][] contestArray)
        {
            List<Contest> contestList = GetContestList(contestArray);
            List<Contest> unimportantContestList = contestList.Where(c => c.Importance == 0).Select(c => c).ToList();
            List<Contest> sortedImportantContestList = contestList.Where(c => c.Importance == 1)
                                                                  .OrderByDescending(c => c.Luck)
                                                                  .Select(c => c)
                                                                  .ToList();
            List<Contest> importantContestToLoseList = sortedImportantContestList.Take(k).ToList();
            List<Contest> importantContestToWinList = sortedImportantContestList.Skip(k).ToList();

            int luckBalance = GetLuckBalance(importantContestToLoseList, importantContestToWinList, unimportantContestList);

            return luckBalance;
        }

        private static List<Contest> GetContestList(int[][] contestArray)
        {
            List<Contest> contestList = new List<Contest>();

            foreach (int[] row in contestArray)
            {
                Contest contest = new Contest
                {
                    Luck = row[0],
                    Importance = row[1]
                };

                contestList.Add(contest);
            }

            return contestList;
        }

        private static int GetLuckBalance(List<Contest> importantContestToLoseList, List<Contest> importantContestToWinList, List<Contest> unimportantContestList)
        {
            int luckBalance = 0;

            foreach (Contest contest in importantContestToLoseList)
            {
                luckBalance += contest.Luck;
            }

            foreach (Contest contest in importantContestToWinList)
            {
                luckBalance -= contest.Luck;
            }

            foreach (Contest contest in unimportantContestList)
            {
                luckBalance += contest.Luck;
            }

            return luckBalance;
        }
    }
}
