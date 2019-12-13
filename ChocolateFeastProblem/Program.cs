using System;

namespace ChocolateFeastProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int moneyToSpend;
            int costPerBar;
            int numberWrappersForBar;
            int numberBars;

            moneyToSpend = 15;
            costPerBar = 3;
            numberWrappersForBar = 2;
            numberBars = ChocolateFeast(moneyToSpend, costPerBar, numberWrappersForBar);                // 9
            Console.WriteLine($"numberBars = {numberBars}");
            Console.WriteLine("************************************");

            moneyToSpend = 10;
            costPerBar = 2;
            numberWrappersForBar = 5;
            numberBars = ChocolateFeast(moneyToSpend, costPerBar, numberWrappersForBar);                // 6
            Console.WriteLine($"numberBars = {numberBars}");
            Console.WriteLine("************************************");

            moneyToSpend = 12;
            costPerBar = 4;
            numberWrappersForBar = 4;
            numberBars = ChocolateFeast(moneyToSpend, costPerBar, numberWrappersForBar);                // 3
            Console.WriteLine($"numberBars = {numberBars}");
            Console.WriteLine("************************************");

            moneyToSpend = 6;
            costPerBar = 2;
            numberWrappersForBar = 2;
            numberBars = ChocolateFeast(moneyToSpend, costPerBar, numberWrappersForBar);                // 5
            Console.WriteLine($"numberBars = {numberBars}");
            Console.WriteLine("************************************");
        }

        private static int ChocolateFeast(int moneyToSpend, int costPerBar, int numberWrappersForBar)
        {
            int numberBars = moneyToSpend / costPerBar;
            int totalBars = numberBars;
            int barsIn = numberBars;
            int wrappersIn = 0;

            while (true)
            {
                EatBars(barsIn, wrappersIn, out int barsOut, out int wrappersOut, numberWrappersForBar);
                Console.WriteLine($"({barsIn}, {wrappersIn}) => ({barsOut}, {wrappersOut})");
                totalBars += barsOut;

                if (barsOut == 0 && wrappersOut < numberWrappersForBar)
                {
                    break;
                }

                barsIn = barsOut;
                wrappersIn = wrappersOut;
            }

            return totalBars;
        }

        private static void EatBars(int barsIn, int wrappersIn, out int barsOut, out int wrappersOut, int numberWrappersForBar)
        {
            barsOut = 0;
            wrappersOut = 0;

            // convert bars to wrappers
            if (barsIn > 0)
            {
                wrappersIn += barsIn;
            }

            // convert wrappers to bars
            if (wrappersIn > 0 && wrappersIn >= numberWrappersForBar)
            {
                barsOut = wrappersIn / numberWrappersForBar;
                wrappersOut = wrappersIn % numberWrappersForBar;
            }
        }
    }
}
