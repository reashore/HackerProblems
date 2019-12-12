using System;
using System.Collections.Generic;
using System.Linq;

namespace CircularArrayRotationProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array = {0, 1, 2, 3, 4, 5, 6, 7 };
            int numRotations = 3;
            RightCircularRotateArray(array, numRotations);

            array = new[] {3, 4, 5};
            numRotations = 2;
            int[] queries = {1, 2};
            int[] values = CircularArrayRotation(array, numRotations, queries);
            int[] expectedValues = {5, 3};
            Console.WriteLine(values.SequenceEqual(expectedValues));

            array = new[] {1, 2, 3};
            numRotations = 2;
            queries = new[] {0, 1, 2};
            values = CircularArrayRotation(array, numRotations, queries);
            expectedValues = new[] {2, 3, 1};
            Console.WriteLine(values.SequenceEqual(expectedValues));

            array = new[] {3};
            numRotations = 2;
            queries = new[] {0};
            values = CircularArrayRotation(array, numRotations, queries);
            expectedValues = new[] {3};
            Console.WriteLine(values.SequenceEqual(expectedValues));
        }

        private static int[] CircularArrayRotation(int[] array, int numRotations, int[] queries)
        {
            List<int> values = new List<int>();

            RightCircularRotateArray(array, numRotations);

            foreach (int index in queries)
            {
                int value = array[index];
                values.Add(value);
            }

            return values.ToArray();
        }

        private static void RightCircularRotateArray(int[] array, int numRotations)
        {
            int len = array.Length;

            if (len == 1)
            {
                return;
            }

            if (numRotations == 0)
            {
                return;
            }

            if (numRotations > len)
            {
                numRotations = numRotations % len;
            }

            int[] segment = new int[numRotations];

            for (int n = 0; n < numRotations; n++)
            {
                segment[n] = array[len - numRotations + n];
            }

            for (int n = 0; n < len - numRotations; n++)
            {
                int top = len - 1 - n;
                int bottom = top - numRotations;
                array[top] = array[bottom];
            }

            for (int n = 0; n < numRotations; n++)
            {
                array[n] = segment[n];
            }
        }
    }
}
