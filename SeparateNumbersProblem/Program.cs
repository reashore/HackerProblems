//using static System.Console;

using System;

namespace SeparateNumbersProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            var number = "1234";
            SeparateNumbers(number);                    // Yes 1

            number = "91011";
            SeparateNumbers(number);                    // YES 9

            number = "99100";
            SeparateNumbers(number);                    // YES 99

            number = "99910001001";
            SeparateNumbers(number);                    // YES 999

            number = "7891011";
            SeparateNumbers(number);                    // YES 7

            number = "9899100";
            SeparateNumbers(number);                    // YES 98

            number = "1";
            SeparateNumbers(number);                    // NO

            Console.WriteLine("###########################################");
            number = "999100010001";
            SeparateNumbers(number);                    // NO

            number = "101103";
            SeparateNumbers(number);                    // NO

            number = "010203";
            SeparateNumbers(number);                    // NO

            number = "13";
            SeparateNumbers(number);                    // NO
        }

        private static void SeparateNumbers(string number)
        {
            bool match = false;
            int firstNumber = 0;
            int numberLength = 1;

            Console.WriteLine("*************************************");

            Console.WriteLine($"number = {number}");

            if (number.Length <= 1)
            {
                Console.WriteLine("NO");
                return;
            }
            
            while (true)
            {
                bool firstTimeFlag = true;
                int loopNumberLength = numberLength;
                string remainderNumber = number;

                while (remainderNumber.Length > 0)
                {
                    //-------------------------------------

                    if (loopNumberLength > remainderNumber.Length)
                    {
                        Console.WriteLine("Breaking 1");
                        break;
                    }

                    string currentNumber = remainderNumber.Substring(0, loopNumberLength);
                    int currentNumberInt = GetNumber(currentNumber);

                    if (firstTimeFlag)
                    {
                        firstNumber = currentNumberInt;
                        firstTimeFlag = false;
                    }

                    //-------------------------------------
                    
                    // is this guaranteed to succeed?
                    remainderNumber = remainderNumber.Substring(loopNumberLength);

                    if (remainderNumber == "")
                    {
                        match = true;
                        Console.WriteLine("Breaking 2");
                        break;
                    }

                    string expectedNextNumber = GetString(currentNumberInt + 1);
                    loopNumberLength = expectedNextNumber.Length;

                    //-------------------------------------

                    if (loopNumberLength > remainderNumber.Length)
                    {
                        Console.WriteLine($"Breaking 3: loopNumberLength = {loopNumberLength}, remainderNumber = {remainderNumber}");
                        break;
                    }

                    string actualNextNumber = remainderNumber.Substring(0, expectedNextNumber.Length);

                    //-------------------------------------

                    Console.WriteLine($"firstNumber = {firstNumber}, currentNumber = {currentNumber}, expectedNextNumber = {expectedNextNumber}, actualNextNumber = {actualNextNumber}, remainder = {remainderNumber}");

                    if (actualNextNumber != expectedNextNumber)
                    {
                        Console.WriteLine("Breaking 4");

                        break;
                    }

                    if (remainderNumber == "")
                    {
                        Console.WriteLine("Breaking 5");
                        match = true;
                    }
                }

                if (match)
                {
                    break;
                }

                if (numberLength > 5)
                {
                    break;
                }

                numberLength++;
            }

            var message = match ? $"YES {firstNumber}" : "NO";
            Console.WriteLine(message);
        }

        private static int GetNumber(string numberString)
        {
            bool success = int.TryParse(numberString, out int number);
            return number;
        }

        private static string GetString(int number)
        {
            return number.ToString();
        }
    }
}
