using System;
using System.Collections.Generic;

namespace IceCreamParlorProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            var money = 4;
            int[] priceArray = {1, 4, 5, 3, 2};
            int[] indices = IceCreamParlor(money, priceArray);              // 1 4
            Print(indices);

            money = 4;
            priceArray = new[] {2, 2, 4, 3};
            indices = IceCreamParlor(money, priceArray);                    // 1 2
            Print(indices);

            money = 6;
            priceArray = new[] {1, 3, 4, 5, 6};
            indices = IceCreamParlor(money, priceArray);                    // 1 4
            Print(indices);
        }

        private static void Print(IEnumerable<int> array)
        {
            Console.Write("[");

            foreach (int item in array)
            {
                Console.Write($"{item}, ");
            }

            Console.Write("]");
            Console.WriteLine();
        }

        private static int[] IceCreamParlor(int money, int[] priceArray)
        {
            int len = priceArray.Length;
            int n1Value = 0;
            int n2Value = 0;

            for (int n1 = 0; n1 < len; n1++)
            {
                for (int n2 = 0; n2 < len; n2++)
                {
                    bool condition = n1 < n2;

                    if (!condition)
                    {
                        continue;
                    }

                    int sum = priceArray[n1] + priceArray[n2];

                    if (sum == money)
                    {
                        n1Value = n1;
                        n2Value = n2;
                    }
                }
            }

            // convert to 1-based indexes
            n1Value++;
            n2Value++;

            return new[] {n1Value, n2Value};
        }
    }
}
