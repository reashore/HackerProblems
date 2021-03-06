﻿using System;
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
            Test3();
        }

        private static int Solve(int x1, int y1, int x2, int y2)
        {
            // vertical line
            if (x1 == x2)
            {
                int difference = y1 - y2;

                if (difference < 0)
                {
                    difference = -difference;
                }

                return difference - 1;
            }

            // horizontal line
            if (y1 == y2)
            {
                int difference = x1 - x2;

                if (difference < 0)
                {
                    difference = -difference;
                }

                return difference - 1;
            }

            int deltaX = Abs(x2 - x1);
            int deltaY = Abs( y2 - y1);

            int count = Gcf(deltaY, deltaX) - 1;
            return count;
        }

        private static int Abs(int x)
        {
            if (x < 0)
            {
                return -x;
            }

            return x;
        }

        private static int Gcf(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        #region Test code

        private static void Test0()
        {
            int x1 = 0;
            int y1 = 2;
            int x2 = 4;
            int y2 = 0;
            int count = Solve(x1, y1, x2, y2);              // 1
            WriteLine($"count = {count}");

            x1 = 2;
            y1 = 2;
            x2 = 5;
            y2 = 5;
            count = Solve(x1, y1, x2, y2);                  // 2
            WriteLine($"count = {count}");

            x1 = 1;
            y1 = 9;
            x2 = 8;
            y2 = 16;
            count = Solve(x1, y1, x2, y2);                  // 6
            WriteLine($"count = {count}");

            x1 = 7173287;
            y1 = -8172527;
            x2 = 5556293;
            y2 = 7032662;
            count = Solve(x1, y1, x2, y2);                  // 0
            WriteLine($"count = {count}");

            x1 = 7158191;
            y1 = -5226453;
            x2 = -4407451;
            y2 = 8512618;
            count = Solve(x1, y1, x2, y2);                  // 18
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
