using System;

namespace CamelCaseProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            const string camelCaseString = "saveChangesInTheEditor";
            int wordCount = CamelCase(camelCaseString);
            Console.WriteLine($"wordCount = {wordCount}");
        }

        private static int CamelCase(string s)
        {
            int numWords = 1;

            foreach (char c in s)
            {
                if (char.IsUpper(c))
                {
                    numWords++;
                }
            }

            return numWords;
        }
    }
}
