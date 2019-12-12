using System;
using System.Collections.Generic;
using System.Linq;

namespace ModifiedKaprekarNumbersProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int number = 5;
            bool isKaprekarNumber = IsKaprekarNumber(number);
            Console.WriteLine($"IsKaprekarNumber({number}) = {isKaprekarNumber}");

            number = 9;
            isKaprekarNumber = IsKaprekarNumber(number);
            Console.WriteLine($"IsKaprekarNumber({number}) = {isKaprekarNumber}");

            number = 77778;
            isKaprekarNumber = IsKaprekarNumber(number);
            Console.WriteLine($"IsKaprekarNumber({number}) = {isKaprekarNumber}");

            int low = 1;
            int high = 100;
            List<int> resultList = KaprekarNumbers(low, high);
            List<int> expectedResultList = new List<int> {1, 9, 45, 55, 99};
            Console.WriteLine(resultList.SequenceEqual(expectedResultList));

            low = 1;
            high = 99999;
            resultList = KaprekarNumbers(low, high);
            expectedResultList = new List<int> {1, 9, 45, 55, 99, 297, 703, 999, 2223, 2728, 4950, 5050, 7272, 7777, 9999, 17344, 22222, 77778, 82656, 95121, 99999};
            Console.WriteLine(resultList.SequenceEqual(expectedResultList));
        }

        private static List<int> KaprekarNumbers(int low, int high)
        {
            List<int> resultList = new List<int>();
            bool numberFoundInRange = false;

            for (int n = low; n <= high; n++)
            {
                if (IsKaprekarNumber(n))
                {
                    numberFoundInRange = true;
                    resultList.Add(n);
                    //Console.Write($"{n} ");
                }
            }

            if (!numberFoundInRange)
            {
                Console.WriteLine("INVALID RANGE");
            }

            return resultList;
        }

        private static bool IsKaprekarNumber(int number)
        {
            int numberLength = number.ToString().Length;
            ulong numberSquared = (ulong) number * (ulong) number;
            string numberSquaredString = numberSquared.ToString();
            int numberSquaredLength = numberSquaredString.Length;

            string rightPart = numberSquaredString.Substring(numberSquaredLength - numberLength);
            string leftPart = numberSquaredString.Substring(0, numberSquaredLength - numberLength);

            int rightNumber = Convert.ToInt32(rightPart);
            int leftNumber = !string.IsNullOrWhiteSpace(leftPart) ? Convert.ToInt32(leftPart) : 0;

            bool result = leftNumber + rightNumber == number;

            return result;
        }
    }
}
