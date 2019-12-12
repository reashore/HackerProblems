using System;

namespace BeautifulTripletsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] array = {1, 2, 4, 5, 7, 8, 10};
            int d = 3;
            int numTriplets = BeautifulTriplets(d, array);                      // 3
            Console.WriteLine($"numTriplets = {numTriplets}");

            array = new[] {2, 2, 3, 4, 5};
            d = 1;
            numTriplets = BeautifulTriplets(d, array);                          // 3
            Console.WriteLine($"numTriplets = {numTriplets}");
        }

        private static int BeautifulTriplets(int d, int[] array)
        {
            int len = array.Length;
            int numTriplets = 0;

            for (int n1 = 0; n1 < len; n1++)
            {
                for (int n2 = 0; n2 < len; n2++)
                {
                    if (n1 >= n2)
                    {
                        continue;
                    }

                    if (array[n2] - array[n1] != d)
                    {
                        continue;
                    }

                    for (int n3 = 0; n3 < len; n3++)
                    {
                        if (n2 >= n3)
                        {
                            continue;
                        }

                        if (array[n3] - array[n2] != d)
                        {
                            continue;
                        }

                        numTriplets++;
                    }
                }
            }

            return numTriplets;
        }
    }
}
