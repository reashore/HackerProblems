using System;

namespace FindTheMedianProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array = {0, 1, 2, 4, 6, 5, 3};
            int median = FindMedian(array);
            Console.WriteLine($"median = {median}");
        }

        private static int FindMedian(int[] array)
        {
            int len = array.Length;
            bool isEven = len % 2 == 0;

            if (isEven)
            {
                throw new ArgumentException("array length must be odd");
            }

            Array.Sort(array);
            int median = array[len / 2];

            return median;
        }
    }
}
