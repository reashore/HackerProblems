using System;

namespace UtopianTreeProblem
{
    internal class Program
    {
        internal static void Main()
        {
            int n = 0;
            int treeHeight = GetUtopianTreeGrowth(n);                            // 1
            Console.WriteLine($"treeHeight({n}) = {treeHeight}");

            n = 1;
            treeHeight = GetUtopianTreeGrowth(n);                                // 2
            Console.WriteLine($"treeHeight({n}) = {treeHeight}");

            n = 2;
            treeHeight = GetUtopianTreeGrowth(n);                                // 3
            Console.WriteLine($"treeHeight({n}) = {treeHeight}");

            n = 3;
            treeHeight = GetUtopianTreeGrowth(n);                                // 6
            Console.WriteLine($"treeHeight({n}) = {treeHeight}");

            n = 4;
            treeHeight = GetUtopianTreeGrowth(n);                                // 7
            Console.WriteLine($"treeHeight({n}) = {treeHeight}");

            n = 5;
            treeHeight = GetUtopianTreeGrowth(n);                                // 14
            Console.WriteLine($"treeHeight({n}) = {treeHeight}");
        }

        private static int GetUtopianTreeGrowth(int n)
        {
            int treeHeight = 1;
            bool isSpring = true;

            for (int period = 0; period < n; period++)
            {
                if (isSpring)
                {
                    treeHeight *= 2;
                }
                else
                {
                    treeHeight += 1;
                }

                isSpring = !isSpring;
            }

            return treeHeight;
        }
    }
}
