using System;
using System.Text;

namespace StaircaseProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            CreateStaircase(0);
            Console.WriteLine();

            CreateStaircase(1);
            Console.WriteLine();

            CreateStaircase(4);
            Console.WriteLine();

            CreateStaircase(5);
            Console.WriteLine();

            CreateStaircase(100);
            Console.WriteLine();
        }

        private static void CreateStaircase(int n)
        {
            if (n == 0)
            {
                return;
            }

            for (int m = 1; m <= n; m++)
            {
                int numHashes = m;
                int numSpaces = n - m;

                string spacesString = CreateRepeatedString(' ', numSpaces);
                string hashesString = CreateRepeatedString('#', numHashes);

                string line = $"{spacesString}{hashesString}";
                Console.WriteLine(line);
            }
        }

        private static string CreateRepeatedString(char c, in int numChars)
        {
            StringBuilder sb = new StringBuilder();

            for (int n = 1; n <= numChars; n++)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
