using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static System.Console;

namespace MostDistantProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            List<List<int>> pointList = new()
            {
                new List<int>() {-1, 0},
                new List<int>() {1, 0},
                new List<int>() {0, 1},
                new List<int>() {0, -1}
            };
            double maximumDistance = Solve(pointList);
            WriteLine($"maximumDistance = {maximumDistance}");          // 2

            pointList = new()
            {
                new List<int>() {0, -5},
                new List<int>() {-7, 0},
                new List<int>() {0, -6},
                new List<int>() {-4, 0},
                new List<int>() {0, 0}
            };
            maximumDistance = Solve(pointList);
            WriteLine($"maximumDistance = {maximumDistance}");          // 9.219544457293

            Test1();                                                    // 1414208066.040572166443
            Test2();                                                    // 1414208105.636744260788
        }

        private static double Solve(List<List<int>> points)
        {
            List<Point> pointList = ConvertToListOfPoints(points);
            int minX = int.MaxValue;
            int maxX = int.MinValue;
            int minY = int.MaxValue;
            int maxY = int.MinValue;

            foreach (Point point in pointList)
            {
                int x = point.X;
                int y = point.Y;

                if (x < minX)
                {
                    minX = x;
                }

                if (x > maxX)
                {
                    maxX = x;
                }

                if (y < minY)
                {
                    minY = y;
                }

                if (y > maxY)
                {
                    maxY = y;
                }
            }

            double maximumDistance = GetMaximumDistance(minX, maxX, minY, maxY);

            return maximumDistance;
        }

        private static double GetMaximumDistance(int minX, int maxX, int minY, int maxY)
        {
            double maximumDistance = double.MinValue;

            //---------------------------------------------

            Point p1 = new Point(minX, 0);
            Point p2 = new Point(maxX, 0);
            double distance = GetDistance(p1, p2);

            if (distance > maximumDistance)
            {
                maximumDistance = distance;
            }

            p1 = new Point(0, minY);
            p2 = new Point(0, maxY);
            distance = GetDistance(p1, p2);

            if (distance > maximumDistance)
            {
                maximumDistance = distance;
            }

            //---------------------------------------------

            p1 = new Point(minX, 0);
            p2 = new Point(0, minY);
            distance = GetDistance(p1, p2);

            if (distance > maximumDistance)
            {
                maximumDistance = distance;
            }

            p1 = new Point(maxX, 0);
            p2 = new Point(0, minY);
            distance = GetDistance(p1, p2);

            if (distance > maximumDistance)
            {
                maximumDistance = distance;
            }

            //---------------------------------------------

            p1 = new Point(minX, 0);
            p2 = new Point(0, maxY);
            distance = GetDistance(p1, p2);

            if (distance > maximumDistance)
            {
                maximumDistance = distance;
            }

            p1 = new Point(maxX, 0);
            p2 = new Point(0, maxY);
            distance = GetDistance(p1, p2);

            if (distance > maximumDistance)
            {
                maximumDistance = distance;
            }

            return maximumDistance;
        }

        private static List<Point> ConvertToListOfPoints(List<List<int>> points)
        {
            List<Point> pointList = new List<Point>();

            foreach (List<int> point in points)
            {
                int x = point[0];
                int y = point[1];
                Point p = new Point(x, y);
                pointList.Add(p);
            }

            return pointList;
        }

        private static double GetDistance(Point p1, Point p2)
        {
            long x1 = p1.X;
            long y1 = p1.Y;
            long x2 = p2.X;
            long y2 = p2.Y;
            double deltaX = x1 - x2;
            double deltaY = y1 - y2;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        #region Test code

        private static void Test1()
        {
            const string testDataFileName = @"./TestData1.txt";
            const double expectedTestValue = 1414208066.040572166443;

            Test(testDataFileName, expectedTestValue);
        }

        private static void Test2()
        {
            const string testDataFileName = @"./TestData2.txt";
            const double expectedTestValue = 1414208105.636744260788;

            Test(testDataFileName, expectedTestValue);
        }

        private static void Test(string testDataFileName, double expected)
        {
            string[] lines = GetTestData(testDataFileName);
            List<List<int>> pointList = new();

            foreach (var line in lines)
            {
                string[] values = line.Split(" ");

                int.TryParse(values[0], out int x);
                int.TryParse(values[1], out int y);
                List<int> coordinatesList = new()
                {
                    x, y
                };

                pointList.Add(coordinatesList);
            }

            double actual = Solve(pointList);

            if (!IsEqual(actual, expected))
            {
                WriteLine($"Failed: actual = {actual}, expected = {expected}");
            }
            else
            {
                WriteLine("Passed");
            }
        }

        private static bool IsEqual(double d1, double d2, double tolerance = .000_000_6)
        {
            double delta = d1 - d2;

            if (delta < 0)
            {
                delta = -delta;
            }

            return delta < tolerance;
        }

        private static string[] GetTestData(string testDataFileName)
        {
            string[] lines = ReadTextFile(testDataFileName);
            return lines;
        }

        private static string[] ReadTextFile(string fileName)
        {
            string location = Assembly.GetExecutingAssembly().Location;
            string rootDirectory = Path.GetDirectoryName(location);
            // ReSharper disable once AssignNullToNotNullAttribute
            string fullFileName = Path.Combine(rootDirectory, fileName);
            string[] fileLines = File.ReadAllLines(fullFileName);

            return fileLines;
        }

        #endregion
    }

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
