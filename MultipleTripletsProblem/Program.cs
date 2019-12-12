using System;
using System.Collections.Generic;

namespace MultipleTripletsProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        public static void Main()
        {
            long ratio = 2;
            List<long> array = new List<long> {1, 2, 2, 4};
            long numberTriplets = CountTriplets(array, ratio);
            Console.WriteLine($"numberTriplets = {numberTriplets}");        // 2

            ratio = 3;
            array = new List<long> {1, 3, 9, 9, 27, 81};
            numberTriplets = CountTriplets(array, ratio);
            Console.WriteLine($"numberTriplets = {numberTriplets}");        // 6

            ratio = 5;
            array = new List<long> {1, 5, 5, 25, 125};
            numberTriplets = CountTriplets(array, ratio);
            Console.WriteLine($"numberTriplets = {numberTriplets}");        // 4

            ratio = 1;
            array = new List<long> {1, 1, 1};
            numberTriplets = CountTriplets(array, ratio);
            Console.WriteLine($"numberTriplets = {numberTriplets}");        // 1

            ratio = 1;
            array = new List<long> {1, 1, 1, 1};
            numberTriplets = CountTriplets(array, ratio);
            Console.WriteLine($"numberTriplets = {numberTriplets}");        // 1
        }

        private struct Triplet
        {
            public int I1;
            public int I2;
            public int I3;
        }

        private static long CountTriplets(List<long> arr, long r)
        {
            Dictionary<long, List<int>> dict = new Dictionary<long, List<int>>();
            int arrLen = arr.Count;
            List<Triplet> tripletList = new List<Triplet>();

            for (int n = 0; n < arrLen; n++)
            {
                long value = arr[n];

                if (!dict.ContainsKey(value))
                {
                    dict[value] = new List<int> {n};
                }
                else
                {
                    dict[value].Add(n);
                }
            }

            if (r == 1)
            {
                for (int n1 = 0; n1 < arrLen - 2; n1++)
                {
                    for (int n2 = n1 + 1; n2 < arrLen - 1; n2++)
                    {
                        for (int n3 = n2 + 1; n3 < arrLen; n3++)
                        {
                            Triplet triplet = new Triplet {I1 = 1, I2 = 1, I3 = 1};
                            tripletList.Add(triplet);
                        }
                    }
                }

                return tripletList.Count;
            }

            for (int n = 0; n < arrLen - 2; n++)
            {
                long value1 = arr[n];
                long value2 = value1 * r;
                long value3 = value1 * r * r;
                bool dictContainsBothKeys = dict.ContainsKey(value2) && dict.ContainsKey(value3);

                if (!dictContainsBothKeys)
                {
                    continue;
                }

                List<int> indexList1 = dict[value2];
                List<int> indexList2 = dict[value3];

                foreach (var index1 in indexList1)
                {
                    foreach (var index2 in indexList2)
                    {
                        Triplet triplet = new Triplet
                        {
                            I1 = n, 
                            I2 = index1, 
                            I3 = index2
                        };

                        tripletList.Add(triplet);
                    }
                }
            }

            int numberTriplets = tripletList.Count;

            return numberTriplets;
        }
    }
}
