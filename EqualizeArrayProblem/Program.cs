using System.Collections.Generic;
using static System.Console;

namespace EqualizeArrayProblem
{
    public static class Program
    {
        public static void Main()
        {
            int[] array = {1, 2, 2, 3};
            int numberElementsToDelete = EqualizeArray(array);

            WriteLine($"numberElementsToDelete = {numberElementsToDelete}");
        }

        private static int EqualizeArray(int[] array)
        {
            int arrayLength = array.Length;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (int item in array)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary[item] = 1;
                }
                else
                {
                    dictionary[item]++;
                }
            }

            int maxValue = 0;

            foreach (int value in dictionary.Values)
            {
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }

            int numberElementsToDelete = arrayLength - maxValue;

            return numberElementsToDelete;
        }
    }
}
