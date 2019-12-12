using System;

namespace ElectronicsShopProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] keyboards = {40, 50, 60};
            int[] drives = {5, 8, 12};
            int money = 60;
            int moneySpent = GetMoneySpent(keyboards, drives, money);               // 58
            Console.WriteLine($"moneySpent = {moneySpent}");

            keyboards = new[] {3, 1};
            drives = new[] {5, 2, 8};
            money = 10;
            moneySpent = GetMoneySpent(keyboards, drives, money);                   // 9
            Console.WriteLine($"moneySpent = {moneySpent}");

            keyboards = new [] {4};
            drives = new [] {5};
            money = 5;
            moneySpent = GetMoneySpent(keyboards, drives, money);                   // -1
            Console.WriteLine($"moneySpent = {moneySpent}");
        }

        private static int GetMoneySpent(int[] keyboards, int[] drives, int money)
        {
            int maxPrice = 0;
            bool canAfford = false;

            foreach (int keyboard in keyboards)
            {
                foreach (int drive in drives)
                {
                    int price = keyboard + drive;

                    if (price <= money)
                    {
                        canAfford = true;

                        if (price >= maxPrice)
                        {
                            maxPrice = price;
                        }
                    }
                }
            }

            return canAfford ? maxPrice : -1;
        }
    }
}
