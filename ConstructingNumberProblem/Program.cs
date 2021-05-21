using System.Collections.Generic;
using static System.Console;

namespace ConstructingNumberProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            List<int> numberList = new List<int>()
            {
                9
            };
            string result = CanConstruct(numberList);
            WriteLine($"Result = {result}");

            numberList = new List<int>()
            {
                40,
                50,
                90
            };
            result = CanConstruct(numberList);
            WriteLine($"Result = {result}");

            numberList = new List<int>()
            {
                1,
                4
            };
            result = CanConstruct(numberList);
            WriteLine($"Result = {result}");
        }

        private static string CanConstruct(List<int> numberList)
        {
            ulong sum = 0;

            foreach (int number in numberList)
            {
                sum += (ulong)number % 3;
            }

            string message = sum % 3 == 0 ? "Yes" : "No";
            return message;
        }
    }
}
