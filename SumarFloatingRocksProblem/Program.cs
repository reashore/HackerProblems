using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static System.Console;

namespace SumarFloatingRocksProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            Test0();
            Test1();
            Test2();
            WriteLine("New tests start");
            Test3();
            WriteLine("New tests end");
        }

        private static int Solve(int x1, int y1, int x2, int y2)
        {
            // vertical line
            if (x1 == x2)
            {
                if (y1 < y2)
                {
                    Swap(ref y1, ref y2);
                }

                int difference = y1 - y2 - 1;

                if (difference < 0)
                {
                    difference = -difference;
                }

                return difference;
            }

            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }

            //int deltaX = x2 - x1;
            //int deltaY = y2 - y1;

            //if (deltaY % deltaX != 0)
            //{
            //    return 0;
            //}

            double slope = (double)(y1 - y2) / (x1 - x2);
            double xMean = (double)(x1 + x2) / 2;
            double yMean = (double)(y1 + y2) / 2;
            double offset = yMean - slope * xMean;
            int count = 0;
            
            for (int x = x1 + 1; x < x2; x++)
            {
                double y = slope * x + offset;

                if (IsEqualToInteger(y))
                {
                    count++;
                }
            }

            return count;
        }

        private static void Swap(ref int x1, ref int x2)
        {
            int temp = x1;
            x1 = x2;
            x2 = temp;
        }

        private static bool IsEqualToInteger(double value, double delta = .00000000001)
        {
            double difference = value - Math.Round(value);

            if (difference < 0)
            {
                difference = -difference;
            }

            return difference < delta;
        }

        #region Test code

        private static void Test0()
        {
            int x1 = 0;
            int y1 = 2;
            int x2 = 4;
            int y2 = 0;
            int count = Solve(x1, y1, x2, y2);
            WriteLine($"count = {count}");

            x1 = 2;
            y1 = 2;
            x2 = 5;
            y2 = 5;
            count = Solve(x1, y1, x2, y2);
            WriteLine($"count = {count}");

            x1 = 1;
            y1 = 9;
            x2 = 8;
            y2 = 16;
            count = Solve(x1, y1, x2, y2);
            WriteLine($"count = {count}");

            // actual = 2, expected = 0: x1 = 7173287, y1 = -8172527, x2 = 5556293, y2 = 7032662
            x1 = 7173287;
            y1 = -8172527;
            x2 = 5556293;
            y2 = 7032662;
            count = Solve(x1, y1, x2, y2);   // expected 0
            WriteLine($"count = {count}");

            WriteLine();
        }

        private static void Test1()
        {
            const string testDataFileName = @"./TestData1.txt";
            const string expectedValuesFileName = @"./ExpectedValues1.txt";

            Test(testDataFileName, expectedValuesFileName);
            WriteLine();
        }

        private static void Test2()
        {
            const string testDataFileName = @"./TestData2.txt";
            const string expectedValuesFileName = @"./ExpectedValues2.txt";

            Test(testDataFileName, expectedValuesFileName);
            WriteLine();
        }

        private static void Test3()
        {
            const string testDataFileName = @"./TestData3.txt";
            const string expectedValuesFileName = @"./ExpectedValues3.txt";

            Test(testDataFileName, expectedValuesFileName);
            WriteLine();
        }

        private static void Test(string testDataFileName, string expectedValuesFileName)
        {
            string[] lines = GetTestData(testDataFileName);
            List<int> expectedList = GetExpectedValues(expectedValuesFileName);

            for (int n = 0; n < lines.Length; n++)
            {
                string[] values = lines[n].Split(" ");

                int.TryParse(values[0], out int x1);
                int.TryParse(values[1], out int y1);
                int.TryParse(values[2], out int x2);
                int.TryParse(values[3], out int y2);

                int actual = Solve(x1, y1, x2, y2);
                int expected = expectedList[n];

                if (actual != expected)
                {
                    WriteLine($"Failed: actual = {actual}, expected = {expected}: x1 = {x1}, y1 = {y1}, x2 = {x2}, y2 = {y2}");
                }
            }
        }

        private static string[] GetTestData(string testDataFileName)
        {
            string[] lines = ReadTextFile(testDataFileName);
            return lines;
        }

        private static List<int> GetExpectedValues(string expectedValuesFileName)
        {
            string[] expectedStringValues = ReadTextFile(expectedValuesFileName);

            List<int> expectedValues = new List<int>();

            foreach (string expectedStringValue in expectedStringValues)
            {
                int.TryParse(expectedStringValue, out int expectedValue);
                expectedValues.Add(expectedValue);
            }

            return expectedValues;
        }

        private static string[] ReadTextFile(string fileName)
        {
            string location = Assembly.GetExecutingAssembly().Location;
            string rootDirectory = Path.GetDirectoryName(location);
            string fullFileName = Path.Combine(rootDirectory, fileName);
            string[] fileLines = File.ReadAllLines(fullFileName);

            return fileLines;
        }

        #endregion
    }
}
