using System;
using System.Linq;
using System.Numerics;

namespace BigSortingProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string[] array =
            {
                "31415926535897932384626433832795",
                "1",
                "3",
                "10",
                "3",
                "5"
            };
            string[] sortedArray = BigSorting(array);
            string[] expectedSortedArray =
            {
                "1",
                "3",
                "3",
                "5",
                "10",
                "31415926535897932384626433832795"
            };
            Console.WriteLine(sortedArray.SequenceEqual(expectedSortedArray));

            array = new[]
            {
                "1",
                "2",
                "100",
                "12303479849857341718340192371",
                "3084193741082937",
                "3084193741082938",
                "111",
                "200"
            };
            sortedArray = BigSorting(array);
            expectedSortedArray = new[]
            {
                "1",
                "2",
                "100",
                "111",
                "200",
                "3084193741082937",
                "3084193741082938",
                "12303479849857341718340192371"
            };
            Console.WriteLine(sortedArray.SequenceEqual(expectedSortedArray));
        }

        private static string[] BigSorting(string[] array)
        {
            return array.OrderBy(s => s.Length).ThenBy(s => s).ToArray();
        }

        private static string[] BigSorting2(string[] array)
        {
            int len = array.Length;
            BigInteger[] bigArray = new BigInteger[len];
            string[] sortedArray = new string[len];

            for (int n = 0; n < len; n++)
            {
                bigArray[n] = BigInteger.Parse(array[n]);
            }

            //Array.Sort(bigArray);
            QuickSort(bigArray);

            for (int n = 0; n < len; n++)
            {
                sortedArray[n] = bigArray[n].ToString();
            }

            return sortedArray;
        }

        private static void QuickSort(BigInteger[] array)
        {
            const int start = 0;
            int end = array.Length - 1;
            QuickSortInternal(array, start, end);
        }

        private static void QuickSortInternal(BigInteger[] arr, int start, int end)
        {
            if (start < end)
            {
                int i = Partition(arr, start, end);

                QuickSortInternal(arr, start, i - 1);
                QuickSortInternal(arr, i + 1, end);
            }
        }

        private static int Partition(BigInteger[] arr, int start, int end)
        {
            BigInteger temp;
            BigInteger p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }
    }
}
