using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MostPopularCompetitorsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int numberCompetitors = 6;
            string[] competitors = 
            {
                "C1",
                "C2",
                "C3",
                "C4",
                "C5",
                "C6"
            };
            string[] reviews =
            {
                "C1 C3 C2",
                "C2 C3",
                "C4 C5",
                "C6 C3 C5",
                "C6 C5",
                "C1 C3"
            };
            List<string> mostPopularCompetitors = GetMostPopularCompetitors(competitors, reviews, numberCompetitors);
            PrintShortList(mostPopularCompetitors);
            Console.WriteLine();
        }

        private static void PrintShortList(List<string> list)
        {
            Console.Write("[");

            string[] array = list.ToArray();
            string line = string.Join(", ", array);
            Console.Write(line);

            Console.Write("]");
            Console.WriteLine();
        }

        private static List<string> GetMostPopularCompetitors(string[] competitors, string[] reviews, int numberTopCompetitors)
        {
            int numCompetitors = competitors.Length;

            if (numberTopCompetitors > numCompetitors)
            {
                throw new Exception("Must have numCompetitors >= numberTopCompetitors");
            }

            Dictionary<string, int> competitorOccurancesDictionary = GetCompetitorOccurances(competitors, reviews);
            List<string> topCompetitors = new List<string>();

            for (int n = 1; n <= numberTopCompetitors; n++)
            {
                int maxOccurances = 0;
                string topCompetitor = "";

                // ties are handled as first come
                foreach (KeyValuePair<string, int> kvp in competitorOccurancesDictionary)
                {
                    string competitor = kvp.Key;
                    int occurances = kvp.Value;

                    if (occurances > maxOccurances)
                    {
                        maxOccurances = occurances;
                        topCompetitor = competitor;
                    }
                }

                competitorOccurancesDictionary.Remove(topCompetitor);
                topCompetitors.Add(topCompetitor);
            }

            return topCompetitors;
        }

        private static Dictionary<string, int> GetCompetitorOccurances(string[] competitors, string[] reviews)
        {
            Dictionary<string, int> competitorOccurancesDictionary = new Dictionary<string, int>();

            foreach (string competitor in competitors)
            {
                competitorOccurancesDictionary[competitor] = 0;
            }

            foreach (string competitor in competitors)
            {
                foreach (string review in reviews)
                {
                    int occurances = GetOccurances(competitor, review);
                    competitorOccurancesDictionary[competitor] += occurances;
                }
            }

            return competitorOccurancesDictionary;
        }

        private static int GetOccurances(string competitor, string review)
        {
            int numOccurances = 0;

            // Improve matching pattern? Should C1C1 be a match?
            foreach (Match match in Regex.Matches(review, competitor))
            {
                numOccurances++;
            }

            return numOccurances;
        }
    }
}






















