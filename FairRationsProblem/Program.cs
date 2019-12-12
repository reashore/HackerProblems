using System;

namespace FairRationsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array = {4, 5, 6, 7};
            int minLoaves = GetFairRations(array);                      // 4
            Console.WriteLine($"minLoaves = {minLoaves}");

            array = new[] { 2, 3, 4, 5, 6 };
            minLoaves = GetFairRations(array);                          // 4
            Console.WriteLine($"minLoaves = {minLoaves}");

            array = new[] { 1, 2 };
            minLoaves = GetFairRations(array);                          // 0 NO
            Console.WriteLine($"minLoaves = {minLoaves}");
        }

        private static void PrintArray(int[] array)
        {
            Console.Write("[");

            foreach (int element in array)
            {
                Console.Write($"{element}, ");
            }

            Console.Write("]");
            Console.WriteLine();
        }

        private static int GetFairRations(int[] array)
        {
            int sum = 0;

            foreach (int element in array)
            {
                sum += element;
            }

            bool isSumOdd = sum % 2 != 0;

            if (isSumOdd)
            {
                Console.WriteLine("NO");
                return 0;
            }

            int len = array.Length;
            int numLoaves = 0;

            for (int n = 0; n < len; n++)
            {
                if (array[n] % 2 == 0)
                {
                    continue;
                }

                GiveLoaf(array, n);
                numLoaves += 2;
            }

            bool isEven = IsEven(array);

            return isEven ? numLoaves : 0;
        }

        private static void GiveLoaf(int[] array, int n)
        {
            int len = array.Length;

            array[n]++;

            if (n == 0)
            {
                array[1]++;
            }
            else if (n == len - 1)
            {
                array[len - 2]++;
            }
            else
            {
                array[n + 1]++;
            }
        }

        private static bool IsEven(int[] array)
        {
            foreach (int element in array)
            {
                if (element % 2 != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
