using System;
using System.Collections.Generic;

namespace DesignerPdfViewerProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] charHeightArray = {1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5};
            string word = "abc";
            int area = DesignerPdfViewer(charHeightArray, word);                    // 9
            Console.WriteLine($"area = {area}");

            charHeightArray = new[] {1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7};
            word = "zaba";
            area = DesignerPdfViewer(charHeightArray, word);                        // 28
            Console.WriteLine($"area = {area}");
        }

        private static int DesignerPdfViewer(int[] charHeightArray, string word)
        {
            int len = charHeightArray.Length;
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            for (int n = 0; n < len; n++)
            {
                int charCode = 97 + n;

                char c = Convert.ToChar(charCode);
                int height = charHeightArray[n];

                dictionary[c] = height;
            }

            int maxCharHeight = 0;

            foreach (char c in word)
            {
                int charHeight = dictionary[c];

                if (charHeight > maxCharHeight)
                {
                    maxCharHeight = charHeight;
                }
            }

            int wordLen = word.Length;
            int textArea = wordLen * maxCharHeight;

            return textArea;
        }
    }
}
