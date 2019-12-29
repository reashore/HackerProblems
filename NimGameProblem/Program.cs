using System;

namespace NimGameProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] pile = new[] {1, 1};
            string result = NimGame(pile);                  // Second
            Console.WriteLine($"result = {result}");

            pile = new[] {2, 1, 4};
            result = NimGame(pile);                         // First
            Console.WriteLine($"result = {result}");
        }

        private static string NimGame(int[] pile)
        {
            // https://math.stackexchange.com/questions/416042/why-xor-operator-works

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
