using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceEquationProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] p = {5, 2, 1, 3, 4};
            int[] result = PermutationEquation(p);
            int[] expected = {4, 2, 5, 1, 3};
            Console.WriteLine(result.SequenceEqual(expected));

            p = new[] {2, 3, 1};
            result = PermutationEquation(p);
            expected = new[] {2, 3, 1};
            Console.WriteLine(result.SequenceEqual(expected));

            p = new[] {4, 3, 5, 1, 2};
            result = PermutationEquation(p);
            expected = new[] {1, 3, 5, 4, 2};
            Console.WriteLine(result.SequenceEqual(expected));
        }

        private static int[] PermutationEquation(int[] p)
        {
            int len = p.Length;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            List<int> result = new List<int>();

            for (int n = 0; n < len; n++)
            {
                int value = p[n];
                int index = n + 1;

                dictionary[value] = index;
            }

            for (int index1 = 1; index1 <= len; index1++)
            {
                int index2 = dictionary[index1];
                int index3 = dictionary[index2];

                result.Add(index3);
            }

            return result.ToArray();
        }
    }
}
