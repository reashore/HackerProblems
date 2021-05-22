using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class Utilities
    {
        public static bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;

            while (true)
            {
                if (min > max)
                {
                    return true;
                }

                char a = value[min];
                char b = value[max];

                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }

                min++;
                max--;
            }
        }

        private static List<int> GetPrimeFactors(int number)
        {
            // https://www.thecsengineer.com/2020/11/efficient-algorithm-to-find-all-prime-factors-of-number.html

            List<int> primeFactors = new List<int>();

            while (number % 2 == 0)
            {
                primeFactors.Add(2);
                number /= 2;
            }

            for (int n = 3; n <= Math.Sqrt(number); n += 2)
            {
                while (number % n == 0)
                {
                    primeFactors.Add(n);
                    number /= n;
                }
            }

            if (number > 1)
            {
                primeFactors.Add(number);
            }

            return primeFactors;
        }

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
        
        private static int Gcf(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static int Lcm(int a, int b)
        {
            return (a / Gcf(a, b)) * b;
        }

    }
}
