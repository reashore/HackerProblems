using System;
using System.Collections.Generic;
using System.Linq;

namespace MarcsCakewalkProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] calorieArray;
            long milesWalked;

            calorieArray = new[] { 5, 10, 7 };
            milesWalked = MarcsCakewalk(calorieArray);                              // 44
            Console.WriteLine($"milesWalked = {milesWalked}");

            calorieArray = CreateTestInput();
            milesWalked = MarcsCakewalk(calorieArray);                               // 59715404338867
            Console.WriteLine($"milesWalked = {milesWalked}");
        }

        private static long MarcsCakewalk(int[] calorieArray)
        {
            int len = calorieArray.Length;
            List<int> sortedCalorieArray = calorieArray.OrderByDescending(c => c).ToList();
            long milesWalked = 0;

            for (int n = 0; n < len; n++)
            {
                double factor = Math.Pow(2, n);
                long calorie = sortedCalorieArray[n];
                milesWalked += (long) factor * calorie;
                //Console.WriteLine($"2 ^ {n} * {calorie}");
            }

            return milesWalked;
        }

        private static int[] CreateTestInput()
        {
            int[] array =
            {
                819, 701, 578, 403, 50, 400, 983, 665, 510, 523, 696, 532, 51, 449, 333, 234, 958, 460, 277, 347, 950, 53, 123, 227, 646, 190, 938, 61, 409, 110, 61, 178, 659, 989, 625, 237, 944, 550, 954, 439
            };

            return array;
        }
    }
}
