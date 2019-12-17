using System;
using System.Text;

namespace FunnyStringProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            var inputString = "acxz";
            var result = FunnyString(inputString);      // Funny
            Console.WriteLine($"result = {result}");

            inputString = "bcxz";
            result = FunnyString(inputString);                // Not Funny
            Console.WriteLine($"result = {result}");

            inputString = "lmnop";
            result = FunnyString(inputString);                // Funny
            Console.WriteLine($"result = {result}");
        }

        private static string FunnyString(string inputString)
        {
            int len = inputString.Length;
            string reversedString = Reverse(inputString);
            bool differenceStringsAreEqual = true;

            for (int n = 0; n < len / 2; n++)
            {
                char first1 = inputString[n];
                char next1 = inputString[n + 1];
                int difference1 = Math.Abs(first1 - next1);

                char first2 = reversedString[n];
                char next2 = reversedString[n + 1];
                int difference2 = Math.Abs(first2 - next2);

                if (difference1 != difference2)
                {
                    differenceStringsAreEqual = false;
                    break;
                }
            }

            return differenceStringsAreEqual ? "Funny" : "Not Funny";
        }

        private static string Reverse(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int len = s.Length;

            for (int n = len - 1; 0 <= n; n--)
            {
                stringBuilder.Append(s[n]);
            }

            return stringBuilder.ToString();
        }
    }
}
