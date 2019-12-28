using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class Utilities
    {
        public static string Reverse(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int len = s.Length;

            for (int n = len - 1; 0 <= n; n--)
            {
                stringBuilder.Append(s[n]);
            }

            return stringBuilder.ToString();
        }

        public static string GetDistinctChars(string inputString)
        {
            return new string(inputString.Distinct().ToArray());
        }

        public static Dictionary<char, int> GetOccurances(string s)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (!dictionary.ContainsKey(c))
                {
                    dictionary[c] = 1;
                }
                else
                {
                    dictionary[c]++;
                }
            }

            return dictionary;
        }

        public static void Print(IEnumerable<int> array)
        {
            Console.Write("[");

            foreach (int item in array)
            {
                Console.Write($"{item}, ");
            }

            Console.Write("]");
        }

        public static void Print(IEnumerable<string> array)
        {
            string line = string.Join(", ", array);
            Console.WriteLine(line);
        }

        public static void Print2(IEnumerable<int> array)
        {
            string line = string.Join(", ", array);
            Console.WriteLine(line);
        }

        public static string Sort(string inputString)
        {
            return new string(inputString.OrderBy(c => c).ToArray());
        }

        public static void Print(char[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{array[row, col],2} ");
                }

                Console.WriteLine();
            }
        }
    }
}
