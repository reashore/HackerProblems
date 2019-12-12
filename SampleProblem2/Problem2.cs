using System.Collections.Generic;

namespace SampleProblem2
{
    public static class Problem2
    {
        public static int GeneralizedGreatestCommonDivisor(int[] array)
        {
            int arrayLength = array.Length;
            List<int> gcdList = new List<int>();

            for (int n = 0; n < arrayLength - 1; n++)
            {
                int gcd = GreatestCommonDivisor(array[n], array[n + 1]);
                gcdList.Add(gcd);
            }

            int minGcd = 1;

            foreach (int gcd in gcdList)
            {
                if (gcd > minGcd)
                {
                    minGcd = gcd;
                }
            }

            return minGcd;
        }

        private static int GreatestCommonDivisor(int a, int b)
        {
            if (a < 0)
            {
                a = -a;
            }

            if (b < 0)
            {
                b = -b;
            }

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a == 0 ? b : a;
        }
    }
}