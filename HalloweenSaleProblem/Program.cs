using System;

namespace HalloweenSaleProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int initialPrice;
            int discount;
            int thresholdPrice;
            int money;
            int numGames;

            initialPrice = 20;
            discount = 3;
            thresholdPrice = 6;
            money = 80;
            numGames = HowManyGames(initialPrice, discount, thresholdPrice, money);                     // 6
            Console.WriteLine($"numGames = {numGames}");

            initialPrice = 20;
            discount = 3;
            thresholdPrice = 6;
            money = 85;
            numGames = HowManyGames(initialPrice, discount, thresholdPrice, money);                    // 7
            Console.WriteLine($"numGames = {numGames}");

            initialPrice = 1;
            discount = 100;
            thresholdPrice = 1;
            money = 3;
            numGames = HowManyGames(initialPrice, discount, thresholdPrice, money);                    // 3
            Console.WriteLine($"numGames = {numGames}");

            initialPrice = 1;
            discount = 100;
            thresholdPrice = 1;
            money = 9777;
            numGames = HowManyGames(initialPrice, discount, thresholdPrice, money);                    // 9777
            Console.WriteLine($"numGames = {numGames}");

            initialPrice = 16;
            discount = 2;
            thresholdPrice = 1;
            money = 9981;
            numGames = HowManyGames(initialPrice, discount, thresholdPrice, money);                    // 9917
            Console.WriteLine($"numGames = {numGames}");
        }

        private static int HowManyGames(int initialPrice, int discount, int thresholdPrice, int money)
        {
            int numVideosPurchased = 0;
            int currentPrice = initialPrice;
            int amountPurchased = 0;
            bool firstVideo = true;

            while (true)
            {
                int currentDiscount;

                if (firstVideo && currentPrice > thresholdPrice)
                {
                    currentDiscount = 0;
                    firstVideo = false;
                }
                else
                {
                    currentDiscount = discount;
                }

                if (currentPrice - currentDiscount > thresholdPrice)
                {
                    currentPrice -= currentDiscount;
                }
                else
                {
                    currentPrice = thresholdPrice;
                }

                amountPurchased += currentPrice;

                if (amountPurchased <= money)
                {
                    numVideosPurchased++;
                }
                else
                {
                    break;
                }
            }

            return numVideosPurchased;
        }
    }
}
