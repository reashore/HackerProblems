using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCipherProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string originalString = "middle-Outz";
            int numRotations = 2;
            string encodedString = CaesarCipher(originalString, numRotations);        // okffng-Qwvb
            Console.WriteLine($"encodedString = {encodedString}");

            originalString = "www.abc.xy";
            numRotations = 87;
            encodedString = CaesarCipher(originalString, numRotations);               // fff.jkl.gh
            Console.WriteLine($"encodedString = {encodedString}");
        }

        private static string CaesarCipher(string originalString, int numRotations)
        {
            const string baseLowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            const string baseUpperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Dictionary<char, char> lowerEncodingDictionary = CreateEncodingDictionary(baseLowerAlphabet, numRotations);
            Dictionary<char, char> upperEncodingDictionary = CreateEncodingDictionary(baseUpperAlphabet, numRotations);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in originalString)
            {
                if (char.IsLetter(c))
                {
                    bool isLowerChar = char.IsLower(c);
                    char encodedChar = isLowerChar ? lowerEncodingDictionary[c] : upperEncodingDictionary[c];
                    stringBuilder.Append(encodedChar);
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }

            string encodedString = stringBuilder.ToString();

            return encodedString;
        }

        private static Dictionary<char, char> CreateEncodingDictionary(string baseAlphabet, int numRotations)
        {
            int len = baseAlphabet.Length;
            Queue<char> queue = new Queue<char>();
            List<char> charList = new List<char>();
            Dictionary<char, char> encodingDictionary = new Dictionary<char, char>();

            foreach (char c in baseAlphabet)
            {
                queue.Enqueue(c);
            }

            numRotations = numRotations % len;

            for (int n = 1; n <= numRotations; n++)
            {
                char c = queue.Dequeue();
                charList.Add(c);
            }

            foreach (char c in charList)
            {
                queue.Enqueue(c);
            }

            char[] queueArray = queue.ToArray();

            for (int n = 0; n < len; n++)
            {
                char key = baseAlphabet[n];
                char value = queueArray[n];

                encodingDictionary[key] = value;
            }

            return encodingDictionary;
        }
    }
}
