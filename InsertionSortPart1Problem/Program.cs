using System;

namespace InsertionSortPart1Problem
{
    internal static class Program
    {
        internal static void Main()
        {
            int n = -1;
            int[] array;

            array = new[] { 2, 4, 6, 8, 3 };
            InsertionSort1(n, array);
            Console.WriteLine();

            array = new[] { 1, 3, 5, 9, 13, 22, 27, 35, 46, 51, 55, 83, 87, 23 };
            InsertionSort1(n, array);
            Console.WriteLine();

            array = new[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 };
            InsertionSort1(n, array);
            Console.WriteLine();

            //array = new[] {2, 3, 1};
            //InsertionSort1(n, array);
            //Console.WriteLine();
        }

        private static void InsertionSort1(int length, int[] array)
        {
            int len = array.Length;
            int valueToInsert = array[len - 1];
            bool insertedValue = false;

            for (int n = len - 1; 0 < n; n--)
            {
                if (valueToInsert < array[n - 1])
                {
                    array[n] = array[n - 1];
                }
                else
                {
                    array[n] = valueToInsert;
                    insertedValue = true;
                }

                Print(array);

                if (insertedValue)
                {
                    break;
                }
            }

            if (!insertedValue)
            {
                array[0] = valueToInsert;
                Print(array);
            }
        }

        private static void Print(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }
    }
}
