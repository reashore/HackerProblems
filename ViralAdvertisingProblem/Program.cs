using System;

namespace ViralAdvertisingProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int days = 3;
            int totalLikes = ViralAdvertising(days);                   // 9
            Console.WriteLine($"totalLikes = {totalLikes}");

            days = 5;
            totalLikes = ViralAdvertising(days);                       // 24
            Console.WriteLine($"totalLikes = {totalLikes}");
        }

        private static int ViralAdvertising(int days)
        {
            const int numberInitialShares = 5;
            const int newSharesForEachLike = 3;
            int numberShares = numberInitialShares;
            int totalLikes = 0;
            int day = 1;

            while (true)
            {
                int numberLikes = numberShares / 2;
                totalLikes += numberLikes;

                if (day == days)
                {
                    break;
                }

                numberShares = numberLikes * newSharesForEachLike;
                day++;
            }

            return totalLikes;
        }
    }
}
