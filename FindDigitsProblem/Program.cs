using System;

namespace FindDigitsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int number = 111;
            int result = FindDigits(number);                        // 3
            Console.WriteLine($"result = {result}");

            number = 12;
            result = FindDigits(number);                            // 2
            Console.WriteLine($"result = {result}");

            number = 1012;
            result = FindDigits(number);                            // 3
            Console.WriteLine($"result = {result}");
        }

        private static int FindDigits(int number)
        {
            string numberString = number.ToString();
            int numDivisors = 0;

            foreach (char digitChar in numberString)
            {
                string digitString = digitChar.ToString();
                int digit = Convert.ToInt32(digitString);

                if (digit != 0 && number % digit == 0)
                {
                    numDivisors++;
                }
            }

            return numDivisors;
        }
    }
}
