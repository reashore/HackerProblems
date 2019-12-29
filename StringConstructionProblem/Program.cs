using System;
using System.Linq;

namespace StringConstructionProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string s = "abcd";
            int cost = StringConstruction(s);                   // 4
            Console.WriteLine($"cost = {cost}");

            s = "abab";
            cost = StringConstruction(s);                       // 2
            Console.WriteLine($"cost = {cost}");
        }

        private static int StringConstruction(string s)
        {
            return s.Distinct().Count();
        }
    }
}
