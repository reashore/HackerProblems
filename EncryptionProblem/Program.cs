using System;
using System.Text;
using static System.Console;

namespace EncryptionProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            string value = "aaaaa bbbbb ccccc ddddd";
            string expectedValue = "abcd abcd abcd abcd abcd";
            Test(value, expectedValue);

            value = "haveaniceday";
            expectedValue = "hae and via ecy";
            Test(value, expectedValue);

            value = "feedthedog ";
            expectedValue = "fto ehg ee dd";
            Test(value, expectedValue);

            value = "chillout";
            expectedValue = "clu hlt io";
            Test(value, expectedValue);

            value = "if man was meant to stay on the ground god would have given us roots";
            expectedValue = "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau";
            Test(value, expectedValue);
        }

        private static void Test(string value, string expectedValue)
        {
            string actualValue = Encryption(value);

            if (actualValue != expectedValue)
            {
                WriteLine($"Failed: actual = {actualValue}, expected = {expectedValue}");
            }
            else
            {
                WriteLine("Passed");
            }
        }

        private static string Encryption(string value)
        {
            value = value.Replace(" ", "");
            int length = value.Length;
            double sqrtLength = Math.Sqrt(length);
            int rows = (int)Math.Floor(sqrtLength);
            int cols = (int)Math.Ceiling(sqrtLength);
            StringBuilder stringBuilder = new StringBuilder();

            if (rows * cols < length)
            {
                rows++;
            }

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    int index = row + col + (cols - 1) * row;

                    if (index < length)
                    {
                        stringBuilder.Append(value[index]);
                    }
                }

                stringBuilder.Append(" ");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
