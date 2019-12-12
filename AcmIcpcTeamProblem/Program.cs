using System;
using System.Text;

namespace AcmIcpcTeamProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string[] topicArray =
            {
                "10101",
                "11110",
                "00010"
            };
            int[] resultArray = AcmTeam(topicArray);                                    // 5 1
            int maxNumTopics = resultArray[0];
            int numPairs = resultArray[1];
            Console.WriteLine($"maxNumTopics = {maxNumTopics}, numPairs = {numPairs}");

            topicArray = new[]
            {
                "10101",
                "11100",
                "11010",
                "00101"
            };
            resultArray = AcmTeam(topicArray);                                          // 5 2
            maxNumTopics = resultArray[0];
            numPairs = resultArray[1];
            Console.WriteLine($"maxNumTopics = {maxNumTopics}, numPairs = {numPairs}");
        }

        private static int[] AcmTeam(string[] topicArray)
        {
            int len = topicArray.Length;
            int maxNumTopics = 0;
            int numPairs = 0;

            for (int n1 = 0; n1 < len; n1++)
            {
                for (int n2 = 0; n2 < len; n2++)
                {
                    if (n1 >= n2)
                    {
                        continue;
                    }

                    string topic1 = topicArray[n1];
                    string topic2 = topicArray[n2];

                    string combinedTopics = CombineTopics(topic1, topic2);
                    int numTopics = GetNumTopics(combinedTopics);

                    if (numTopics > maxNumTopics)
                    {
                        numPairs = 1;
                        maxNumTopics = numTopics;
                    }
                    else if (numTopics == maxNumTopics)
                    {
                        numPairs++;
                    }
                }
            }

            return new[] { maxNumTopics, numPairs};
        }

        private static string CombineTopics(string topic1String, string topic2String)
        {
            int len = topic1String.Length;
            StringBuilder sb = new StringBuilder();

            for (int n = 0; n < len; n++)
            {
                bool topic1 = topic1String[n] == '1';
                bool topic2 = topic2String[n] == '1';

                bool topic = topic1 || topic2;
                char c = topic ? '1' : '0';

                sb.Append(c);
            }

            return sb.ToString();
        }

        private static int GetNumTopics(string topics)
        {
            int numTopics = 0;

            foreach (char c in topics)
            {
                if (c == '1')
                {
                    numTopics++;
                }
            }

            return numTopics;
        }
    }
}
