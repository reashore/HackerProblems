using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common
{
    public static class Utilities
    {
        public static string Reverse(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int len = s.Length;

            for (int n = len - 1; 0 <= n; n--)
            {
                stringBuilder.Append(s[n]);
            }

            return stringBuilder.ToString();
        }

        public static string GetDistinctChars(string inputString)
        {
            return new string(inputString.Distinct().ToArray());
        }

        public static Dictionary<char, int> GetOccurances(string s)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (!dictionary.ContainsKey(c))
                {
                    dictionary[c] = 1;
                }
                else
                {
                    dictionary[c]++;
                }
            }

            return dictionary;
        }

        public static void Print(IEnumerable<int> array)
        {
            Console.Write("[");

            foreach (int item in array)
            {
                Console.Write($"{item}, ");
            }

            Console.Write("]");
            Console.WriteLine();
        }

        public static string Sort(string inputString)
        {
            return new string(inputString.OrderBy(c => c).ToArray());
        }

        public static void Print(char[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{array[row, col],2} ");
                }

                Console.WriteLine();
            }
        }
    }

    public class TestCase
    {
        public List<int> Array;
        public string Result;
    }

    public static class TestCaseUtilities
    {
        public  static void RunTestCases()
        {
            List<TestCase> testCaseList = GetTestCases();

            for (int n = 0; n < testCaseList.Count; n++)
            {
                TestCase testCase = testCaseList[n];
                List<int> array = testCase.Array;
                string expectedResult = testCase.Result;
                string result = Test(array);

                if (result != expectedResult)
                {
                    Console.WriteLine($"Test case {n} failed, result = {result}, expectedResult = {expectedResult}");
                }
            }
        }
        private static string Test(List<int> array)
        {
            // replace with proper test function
            return "YES";
        }

        private static List<TestCase> GetTestCases()
        {
            List<List<int>> testInputList = ReadTestInput();
            List<string> testResultList = ReadTestResults();
            List<TestCase> testCaseList = new List<TestCase>();
            int testInputLen = testInputList.Count;
            int testResultsLen = testResultList.Count;

            if (testInputLen != testResultsLen)
            {
                throw new Exception("Test inputs and test results lengths are not equal");
            }

            for (int n = 0; n < testInputLen; n++)
            {
                TestCase testCase = new TestCase
                {
                    Array = testInputList[n],
                    Result = testResultList[n]
                };

                testCaseList.Add(testCase);
            }

            return testCaseList;
        }

        private static string[] ReadTextFile(string fileName)
        {
            string location = Assembly.GetExecutingAssembly().Location;
            string rootDirectory = Path.GetDirectoryName(location);
            string fullFileName = Path.Combine(rootDirectory, fileName);
            string[] fileLines = File.ReadAllLines(fullFileName);

            return fileLines;
        }

        private static List<List<int>> ReadTestInput()
        {
            const string testInputFileName = @"TestData\TestInput.txt";
            string[] testInputLines = TestCaseUtilities.ReadTextFile(testInputFileName);
            List<List<int>> testInputList = new List<List<int>>();

            int numberTestCases = Convert.ToInt32(testInputLines[0]);

            for (int n = 0; n < numberTestCases; n++)
            {
                string arrayValuesString = testInputLines[n + 2];
                string[] valueArray = arrayValuesString.Split(" ");
                List<int> valuesList = new List<int>();

                foreach (string valueString in valueArray)
                {
                    int value = Convert.ToInt32(valueString);
                    valuesList.Add(value);
                }

                testInputList.Add(valuesList);
            }

            return testInputList;
        }

        private static List<string> ReadTestResults()
        {
            const string testResultsFileName = @"TestData\TestResults.txt";
            string[] testResultLines = TestCaseUtilities.ReadTextFile(testResultsFileName);
            List<string> testResultList = new List<string>(testResultLines);
            return testResultList;
        }
    }
}
