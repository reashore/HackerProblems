using System;
using System.Linq;

namespace HurdleRaceProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int maxJumpHeight = 1;
            int[] heightArray = {1, 2, 3, 3, 2};
            int numberDoses = HurdleRace(maxJumpHeight, heightArray);               // 2
            Console.WriteLine($"numberDoses = {numberDoses}");

            maxJumpHeight = 4;
            heightArray = new[] {1, 6, 3, 5, 2};
            numberDoses = HurdleRace(maxJumpHeight, heightArray);                   // 2
            Console.WriteLine($"numberDoses = {numberDoses}");

            maxJumpHeight = 7;
            heightArray = new[] {2, 5, 4, 5, 2};
            numberDoses = HurdleRace(maxJumpHeight, heightArray);                   // 0
            Console.WriteLine($"numberDoses = {numberDoses}");
        }

        private static int HurdleRace(int maxJumpHeight, int[] heightArray)
        {
            int maxHeight = heightArray.Max();
            int dosesNeeded = maxHeight - maxJumpHeight;
            return dosesNeeded > 0 ? dosesNeeded : 0;
        }
    }
}
