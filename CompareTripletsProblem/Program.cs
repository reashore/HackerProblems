using System;
using System.Collections.Generic;

namespace CompareTripletsProblem
{
    internal class Program
    {
        internal static void Main()
        {
            List<int> a = new List<int> {5, 6, 7};
            List<int> b = new List<int> {3, 6, 10};
            List<int> scores = CompareTriplets(a, b);                           // 1, 1
            Console.WriteLine($"scores = {scores[0]} {scores[1]}");

            a = new List<int> {17, 28, 30};
            b = new List<int> {99, 16, 8};
            scores = CompareTriplets(a, b);
            Console.WriteLine($"scores = {scores[0]}, {scores[1]}");            // 2, 1
        }

        private static List<int> CompareTriplets(List<int> a, List<int> b)
        {
            int aScore = 0;
            int bScore = 0;
            int len = a.Count;

            for (int n = 0; n < len; n++)
            {
                if (a[n] > b[n])
                {
                    aScore++;
                }
                else if (a[n] < b[n])
                {
                    bScore++;
                }
            }

            List<int> scores = new List<int> {aScore, bScore};
            return scores;
        }
    }
}
