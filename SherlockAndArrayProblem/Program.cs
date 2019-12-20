using System;
using System.Collections.Generic;
using System.Linq;

namespace SherlockAndArrayProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            RunSpecialTests();
        }

        private static void RunSpecialTests()
        {
            List<int> array = new List<int> { 1, 1, 4, 1, 1 };
            string result = BalancedSums(array);                // YES
            Console.WriteLine($"result = {result}");

            array = new List<int> { 2, 0, 0, 0 };
            result = BalancedSums(array);                        // YES
            Console.WriteLine($"result = {result}");

            array = new List<int> { 0, 0, 2, 0 };
            result = BalancedSums(array);                        // YES
            Console.WriteLine($"result = {result}");

            array = new List<int> { 1, 2, 3 };
            result = BalancedSums(array);                        // NO
            Console.WriteLine($"result = {result}");

            array = new List<int> { 1, 2, 3, 3 };
            result = BalancedSums(array);                        // YES
            Console.WriteLine($"result = {result}");

            array = new List<int> { 1, 2, 3, 4, 6 };
            result = BalancedSums(array);                        // YES
            Console.WriteLine($"result = {result}");

            array = new List<int> { 75, 26, 45, 72, 81, 47, 29, 97, 2, 75, 25, 82, 84, 17, 56, 32, 2, 28, 37, 57, 39, 18, 11, 79, 6, 40, 68, 68, 16, 40, 63, 93, 49, 91, 10, 55, 68, 31, 80, 57, 18, 34, 28, 76, 55, 21, 80, 22, 45, 11, 67, 67, 74, 91, 4, 35, 34, 65, 80, 21, 95, 1, 52, 25, 31, 2, 53, 96, 22, 89, 99, 7, 66, 32, 2, 68, 33, 75, 92, 84, 10, 94, 28, 54, 12, 9, 80, 43, 21, 51, 92, 20, 97, 7, 25, 67, 17, 38, 100, 86 };
            result = BalancedSums(array);                        // NO
            Console.WriteLine($"result = {result}");

            array = new List<int> {83, 20, 6, 81, 58, 59, 53, 2, 54, 62, 25, 35, 79, 64, 27, 49, 32, 95, 100, 20, 58, 39, 92, 30, 67, 89, 58, 81, 100, 66, 73, 29, 75, 81, 70, 55, 18, 28, 7, 35, 98, 52, 30, 11, 69, 48, 84, 54, 13, 14, 15, 86, 34, 82, 92, 26, 8, 53, 62, 57, 50, 31, 61, 85, 88, 5, 80, 64, 90, 52, 47, 43, 40, 93, 69, 70, 16, 43, 7, 25, 99, 12, 63, 99, 71, 76, 55, 17, 90, 43, 27, 20, 42, 84, 39, 96, 75, 1, 58, 49};
            result = BalancedSums(array);                        // NO
            Console.WriteLine($"result = {result}");
        }

        private static string BalancedSums(List<int> array)
        {
            int arraySum = array.Sum(x => x);
            int len = array.Count;

            if (len == 1)
            {
                return "YES";
            }

            int rightSum = arraySum - array[0];
            int leftSum = 0;

            for (int n = 0; n < len - 1; n++)
            {
                int difference = rightSum - leftSum;

                if (difference == 0)
                {
                    return "YES";
                }
                
                if (difference < 0)
                {
                    break;
                }

                leftSum += array[n];
                rightSum = arraySum - leftSum - array[n + 1];
            }

            return "NO";
        }
    }
}
