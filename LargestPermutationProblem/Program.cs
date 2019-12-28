using System;
using System.Collections.Generic;
using System.Linq;

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
            array = new[] {4, 2, 3, 5, 1};
            largestPermutation = LargestPermutation(numberSwaps, array);              // 5 2 3 4 1
            Print(largestPermutation);

            numberSwaps = 1;
            array = new[] {2, 1, 3};
            largestPermutation = LargestPermutation(numberSwaps, array);              // 5 2 3 4 1
            Print(largestPermutation);

            numberSwaps = 1;
            array = new[] {2, 1};
            largestPermutation = LargestPermutation(numberSwaps, array);              // 2 1 (no swaps)
            Print(largestPermutation);
        }

        private static void Print(IEnumerable<int> array)
        {
            string line = string.Join(", ", array);
            Console.WriteLine(line);
        }

        private static int[] LargestPermutation(int numberSwaps, int[] array)
        {
            GetMinAndMax(array, out int min, out int max);
            Dictionary<int, int> occuranceDictionary = GetIndexes(array);
            int currentMax = max;
            int currentIndex = 0;

            for (int n = 1; n <= numberSwaps; n++)
            {

            }



            // values must be consecutive
            // get occurance count (maps value -> index)
            // how to update occurance count after swap?

            // find largest integer in array
            // swap to left-most position

            return array;
        }

        private static void GetMinAndMax(int[] array, out int min, out int max)
        {
            max = int.MinValue;
            min = int.MaxValue;

            foreach (int element in array)
            {
                if (element > max)
                {
                    max = element;
                }

                if (element < min)
                {
                    min = element;
                }
            }
        }

        private static void Swap(int highIndex, int lowIndex, int[] array)
        {

        }

        private static Dictionary<int, int> GetIndexes(int[] array)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (int element in array)
            {
                if (!dictionary.ContainsKey(element))
                {
                    dictionary[element] = 1;
                }
                else
                {
                    dictionary[element]++;
                }
            }

            return dictionary;
        }

    }
}
