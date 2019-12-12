using System;
using System.Collections.Generic;

namespace FrequencyQueriesProblem
{
    public class Program
    {
        public static void Main()
        {
            //RunSampleTests();
            //RunAdditionalTests();
        }

        private static void RunSampleTests()
        {
            List<List<int>> queries = new List<List<int>>
            {
                new List<int> {1, 1},
                new List<int> {2, 2},
                new List<int> {3, 2},
                new List<int> {1, 1},
                new List<int> {1, 1},
                new List<int> {2, 1},
                new List<int> {3, 2}
            };
            (Dictionary<int, int> dataDict, Dictionary<int, int> frequencyDict, List<int> resultList) = FrequencyQueries.FrequeryQuery(queries);          // [0, 1]
            PrintList(resultList);

            queries = new List<List<int>>
            {
                new List<int> {1, 5},
                new List<int> {1, 6},
                new List<int> {3, 2},
                new List<int> {1, 10},
                new List<int> {1, 10},
                new List<int> {1, 6},
                new List<int> {2, 5},
                new List<int> {3, 2}
            };
            (dataDict, frequencyDict, resultList) = FrequencyQueries.FrequeryQuery(queries);                    // [0, 1]
            PrintList(resultList);

            queries = new List<List<int>>
            {
                new List<int> {3, 4},
                new List<int> {2, 1003},
                new List<int> {1, 16},
                new List<int> {3, 1}
            };
            (dataDict, frequencyDict, resultList) = FrequencyQueries.FrequeryQuery(queries);                    // [0, 1]
            PrintList(resultList);

            queries = new List<List<int>>
            {
                new List<int> {1, 3},
                new List<int> {2, 3},
                new List<int> {3, 2},
                new List<int> {1, 4},
                new List<int> {1, 5},
                new List<int> {1, 5},
                new List<int> {1, 4},
                new List<int> {3, 2},
                new List<int> {2, 4},
                new List<int> {3, 2}
            };
            (dataDict, frequencyDict, resultList) = FrequencyQueries.FrequeryQuery(queries);                    // [0, 1, 1]
            PrintList(resultList);
        }

        private static void RunAdditionalTests()
        {
            List<List<int>> queries = new List<List<int>>
            {
                new List<int> {1, 1},
                new List<int> {1, 2},
                new List<int> {1, 3},
                new List<int> {1, 4},
                new List<int> {1, 5}
            };
            (Dictionary<int, int> dataDict, Dictionary<int, int> frequencyDict, List<int> resultList) = FrequencyQueries.FrequeryQuery(queries);
            PrintList(resultList);

            queries = new List<List<int>>
            {
                new List<int> {1, 1},
                new List<int> {1, 2},
                new List<int> {1, 3},
                new List<int> {2, 3},
                new List<int> {3, 1}
            };
            (dataDict, frequencyDict, resultList) = FrequencyQueries.FrequeryQuery(queries);                      // [1]
            PrintList(resultList);
        }

        private static void PrintList(List<int> itemList)
        {
            if (itemList.Count == 0)
            {
                Console.WriteLine("Empty");
                return;
            }

            Console.Write("[");
            foreach (int item in itemList)
            {
                Console.Write($"{item} ");
            }
            Console.Write("]");

            Console.WriteLine();
        }
    }

    public static class FrequencyQueries
    {
        public static (Dictionary<int, int>, Dictionary<int, int>, List<int>) FrequeryQuery(List<List<int>> queries)
        {
            Dictionary<int, int> dataDict = new Dictionary<int, int>();
            Dictionary<int, int> frequencyDict = new Dictionary<int, int>();
            List<int> resultList = new List<int>();

            foreach (List<int> query in queries)
            {
                int command = query[0];
                int value = query[1];
                int frequency;
                int previousFrequency;

                Console.WriteLine($"Before: comand = {command}, value = {value}");

                switch (command)
                {
                    case 1:
                        if (!dataDict.ContainsKey(value))
                        {
                            frequency = 1;
                            dataDict[value] = frequency;
                            AddFrequency(frequencyDict, frequency);
                        }
                        else
                        {
                            previousFrequency = dataDict[value];
                            RemoveFrequency(frequencyDict, previousFrequency);

                            frequency = dataDict[value]++;
                            AddFrequency(frequencyDict, frequency);
                        }
                        break;

                    case 2:
                        if (dataDict.ContainsKey(value))
                        {
                            if (dataDict[value] > 1)
                            {
                                previousFrequency = dataDict[value];
                                RemoveFrequency(frequencyDict, previousFrequency);

                                frequency = dataDict[value]--;
                                AddFrequency(frequencyDict, frequency);
                            }
                            else
                            {
                                previousFrequency = 1;
                                RemoveFrequency(frequencyDict, previousFrequency);

                                dataDict.Remove(value);
                            }
                        }
                        break;

                    case 3:
                        int result = frequencyDict.ContainsKey(value) ? 1 : 0;
                        Console.WriteLine(result);
                        resultList.Add(result);
                        break;
                }
            }

            return (dataDict, frequencyDict, resultList);
        }

        private static void AddFrequency(Dictionary<int, int> frequencyDict, int frequency)
        {
            if (!frequencyDict.ContainsKey(frequency))
            {
                frequencyDict[frequency] = 1;
            }
            else
            {
                frequencyDict[frequency]++;
            }
        }

        private static void RemoveFrequency(Dictionary<int, int> frequencyDict, int frequency)
        {
            if (frequencyDict[frequency] > 1)
            {
                frequencyDict[frequency]--;
            }
            else
            {
                frequencyDict.Remove(frequency);
            }
        }
    }
}
