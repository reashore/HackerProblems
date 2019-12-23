using System;

namespace TowerBreakersProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int n = 2;
            int m = 2;
            int winningPlayer = TowerBreakers(n, m);                        // 2
            Console.WriteLine($"winningPlayer = {winningPlayer}");

            n = 1;
            m = 4;
            winningPlayer = TowerBreakers(n, m);                            // 1
            Console.WriteLine($"winningPlayer = {winningPlayer}");
        }

        private static int TowerBreakers(int n, int m)
        {
            return (m == 1 || n % 2 == 0 ? 2 : 1);
        }
    }
}
