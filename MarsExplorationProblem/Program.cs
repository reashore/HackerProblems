using System;

namespace MarsExplorationProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string inputString = "SOSSPSSQSSOR";
            int numberCharactersChanged = MarsExploration(inputString);                     // 3
            Console.WriteLine($"numberCharactersChanged = {numberCharactersChanged}");

            inputString = "SOSSOT";
            numberCharactersChanged = MarsExploration(inputString);                         // 1
            Console.WriteLine($"numberCharactersChanged = {numberCharactersChanged}");

            inputString = "SOSSOSSOS";
            numberCharactersChanged = MarsExploration(inputString);                         // 0
            Console.WriteLine($"numberCharactersChanged = {numberCharactersChanged}");
        }

        private static int MarsExploration(string inputString)
        {
            const string sos = "SOS";
            int len = sos.Length;
            int index = 0;
            int numberCharactersChanged = 0;

            foreach (char c in inputString)
            {
                if (c != sos[index])
                {
                    numberCharactersChanged++;
                }

                index++;
                index %= len;
            }

            return numberCharactersChanged;
        }
    }
}
