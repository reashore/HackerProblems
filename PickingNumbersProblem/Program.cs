using System;
using System.Collections.Generic;

namespace PickingNumbersProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            List<int> numList = new List<int> {1, 1, 2, 2, 4, 4, 5, 5, 5};
            int maxLengthArray = PickNumbers(numList);                           // 5
            Console.WriteLine($"maxLengthArray = {maxLengthArray}");

            numList = new List<int> {4, 6, 5, 3, 3, 1};
            maxLengthArray = PickNumbers(numList);                               // 3
            Console.WriteLine($"maxLengthArray = {maxLengthArray}");

            numList = new List<int> {1, 2, 2, 3, 1, 2};
            maxLengthArray = PickNumbers(numList);                               // 5
            Console.WriteLine($"maxLengthArray = {maxLengthArray}");
        }

        private static int PickNumbers(List<int> numList)
        {
            int len = numList.Count;
            numList.Sort();
            int maxLen = 0;

            for (int n = 0; n < len; n++)
            {
                List<int> diffList = new List<int>();
                int firstValue = numList[n];
                diffList.Add(firstValue);

                for (int l = 1; n + l < len; l++)
                {
                    int currentValue = numList[n + l];
                    int diff = Math.Abs(currentValue - firstValue);

                    if (diff > 1)
                    {
                        break;
                    }

                    diffList.Add(currentValue);
                }

                int diffListLen = diffList.Count;

                if (diffListLen > maxLen)
                {
                    maxLen = diffListLen;
                }
            }

            return maxLen;
        }
    }
}
