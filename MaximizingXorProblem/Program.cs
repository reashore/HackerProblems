using System;

namespace MaximizingXorProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int low = 10;
            int high = 15;
            int maxXor = MaximizingXor(low, high);                  // 7
            Console.WriteLine($"maxXor = {maxXor}");

            low = 11;
            high = 100;
            maxXor = MaximizingXor(low, high);                      // 127
            Console.WriteLine($"maxXor = {maxXor}");
        }

        private static int MaximizingXor(int low, int high)
        {
            int maxXor = 0;

            for (int n1 = low; n1 <= high; n1++)
            {
                for (int n2 = low; n2 <= high; n2++)
                {
                    bool condition = n1 <= n2;

                    if (!condition)
                    {
                        continue;
                    }

                    int xor = n1 ^ n2;

                    if (xor > maxXor)
                    {
                        maxXor = xor;
                    }
                }
            }

            return maxXor;
        }
    }
}
