using System;

namespace TaumBirthdayProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int numBlack;
            int numWhite;
            int blackCost;
            int whiteCost;
            int conversionCost;
            long totalCost;

            numBlack = 10;
            numWhite = 10;
            blackCost = 1;
            whiteCost = 1;
            conversionCost = 1;
            totalCost = TaumBday(numBlack, numWhite, blackCost, whiteCost, conversionCost);             // 20
            Console.WriteLine($"totalCost = {totalCost}");

            numBlack = 5;
            numWhite = 9;
            blackCost = 2;
            whiteCost = 3;
            conversionCost = 4;
            totalCost = TaumBday(numBlack, numWhite, blackCost, whiteCost, conversionCost);             // 37
            Console.WriteLine($"totalCost = {totalCost}");

            numBlack = 3;
            numWhite = 6;
            blackCost = 9;
            whiteCost = 1;
            conversionCost = 1;
            totalCost = TaumBday(numBlack, numWhite, blackCost, whiteCost, conversionCost);             // 12
            Console.WriteLine($"totalCost = {totalCost}");

            numBlack = 7;
            numWhite = 7;
            blackCost = 4;
            whiteCost = 2;
            conversionCost = 1;
            totalCost = TaumBday(numBlack, numWhite, blackCost, whiteCost, conversionCost);             // 35
            Console.WriteLine($"totalCost = {totalCost}");

            numBlack = 3;
            numWhite = 3;
            blackCost = 1;
            whiteCost = 9;
            conversionCost = 2;
            totalCost = TaumBday(numBlack, numWhite, blackCost, whiteCost, conversionCost);             // 12
            Console.WriteLine($"totalCost = {totalCost}");

            numBlack = 27984;
            numWhite = 1402;
            blackCost = 619246;
            whiteCost = 615589;
            conversionCost = 247954;
            totalCost = TaumBday(numBlack, numWhite, blackCost, whiteCost, conversionCost);             // 18192035842
            Console.WriteLine($"totalCost = {totalCost}");
        }

        private static long TaumBday(int b, int w, int bc, int wc, int z)
        {
            long numBlack = b;
            long numWhite = w;
            long blackCost = bc;
            long whiteCost = wc;
            long conversionCost = z;
            long totalCost;
            long costOfConversion;
            long diffCost = blackCost - whiteCost;

            if (blackCost > whiteCost && diffCost > conversionCost)
            {
                costOfConversion = numBlack * conversionCost;
                totalCost = (numBlack + numWhite) * whiteCost + costOfConversion;
            }
            else if (whiteCost > blackCost && -diffCost > conversionCost)
            {
                costOfConversion = numWhite * conversionCost;
                totalCost = (numBlack + numWhite) * blackCost + costOfConversion;
            }
            else
            {
                totalCost = numBlack * blackCost + numWhite * whiteCost;
            }

            return totalCost;
        }
    }
}
