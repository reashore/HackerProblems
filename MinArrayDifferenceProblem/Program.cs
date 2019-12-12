using System;
using static System.Console;

namespace MinArrayDifferenceProblem
{
    public class Program
    {
        public static void Main()
        {
            int[] array = {3, -7, 0};
            int minAbsoluteDifference = MinimumAbsoluteDifference(array);
            WriteLine($"minAbsoluteDifference = {minAbsoluteDifference}");      // 3

            //array = new [] {-59, -36, -13, 1, -53, -92, -2, -96, -54, 75};
            //minAbsoluteDifference = MinimumAbsoluteDifference(array);
            //WriteLine($"minAbsoluteDifference = {minAbsoluteDifference}");      // 1

            //array = new [] { 1, -3, 71, 68, 17 };
            //minAbsoluteDifference = MinimumAbsoluteDifference(array);
            //WriteLine($"minAbsoluteDifference = {minAbsoluteDifference}");      // 3

            //array = new [] { 2, 3 };
            //minAbsoluteDifference = MinimumAbsoluteDifference(array);
            //WriteLine($"minAbsoluteDifference = {minAbsoluteDifference}");      // 1

            //const int arrayLen = 10 * 10 * 10 * 10 * 10;
            //array = new int[arrayLen];
            //for (int n = 0; n < arrayLen; n++)
            //{
            //    array[n] = n;
            //}
            //minAbsoluteDifference = MinimumAbsoluteDifference(array);
            //WriteLine($"minAbsoluteDifference = {minAbsoluteDifference}");      // 
        }

        private static int MinimumAbsoluteDifference(int[] array)
        {
            int arrayLen = array.Length;
            int minAbsoluteDifference = int.MaxValue;

            for (int n1 = 0; n1 < arrayLen; n1++)
            {
                for (int n2 = n1 + 1; n2 < arrayLen; n2++)
                {
                    //if (n2 == n1)
                    //{
                    //    continue;
                    //}

                    WriteLine($"({n1}, {n2})");

                    int difference = array[n1] - array[n2];

                    if (difference < 0)
                    {
                        difference = -difference;
                    }

                    if (difference < minAbsoluteDifference)
                    {
                        minAbsoluteDifference = difference;
                    }
                }
            }

            return minAbsoluteDifference;
        }
    }
}
