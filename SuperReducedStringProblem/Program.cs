using System;
using System.Text;

namespace SuperReducedStringProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string s = "aaabccddd";
            string superReducedString = SuperReducedString(s);
            Console.WriteLine($"superReducedString = {superReducedString}");

            s = "aa";
            superReducedString = SuperReducedString(s);
            Console.WriteLine($"superReducedString = {superReducedString}");

            s = "baab";
            superReducedString = SuperReducedString(s);
            Console.WriteLine($"superReducedString = {superReducedString}");
        }

        private static string SuperReducedString(string s)
        {
            char[] array = s.ToCharArray();
            int len = array.Length;
            StringBuilder stringBuilder = new StringBuilder();

            while (true)
            {
                bool found = false;

                for (int n = 0; n < len - 1; n++)
                {
                    if (array[n] == 'X')
                    {
                        continue;
                    }

                    if (array[n + 1] == array[n])
                    {
                        found = true;
                        array[n] = 'X';
                        array[n + 1] = 'X';
                    }
                }

                array = RemoveDeletions(array);
                len = array.Length;

                if (!found)
                {
                    break;
                }
            }

            foreach (char c in array)
            {
                stringBuilder.Append(c);
            }

            string superReducedString = stringBuilder.ToString();

            return superReducedString != string.Empty ? superReducedString : "Empty String";
        }

        private static char[] RemoveDeletions(char[] array)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in array)
            {
                if (c != 'X')
                {
                    stringBuilder.Append(c);
                }
            }

            string result = stringBuilder.ToString();

            return result.ToCharArray();
        }
    }
}
