using System.Collections.Generic;
using static System.Console;

namespace HalloweenPartyProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            var cuts = 5;
            var pieces = HalloweenParty(cuts);
            WriteLine($"cuts = {cuts}, pieces = {pieces}");

            cuts = 6;
            pieces = HalloweenParty(cuts);
            WriteLine($"cuts = {cuts}, pieces = {pieces}");

            cuts = 7;
            pieces = HalloweenParty(cuts);
            WriteLine($"cuts = {cuts}, pieces = {pieces}");

            cuts = 8;
            pieces = HalloweenParty(cuts);
            WriteLine($"cuts = {cuts}, pieces = {pieces}");

            Test1();
        }

        private static long HalloweenParty(int cuts)
        {
            long pieces;

            checked
            {
                bool even = cuts % 2 == 0;

                if (even)
                {
                    long temp = cuts / 2;
                    pieces = temp * temp;
                }
                else
                {
                    long temp = (cuts - 1) / 2;
                    pieces = temp * (temp + 1);
                }
            }

            return pieces;
        }

        private static void Test1()
        {
            List<int> cutList = new List<int>()
            {
                1856378,
                525494,
                4137970,
                952497,
                3477282,
                4915727,
                4743036,
                7987985,
                6440878,
                1523303
            };

            List<long> expectedList = new List<long>()
            {
                861534819721,
                69035986009,
                4280698930225,
                226812633752,
                3022872526881,
                6041092984632,
                5624097624324,
                15951976090056,
                10371227352721,
                580113007452
            };

            for (int n = 0; n < cutList.Count; n++)
            {
                long actual = HalloweenParty(cutList[n]);
                long expected = expectedList[n];

                if (actual != expected)
                {
                    WriteLine($"Failed for n = {n,2}: actual = {actual}, expected = {expected}");
                }
                else
                {
                    WriteLine($"Passed for n = {n,2}");
                }
            }
        }
    }
}
