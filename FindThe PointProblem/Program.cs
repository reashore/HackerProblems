using System;
using System.Collections.Generic;

namespace FindThe_PointProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int px;
            int py;
            int qx;
            int qy;
            int[] refelctionPoint;

            px = 0;
            py = 0;
            qx = 1;
            qy = 1;
            refelctionPoint = FindPoint(px, py, qx, qy);
            Print(refelctionPoint);
            Console.WriteLine();

            px = 1;
            py = 1;
            qx = 2;
            qy = 2;
            refelctionPoint = FindPoint(px, py, qx, qy);
            Print(refelctionPoint);
            Console.WriteLine();
        }

        private static void Print(IEnumerable<int> array)
        {
            string line = string.Join(", ", array);
            Console.WriteLine(line);
        }

        private static int[] FindPoint(int px, int py, int qx, int qy)
        {
            int deltaX = qx - px;
            int deltaY = qy - py;

            int rx = qx + deltaX;
            int ry = qy + deltaY;

            return new[] {rx, ry};
        }
    }
}
