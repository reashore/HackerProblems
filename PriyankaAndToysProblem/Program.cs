using System;

namespace PriyankaAndToysProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] toyArray = {1, 2, 3, 4, 5, 10, 11, 12, 13};
            int numberContainers = Toys(toyArray);                                  // 2
            Console.WriteLine($"numberContainers = {numberContainers}");

            toyArray = new[] {1, 2, 3, 21, 7, 12, 14, 21};
            numberContainers = Toys(toyArray);                                      // 4
            Console.WriteLine($"numberContainers = {numberContainers}");
        }

        private static int Toys(int[] toyArray)
        {
            Array.Sort(toyArray);
            int numberContainers = 1;
            int maxWeight = toyArray[0] + 4;

            for (int n = 1; n < toyArray.Length; n++)
            {
                if (toyArray[n] > maxWeight)
                {
                    numberContainers++;
                    maxWeight = toyArray[n] + 4;
                }
            }

            return numberContainers;
        }
    }
}
