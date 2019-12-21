using Combinatorics.Collections;
using System;
using System.Collections.Generic;

namespace Permutations
{
    // https://trycatch.me/combinatorics-in-net-part-i-permutations-combinations-variations/

    internal static class Program
    {
        internal static void Main()
        {
            GetPermutations();

            Console.WriteLine();
        }

        private static void GetPermutations()
        {
            List<int> integers = new List<int> { 1, 2, 3 };

            Permutations<int> p = new Permutations<int>(integers);

            foreach (IList<int> item in p)
            {
                string line = string.Join(",", item);
                Console.WriteLine(line);
            }
        }
    }
}
