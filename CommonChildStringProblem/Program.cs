using System;
using System.Linq;
using System.Text;

namespace CommonChildStringProblem
{
    internal static class Program
    {
        public static void Main()
        {
            string s1 = "HARRY";
            string s2 = "SALLY";
            int numberChildren = CommonChild(s1, s2);
            Console.WriteLine($"numberChildren = {numberChildren}");            // 2

            s1 = "AA";
            s2 = "BB";
            numberChildren = CommonChild(s1, s2);
            Console.WriteLine($"numberChildren = {numberChildren}");            // 0

            s1 = "SHINCHAN";
            s2 = "NOHARAAA";
            numberChildren = CommonChild(s1, s2);
            Console.WriteLine($"numberChildren = {numberChildren}");            // 3

            s1 = "OUDFRMYMAW";
            s2 = "AWHYFCCMQX";
            numberChildren = CommonChild(s1, s2);
            Console.WriteLine($"numberChildren = {numberChildren}");            // 2
        }

        private static int CommonChild(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                throw new ArgumentException("s1 and s2 must be the same length");
            }

            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();

            foreach (char c in s1)
            {
                if (s2.Contains(c))
                {
                    stringBuilder1.Append(c);
                }
            }

            foreach (char c in s2)
            {
                if (s1.Contains(c))
                {
                    stringBuilder2.Append(c);
                }
            }

            string result1 = stringBuilder1.ToString();
            string result2 = stringBuilder2.ToString();

            Console.WriteLine($"{s1}, {result1}");
            Console.WriteLine($"{s2}, {result2}");

            int len1 = result1.Length;
            int len2 = result2.Length;
            int maxLen = 0;

            // find longest substring common to result1 and result2

            for (int n = 0; n < len1; n++)
            {
                string substring = result1.Substring(n);
                //Console.WriteLine(substring);

                if (result2.IndexOf(substring, StringComparison.Ordinal) == -1)
                {
                    continue;
                }

                int substringLen = substring.Length;

                if (substringLen > maxLen)
                {
                    maxLen = substringLen;
                }
            }

            return maxLen;
        }

        private static int CommonChild2(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                throw new ArgumentException("s1 and s2 must be the same length");
            }

            StringBuilder stringBuilder = new StringBuilder();

            s1 = s1.DistinctString();
            s2 = s2.DistinctString();

            foreach (char c1 in s1)
            {
                if (s2.Contains(c1))
                {
                    stringBuilder.Append(c1);
                }
            }

            string result = stringBuilder.ToString();

            return result.Length;
        }

        private static string DistinctString(this string value)
        {
            return new string(value.Distinct().ToArray());
        }
    }
}
