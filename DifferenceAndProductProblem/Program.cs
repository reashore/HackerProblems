using System;
using static System.Console;

namespace DifferenceAndProductProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            int difference = 1;
            int product = 2;
            int expected = 4;
            Test(difference, product, expected);

            difference = 0;
            product = 4;
            expected = 2;
            Test(difference, product, expected);

            difference = -1;
            product = 1;
            expected = 0;
            Test(difference, product, expected);
        }

        private static int Solve(int difference, int product)
        {
            int numberPairs = 0;

            double radical = Math.Sqrt(difference * difference + 4 * product);
            int a1 = difference + (int) radical;
            int a2 = difference - (int) radical;

            int b1 = a1 - difference;
            int b2 = a2 - difference;



            return numberPairs;
        }

        private static void Test(int difference, int product, int expected)
        {
            int actual = Solve(difference, product);

            if (actual != expected)
            {
                WriteLine($"difference = {difference}, product = {product}, actual = {actual}, expected = {expected}");
            }
            else
            {
                WriteLine("Passed");
            }
        }
    }
}
