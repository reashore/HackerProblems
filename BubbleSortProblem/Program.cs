using System;

namespace BubbleSortProblem
{
    internal class Program
    {
        internal static void Main()
        {
            int[] array = {6, 4, 1};
            CountSwaps(array);                          // 3

            array = new[] { 1, 2, 3 };
            CountSwaps(array);                          // 0

            array = new[] {3, 2, 1};
            CountSwaps(array);                          // 3

            array = new []{4, 2, 3, 1};                
            CountSwaps(array);                          // 5
        }

        private static void CountSwaps(int[] array)
        {
            int len = array.Length;
            int swaps = 0;

            for (int n1 = 0; n1 < len - 1; n1++)
            {
                for (int n2 = 0; n2 < len - 1; n2++)
                {
                    if (array[n2] > array[n2 + 1])
                    {
                        int temp = array[n2 + 1];
                        array[n2 + 1] = array[n2];
                        array[n2] = temp;
                        swaps++;
                    }
                }
            }

            Console.WriteLine($"Array is sorted in {swaps} swaps.");
            Console.WriteLine($"First Element: {array[0]}");
            Console.WriteLine($"Last Element: {array[len - 1]}");
            Console.WriteLine();
        }
    }
}
