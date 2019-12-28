using System;

namespace AppendAndDeleteProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string string1 = "hackerhappy";
            string string2 = "hackerrank";
            int numberOperations = 9;
            string result = AppendAndDelete(string1, string2, numberOperations);        // Yes
            Console.WriteLine($"result = {result}");

            string1 = "aba";
            string2 = "aba";
            numberOperations = 7;
            result = AppendAndDelete(string1, string2, numberOperations);               // Yes
            Console.WriteLine($"result = {result}");

            string1 = "ashley";
            string2 = "ash";
            numberOperations = 2;
            result = AppendAndDelete(string1, string2, numberOperations);               // No
            Console.WriteLine($"result = {result}");

            string1 = "aaaaaaaaaa";
            string2 = "aaaaa";
            numberOperations = 7;
            result = AppendAndDelete(string1, string2, numberOperations);               // Yes
            Console.WriteLine($"result = {result}");

            string1 = "zzzzz";
            string2 = "zzzzzzz";
            numberOperations = 4;
            result = AppendAndDelete(string1, string2, numberOperations);               // Yes
            Console.WriteLine($"result = {result}");

            string1 = "asdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv";
            string2 = "asdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcvasdfqwertyuighjkzxcv";
            numberOperations = 20;
            result = AppendAndDelete(string1, string2, numberOperations);               // Yes
            Console.WriteLine($"result = {result}");
        }

        private static string AppendAndDelete(string string1, string string2, int numberOperations)
        {
            int commonLength = GetCommonLength(string1, string2);
            int totalLength = string1.Length + string2.Length;
            int totalMinusCommonLength = totalLength - 2 * commonLength;

            // Case 1
            if (totalMinusCommonLength > numberOperations)
            {
                return "No";
            }

            // Case 2
            if ((totalMinusCommonLength - numberOperations) % 2 == 0)
            {
                return "Yes";
            }

            // Case 3
            if (totalLength - numberOperations < 0)
            {
                return "Yes";
            }

            // Case 4
            return "No";
        }

        private static int GetCommonLength(string s1, string s2)
        {
            int commonLength = 0;
            int len1 = s1.Length;
            int len2 = s2.Length;
            int len = len1 >= len2 ? len2 : len1;

            for (int n = 0; n < len; n++)
            {
                if (s1[n] == s2[n])
                {
                    commonLength++;
                }
                else
                {
                    break;
                }
            }

            return commonLength;
        }
    }
}
