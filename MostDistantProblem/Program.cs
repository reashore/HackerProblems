using System;
using System.Collections.Generic;
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
                new List<int>() {0, -1},
            };
            double maximumDistance = Solve(pointList);
            WriteLine($"maximumDistance = {maximumDistance}");
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

            int distance1 = maxX - minX;
            int distance2 = maxY - minY;

            return distance1 > distance2 ? distance1 : distance2;
        }


        #region solution 1

        private static double Solve2(List<List<int>> points)
        {
            List<Point> pointList = ConvertToListOfPoints(points);
            double maxDistance = 0;
            Point maxPoint1 = new Point();
            Point maxPoint2 = new Point();

            for (int n1 = 0; n1 < pointList.Count; n1++)
            {
                for (int n2 = 0; n2 < pointList.Count; n2++)
                {
                    if (n1 == n2)
                    {
                        continue;
                    }

                    Point p1 = pointList[n1];
                    Point p2 = pointList[n2];

                    double distance = GetDistance1(p1, p2);

                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        maxPoint1 = p1;
                        maxPoint2 = p2;
                    }
                }
            }

            maxDistance = GetDistance2(maxPoint1, maxPoint2);
            
            return maxDistance;
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

        private static double GetDistance1(Point p1, Point p2)
        {
            int x1 = p1.X;
            int y1 = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            return Abs(x1 - x2) + Abs(y1 - y2);
        }

        private static double GetDistance2(Point p1, Point p2)
        {
            int x1 = p1.X;
            int y1 = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        private static int Abs(int x)
        {
            if (x > 0)
            {
                return x;
            }

            return -x;
        }

        #endregion
    }

    public class Point
    {
        public Point()
        {

        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
