using System;

namespace StrangeGridAgainProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main(string[] args)
        {
            // maxInt  = 2147483647
            // maxUInt = 4294967295
            //           5000000058

            int row = 6;
            int col = 3;
            long value = StrangeGrid(row, col);
            Console.WriteLine($"Grid({row}, {col}) = {value}");                 // 25

            row = 1000000011;
            col = 5;
            value = StrangeGrid(row, col);
            Console.WriteLine($"Grid({row}, {col}) = {value}");                 // 5000000058
        }

        private static long StrangeGrid(int row, int col)
        {
            long value;

            checked
            {
                long longRow = row;
                long longCol = col;
                long term1 = 10 * ((longRow - 1) / 2);
                long term2 = 2 * (longCol - 1);
                long term3 = 1 - longRow % 2;
                value = term1 + term2 + term3;
            }

            return value;
        }
    }
}
