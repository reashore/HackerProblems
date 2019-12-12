using System;
using static System.Console;

namespace BeautifulStringProblem
{
    internal class Program
    {
        private static void Main()
        {
            string binaryString = "0101010";
            int numberFixes = BeautifulBinaryString(binaryString);
            WriteLine($"numberFixes = {numberFixes}");              // 2

            binaryString = "01100";
            numberFixes = BeautifulBinaryString(binaryString);
            WriteLine($"numberFixes = {numberFixes}");              // 0

            binaryString = "0100101010";
            numberFixes = BeautifulBinaryString(binaryString);
            WriteLine($"numberFixes = {numberFixes}");              // 3
        }

        private static int BeautifulBinaryString(string binaryString)
        {
            int count = 0;
            const string pattern = "010";

            while (true)
            {
                int index = binaryString.IndexOf(pattern, StringComparison.Ordinal);

                bool done = index < 0;

                if (done)
                {
                    break;
                }

                if (index >= 0)
                {
                    count++;
                    char[] charArray = binaryString.ToCharArray();
                    charArray[index + 2] = '1';
                    binaryString = ToString(charArray);
                }
            }

            return count;
        }

        private static string ToString(char[] charArray)
        {
            string result = "";

            foreach (char c in charArray)
            {
                result += c;
            }

            return result;
        }
    }
}
