using System;
using System.Text;
using static System.Console;

namespace SherlockAndTheBeastProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            int numberDigits = 1;
            string expected = "-1";
            Test(numberDigits, expected);

            numberDigits = 3;
            expected = "555";
            Test(numberDigits, expected);

            numberDigits = 5;
            expected = "33333";
            Test(numberDigits, expected);

            numberDigits = 6;
            expected = "555555";
            Test(numberDigits, expected);

            numberDigits = 8;
            expected = "55533333";
            Test(numberDigits, expected);

            numberDigits = 11;
            expected = "55555533333";
            Test(numberDigits, expected);
        }

        private static void Test(int numberDigits, string expected)
        {
            string actual = DecentNumber(numberDigits);

            if (actual != expected)
            {
                WriteLine($"Failed with digits = {numberDigits}: actual = {actual}, expected = {expected}");
            }
            else
            {
                WriteLine("Passed");
            }
        }

        private static string DecentNumber(int numberDigits)
        {
            int digits = numberDigits;

            while (digits % 3 != 0)
            {
                digits -= 5;
            }

            if (digits < 0)
            {
                return "-1";
            }

            string decentNumber = CreateString('5', digits) + CreateString('3', numberDigits - digits);
            return decentNumber;
        }

        //private static void DecentNumber(int numberDigits)
        //{
        //    int digits = numberDigits;

        //    while (digits % 3 != 0)
        //    {
        //        digits -= 5;
        //    }

        //    if (digits < 0)
        //    {
        //        Console.WriteLine("-1");
        //    }
        //    else
        //    {
        //        string decentNumber = CreateString('5', digits) + CreateString('3', numberDigits - digits);
        //        Console.WriteLine(decentNumber);
        //    }
        //}

        private static string CreateString(char character, int repeats)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int n = 0; n < repeats; n++)
            {
                stringBuilder.Append(character);
            }

            return stringBuilder.ToString();
        }
    }
}
