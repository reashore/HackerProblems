using System;

namespace LargestRectangleProblem
{
    internal class Program
    {
        internal static void Main()
        {
            int[] h = {1, 2, 3, 4, 5};
            long maxArea = LargestRectangle(h);
            Console.WriteLine($"maxArea = {maxArea}");
        }

        private static long LargestRectangle(int[] h)
        {
            int len = h.Length;
            long maxArea = 0;

            for (int n1 = 0; n1 < len; n1++)
            {
                for (int n2 = 0; n2 < len; n2++)
                {
                    if (n1 >= n2)
                    {
                        continue;
                    }

                    int width = n2 - n1 + 1;
                    int minHeight = int.MaxValue;

                    for (int n = n1; n <= n2; n++)
                    {
                        if (h[n] < minHeight)
                        {
                            minHeight = h[n];
                        }
                    }

                    long area = width * minHeight;

                    if (area > maxArea)
                    {
                        maxArea = area;
                    }
                }
            }

            return maxArea;
        }
    }
}
