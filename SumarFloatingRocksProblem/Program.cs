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
            Test1();
            Test2();
        }

        private static int Solve(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2)
            {
                WriteLine("Line is vertical");

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

            double xd1 = x1;
            double xd2 = x2;
            double yd1 = y1;
            double yd2 = y2;
            double slope = (yd1 - yd2) / (xd1 - xd2);
            double xMean = (xd1 + xd2) / 2;
            double yMean = (yd1 + yd2) / 2;
            int count = 0;
            
            for (int x = x1 + 1; x < x2; x++)
            {
                double y = GetLinearValue(x, slope, xMean, yMean);

                //WriteLine($"x = {x}, y = {y}");

                if (IsAppoximatelyEqualToInteger(y))
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

        private static double GetLinearValue(double x, double slope, double xMean, double yMean)
        {
            double y = slope * (x - xMean) + yMean;
            return y;
        }

        private static bool IsAppoximatelyEqualToInteger(double value, double delta = .000001)
        {
            double roundedValue = Math.Round(value);
            double difference = value - roundedValue;

            if (difference < 0)
            {
                difference = -difference;
            }

            bool result = difference < delta;
            return result;
        }

        #region Test code

        private static void Test1()
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

            x1 = 21;
            y1 = -87;
            x2 = -81;
            y2 = -33;
            count = Solve(x1, y1, x2, y2);
            WriteLine($"count = {count}");

            x1 = -89;
            y1 = -89;
            x2 = -8;
            y2 = 10;
            count = Solve(x1, y1, x2, y2);
            WriteLine($"count = {count}");

            WriteLine();
        }

        private static void Test2()
        {
            string[] lines = GetTestData();
            List<int> expectedList = GetExpectedValues();

            for (int n = 0; n < lines.Length; n++)
            {
                string[] values = lines[n].Split(" ");

                string x1String = values[0];
                string y1String = values[1];
                string x2String = values[2];
                string y2String = values[3];

                int.TryParse(x1String, out int x1);
                int.TryParse(y1String, out int y1);
                int.TryParse(x2String, out int x2);
                int.TryParse(y2String, out int y2);

                int actual = Solve(x1, y1, x2, y2);
                int expected = expectedList[n];

                if (actual != expected)
                {
                    WriteLine($"Failed: actual = {actual}, expected = {expected}: x1 = {x1}, y1 = {y1}, x2 = {x2}, y2 = {y2}");
                }
                else
                {
                    WriteLine("Passed");
                }
            }
        }

        private static string[] GetTestData()
        {
            const string testDataFileName = @"./TestData1.txt";
            string[] lines = ReadTextFile(testDataFileName);
            return lines;
        }

        private static List<int> GetExpectedValues()
        {
            const string expectedValuesFileName = @"./ExpectedValues1.txt";
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
