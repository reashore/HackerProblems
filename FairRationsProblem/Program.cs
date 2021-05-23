using System;
using System.Collections.Generic;

namespace FairRationsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            List<int> array = new List<int>{4, 5, 6, 7};
            string minLoaves = FairRations(array);                   // 4
            Console.WriteLine($"minLoaves = {minLoaves}");

            array = new List<int>{ 2, 3, 4, 5, 6 };
            minLoaves = FairRations(array);                          // 4
            Console.WriteLine($"minLoaves = {minLoaves}");

            array = new List<int>() { 1, 2 };
            minLoaves = FairRations(array);                          // NO
            Console.WriteLine($"minLoaves = {minLoaves}");
        }

        private static string FairRations(List<int> array)
        {
            if (IsArraySumOdd(array))
            {
                return "NO";
            }

            int len = array.Count;
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

            bool isEven = IsArrayAllEvenElements(array);
            return isEven ? numLoaves.ToString() : "NO";
        }

        private static bool IsArraySumOdd(List<int> array)
        {
            int sum = 0;

            foreach (int element in array)
            {
                sum += element;
            }

            bool isArraySumOdd = sum % 2 != 0;
            return isArraySumOdd;
        }

        private static void GiveLoaf(List<int> array, int n)
        {
            int len = array.Count;

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

        private static bool IsArrayAllEvenElements(List<int> array)
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
