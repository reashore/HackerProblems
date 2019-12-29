using System;

namespace NimGameProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] pile;
            string result;

            pile = new[] {1, 1};
            result = NimGame(pile);                  // Second
            Console.WriteLine($"result = {result}");

            pile = new[] {2, 1, 4};
            result = NimGame(pile);                  // First
            Console.WriteLine($"result = {result}");
        }

        private static string NimGame(int[] pile)
        {
            int result = pile[0];

            for (int n = 1; n < pile.Length; n++)
            {
                int value = pile[n];
                result ^= value;
            }

            return result != 0 ? "First" : "Second";
        }
    }
}
