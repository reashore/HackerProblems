using System;
using System.Collections.Generic;

namespace LargestPermutationProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int numberSwaps;
            int[] array;
            int[] largestPermutation;

            numberSwaps = 1;
            array = new[] { 5, 4, 3, 1, 2 };
            largestPermutation = LargestPermutation(numberSwaps, array);              // 5 4 3 2 1
            Print(largestPermutation);

            numberSwaps = 1;
            array = new[] { 4, 2, 3, 5, 1 };
            largestPermutation = LargestPermutation(numberSwaps, array);              // 5 2 3 4 1
            Print(largestPermutation);

            numberSwaps = 2;
            array = new[] { 4, 2, 3, 5, 1 };
            largestPermutation = LargestPermutation(numberSwaps, array);              // 5 4 3 2 1
            Print(largestPermutation);

            numberSwaps = 3;
            array = new[] { 4, 2, 3, 5, 1 };
            largestPermutation = LargestPermutation(numberSwaps, array);              // 5 4 3 2 1
            Print(largestPermutation);

            numberSwaps = 1;
            array = new[] { 2, 1, 3 };
            largestPermutation = LargestPermutation(numberSwaps, array);              // 3 1 2
            Print(largestPermutation);

            numberSwaps = 1;
            array = new[] { 2, 1 };
            largestPermutation = LargestPermutation(numberSwaps, array);              // 2 1
            Print(largestPermutation);

            numberSwaps = 1;
            array = new[] { 1 };
            largestPermutation = LargestPermutation(numberSwaps, array);              // 1
            Print(largestPermutation);
        }

        private static void Print(IEnumerable<int> array)
        {
            string line = string.Join(", ", array);
            Console.WriteLine(line);
        }

        private static int[] LargestPermutation(int totalNumberSwaps, int[] array)
        {
            int arrayLen = array.Length;
            const int minValue = 1;
            int maxValue = arrayLen;
            Dictionary<int, int> indexDictionary = GetIndexes(array);
            int rightValue = maxValue;
            int leftIndex = 0;
            int numberSwaps = 0;

            while (true)
            {
                bool condition1;
                bool condition2;
                int rightIndex = indexDictionary[rightValue];

                if (leftIndex == rightIndex)
                {
                    rightValue--;
                    leftIndex++;
                    condition1 = rightValue < minValue;
                    condition2 = leftIndex == arrayLen - 1;

                    if (condition1 || condition2)
                    {
                        break;
                    }

                    continue;
                }

                int leftValue = array[leftIndex];
                Swap(leftIndex, rightIndex, array);
                numberSwaps++;

                if (numberSwaps == totalNumberSwaps)
                {
                    break;
                }

                indexDictionary[leftValue] = rightIndex;

                rightValue--;
                leftIndex++;
                condition1 = rightValue < minValue;
                condition2 = leftIndex == arrayLen - 1;

                if (condition1 || condition2)
                {
                    break;
                }
            }

            return array;
        }

        private static void Swap(int leftIndex, int rightIndex, int[] array)
        {
            int temp = array[leftIndex];
            array[leftIndex] = array[rightIndex];
            array[rightIndex] = temp;
        }

        private static Dictionary<int, int> GetIndexes(int[] array)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int index = 0; index < array.Length; index++)
            {
                int value = array[index];
                dictionary[value] = index;
            }

            return dictionary;
        }
    }
}
