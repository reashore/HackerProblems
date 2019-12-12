using System;
using System.Collections.Generic;

namespace BonAppetitProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            List<int> bill = new List<int> {2, 4, 6};
            int k = 2;
            int chargedRefund = 3;
            BonAppetit(bill, k, chargedRefund);                 // Bon Appetit

            bill = new List<int> {3, 10, 2, 9};
            k = 1;
            chargedRefund = 12;
            BonAppetit(bill, k, chargedRefund);                 // 5

            bill = new List<int> {3, 10, 2, 9};
            k = 1;
            chargedRefund = 7;                                                  // Bon Appetit
            BonAppetit(bill, k, chargedRefund);
        }

        private static void BonAppetit(List<int> bill, int annasIndex, int annaPaid)
        {
            int halfBill = Sum(bill) / 2;

            int deletedItemCost = bill[annasIndex];
            List<int> annasList = new List<int>(bill);
            annasList.RemoveAt(annasIndex);
            int annasBill = Sum(annasList) / 2;

            int actualRefund = halfBill - annasBill;
            int paidRefund = halfBill - annaPaid;

            bool correct = actualRefund == paidRefund;
            int diff = actualRefund - paidRefund;
            string message = correct ? "Bon Appetit" : $"{diff}";
            Console.WriteLine(message);
        }

        private static int Sum(List<int> list)
        {
            int sum = 0;

            foreach (int item in list)
            {
                sum += item;
            }

            return sum;
        }
    }
}
