using System;
using System.Collections.Generic;
using static System.Console;

namespace HappyLadybugsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            Test1();
            WriteLine();
            Test2();
            WriteLine("Done");
        }

        private static string HappyLadybugs(string array)
        {
            // Happy Conditions:
            // Condition1: There are at least one empty cell AND there is no Letter with count 1
            // OR
            // Condition2: There is no empty cell AND the given string is happy without swaps

            Dictionary<char, int> dictionary = CreateHistogram(array);
            bool isHappy;

            if (IsCondition1(dictionary))
            {
                isHappy = true;
            }
            else if (IsCondition2(dictionary, array))
            {
                isHappy = true;
            }
            else
            {
                isHappy = false;
            }

            return isHappy ? "YES" : "NO";
        }

        private static Dictionary<char, int> CreateHistogram(string array)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (char character in array)
            {
                if (!dictionary.ContainsKey(character))
                {
                    dictionary[character] = 1;
                }
                else
                {
                    dictionary[character]++;
                }
            }

            return dictionary;
        }

        private static bool IsCondition1(Dictionary<char, int> dictionary)
        {
            bool thereIsAtLeastOneEmptyCell = ThereIsAtLeastOneEmptyCell(dictionary);
            bool thereIsNoLetterWithACountOfOne = ThereIsNoElementWithACountOfOne(dictionary);
            return thereIsAtLeastOneEmptyCell && thereIsNoLetterWithACountOfOne;
        }

        private static bool IsCondition2(Dictionary<char, int> dictionary, string array)
        {
            return ThereIsNoEmptyCell(dictionary) && ArrayIsHappyWithoutSwaps(array);
        }

        private static bool ThereIsNoElementWithACountOfOne(Dictionary<char, int> dictionary)
        {
            foreach (var key in dictionary.Keys)
            {
                if (key != '_' && dictionary[key] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ThereIsAtLeastOneEmptyCell(Dictionary<char,int> dictionary)
        {
            return dictionary.ContainsKey('_') && dictionary['_'] >= 1;
        }

        private static bool ThereIsNoEmptyCell(Dictionary<char,int> dictionary)
        {
            return !dictionary.ContainsKey('_');
        }
        
        private static bool ArrayIsHappyWithoutSwaps(string array)
        {
            // Check that array has no '_' characters
            if (array.Contains("_"))
            {
                throw new Exception("array cannot contain '-'");
            }

            int arrayLength = array.Length;

            if (arrayLength == 1)
            {
                return false;
            }

            if (arrayLength == 2)
            {
                return array[0] == array[1];
            }

            // If here, then array length is at least 3

            bool isFirstElementHappy = array[0] == array[1];
            bool isLastElementHappy = array[arrayLength - 1] == array[arrayLength - 2];

            bool areAllInternalElementsHappy = true;

            for (int n = 1; n < arrayLength - 1; n++)
            {
                bool isHappy = array[n] == array[n - 1] || array[n] == array[n + 1];

                if (!isHappy)
                {
                    areAllInternalElementsHappy = false;
                    break;
                }
            }

            return isFirstElementHappy && areAllInternalElementsHappy && isLastElementHappy;
        }

        #region Test code

        private static void Test1()
        {
            Test("_", "YES");
            Test("__", "YES");
            Test("X", "NO");
            Test("XX", "YES");
            Test("X_", "NO");
            Test("XY", "NO");
            Test("X_X", "YES");
            Test("XYX", "NO");
            Test("XYZ", "NO");
            Test("_XX", "YES");
            Test("YXX", "NO");
            Test("X__", "NO");
            Test("X_Y", "NO");
            Test("XXYY", "YES");
            Test("XXYZ", "NO");
            Test("XYXY", "NO");
            Test("XXXY", "NO");
            Test("XYXX", "NO");
            Test("X_XX", "YES");
            Test("X__X", "YES");
            Test("XY_X", "NO");
            Test("X___", "NO");
            Test("XYZZZ", "NO");
            Test("X_XYY", "YES");
            Test("_XY_Y", "NO");
            Test("_XX__", "YES");
            Test("_XXYY", "YES");
            Test("X_XYY", "YES");
            Test("X___X", "YES");
            Test("X__YX", "NO");
            Test("X_X_Y_", "NO");
            Test("XXXYYY", "YES");
            Test("____ZZ", "YES");
            Test("XYZYZY", "NO");
            Test("XXYYZZ", "YES");
            Test("X_XYXY", "YES");
            Test("XZY_YZX", "YES");
            Test("_XYYYXX", "YES");
        }

        private static void Test2()
        {
            Test("AABBC", "NO");
            Test("AABBC_C", "YES");
            Test("DD__FQ_QQF_", "YES");
            Test("AABCBC", "NO");
            Test("RBY_YBR", "YES");
            Test("X_Y__X", "NO");
            Test("B_RRBR", "YES");
            Test("YYR_B_BR", "YES");
        }

        private static void Test(string array, string expected)
        {
            string actual = HappyLadybugs(array);

            if (actual != expected)
            {
                WriteLine($"Failed: array = {array, 12}, expected = {expected}");
            }
        }
 
        #endregion
    }
}
