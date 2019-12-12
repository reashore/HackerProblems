using System;
using System.Collections.Generic;
using System.Linq;

namespace CutSticksProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array;
            int[] remaining;
            int[] expectedRemaining;

            array = new[] { 1, 2, 3 };
            remaining = CutTheSticks(array);
            expectedRemaining = new[] { 3, 2, 1 };
            PrintList(remaining);
            PrintList(expectedRemaining);
            Console.WriteLine(remaining.SequenceEqual(expectedRemaining));
            Console.WriteLine("*********************");

            array = new[] { 5, 4, 4, 2, 2, 8 };
            remaining = CutTheSticks(array);
            expectedRemaining = new[] { 6, 4, 2, 1 };
            PrintList(remaining);
            PrintList(expectedRemaining);
            Console.WriteLine(remaining.SequenceEqual(expectedRemaining));
            Console.WriteLine("*********************");

            array = new[] { 1, 2, 3, 4, 3, 3, 2, 1 };
            remaining = CutTheSticks(array);
            expectedRemaining = new[] { 8, 6, 4, 1 };
            PrintList(remaining);
            PrintList(expectedRemaining);
            Console.WriteLine(remaining.SequenceEqual(expectedRemaining));
            Console.WriteLine("*********************");

            array = new[] { 8, 8, 14, 10, 3, 5, 14, 12 };
            remaining = CutTheSticks(array);
            expectedRemaining = new[] { 8, 7, 6, 4, 3, 2 };
            PrintList(remaining);
            PrintList(expectedRemaining);
            Console.WriteLine(remaining.SequenceEqual(expectedRemaining));
            Console.WriteLine("*********************");

            array = CreateTestArray();
            remaining = CutTheSticks(array);
            expectedRemaining = new[] {1000};
            PrintList(remaining);
            PrintList(expectedRemaining);
            Console.WriteLine(remaining.SequenceEqual(expectedRemaining));
            Console.WriteLine("*********************");
        }

        private static int[] CutTheSticks(int[] array)
        {
            List<int> remainingList = new List<int>();

            while (true)
            {
                int remaining = array.Length;
                remainingList.Add(remaining);
                int minValue = array.Min();

                if (minValue == 1)
                {
                    int maxValue = array.Max();

                    if (maxValue == 1)
                    {
                        break;
                    }
                }

                array = CutSticks(array);

                if (array.Length == 0)
                {
                    remainingList.Add(array.Length);
                    break;
                }

                int minLen = array.Min();
                int maxLen = array.Max();
                bool minAndMaxAreSame = minLen == maxLen;

                if (minAndMaxAreSame)
                {
                    remainingList.Add(array.Length);
                    break;
                }
            }

            return remainingList.ToArray();
        }

        private static int[] CutSticks(int[] array)
        {
            List<int> results = new List<int>();
            int len = array.Length;
            int minValue = array.Min();

            for (int n = 0; n < len; n++)
            {
                array[n] -= minValue;
            }

            foreach (int element in array)
            {
                if (element > 0)
                {
                    results.Add(element);
                }
            }

            int[] temp = results.ToArray();

            return temp;
        }

        private static void PrintList(int[] array)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", array));
            Console.Write("]");
            Console.WriteLine();
        }

        private static int[] CreateTestArray()
        {
            List<int> list = new List<int>();

            for (int n = 1; n <= 1000; n++)
            {
                list.Add(1);
            }

            return list.ToArray();
        }
    }
}
