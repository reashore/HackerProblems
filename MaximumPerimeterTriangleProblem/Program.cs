using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumPerimeterTriangleProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int[] sideArray = { 1, 1, 1, 3, 3 };
            int[] maximumSides = MaximumPerimeterTriangle(sideArray);
            Print(maximumSides);

            sideArray = new[] { 1, 2, 3 };
            maximumSides = MaximumPerimeterTriangle(sideArray);                   // -1
            Print(maximumSides);

            sideArray = new[] { 1, 1, 1, 2, 3, 5 };
            maximumSides = MaximumPerimeterTriangle(sideArray);                   // 1, 1, 1
            Print(maximumSides);

            sideArray = new[] { 3, 9, 2, 15, 3 };
            maximumSides = MaximumPerimeterTriangle(sideArray);                   // 2, 3, 3
            Print(maximumSides);

            sideArray = CreateTestInput();
            maximumSides = MaximumPerimeterTriangle(sideArray);                   // 1_000_000_000, 1_000_000_000, 1_000_000_000
            Print(maximumSides);
        }

        private static void Print(IEnumerable<int> array)
        {
            Console.Write("[");

            foreach (int item in array)
            {
                Console.Write($"{item}, ");
            }

            Console.Write("]");
            Console.WriteLine();
        }

        private class Triangle
        {
            public int Side1;
            public int Side2;
            public int Side3;
        }

        private static int[] MaximumPerimeterTriangle(int[] sideArray)
        {
            int len = sideArray.Length;
            long maxPerimeter = 0;
            List<Triangle> maxTriangleList = new List<Triangle>();

            for (int n1 = 0; n1 < len; n1++)
            {
                for (int n2 = 0; n2 < len; n2++)
                {
                    for (int n3 = 0; n3 < len; n3++)
                    {
                        bool condition = n1 < n2 && n2 < n3;

                        if (!condition)
                        {
                            continue;
                        }

                        List<int> sideList = new List<int>
                        {
                            sideArray[n1], 
                            sideArray[n2], 
                            sideArray[n3]
                        };

                        sideList.Sort();

                        int side1 = sideList[0];
                        int side2 = sideList[1];
                        int side3 = sideList[2];

                        bool isDegenerate = side1 + side2 <= side3;

                        if (isDegenerate)
                        {
                            continue;
                        }

                        long perimeter = (long) side1 + side2 + side3;

                        if (perimeter > maxPerimeter)
                        {
                            maxPerimeter = perimeter;

                            Triangle triangle = new Triangle
                            {
                                Side1 = side1,
                                Side2 = side2,
                                Side3 = side3
                            };

                            maxTriangleList.Clear();
                            maxTriangleList.Add(triangle);
                        }
                    }
                }
            }

            return SelectBestTriangle(maxTriangleList);
        }

        private static int[] SelectBestTriangle(List<Triangle> maxTriangleList)
        {
            const int degenerateTriangle = -1;
            Triangle triangle;

            if (maxTriangleList.Count == 0)
            {
                return new[] { degenerateTriangle };
            }

            if (maxTriangleList.Count == 1)
            {
                triangle = maxTriangleList[0];
                return new[] {triangle.Side1, triangle.Side2, triangle.Side3};
            }
            
            // maxTriangleList.Count > 1
            triangle = FurtherSelectBestTriangle(maxTriangleList);
            return new[] { triangle.Side1, triangle.Side2, triangle.Side3 };
        }

        private static Triangle FurtherSelectBestTriangle(List<Triangle> maxTriangleList)
        {
            List<Triangle> triangleWithLongestMaximumSideList = SelectTrianglesWithLongestMaximumSide(maxTriangleList);
            Triangle triangle;

            if (maxTriangleList.Count == 1)
            {
                triangle = triangleWithLongestMaximumSideList[0];
                return triangle;
            }

            // triangleWithLongestMaximumSide.Count > 1
            List<Triangle> triangleWithLongestMinimumSideList = SelectTrianglesWithLongestMinimumSide(triangleWithLongestMaximumSideList);

            if (triangleWithLongestMinimumSideList.Count == 1)
            {
                triangle = triangleWithLongestMaximumSideList[0];
                return triangle;
            }

            // triangleWithLongestMinimumSideList.Count > 1
            triangle = triangleWithLongestMinimumSideList.First();

            return triangle;
        }

        private static List<Triangle> SelectTrianglesWithLongestMaximumSide(List<Triangle> maxTriangleList)
        {
            List<Triangle> maxTriangleSideList = new List<Triangle>();
            int maxSide = 0;

            foreach (Triangle triangle in maxTriangleList)
            {
                int side = triangle.Side3;

                if (side >= maxSide)
                {
                    maxSide = side;
                    maxTriangleSideList.Clear();
                    maxTriangleSideList.Add(triangle);
                }
            }

            return maxTriangleSideList;
        }

        private static List<Triangle> SelectTrianglesWithLongestMinimumSide(List<Triangle> triangleWithLongestMaximumSideList)
        {
            List<Triangle> triangleWithLongestMinimumSideList = new List<Triangle>();
            int maxSide = 0;

            foreach (Triangle triangle in triangleWithLongestMaximumSideList)
            {
                int side = triangle.Side1;

                if (side >= maxSide)
                {
                    maxSide = side;
                    triangleWithLongestMinimumSideList.Clear();
                    triangleWithLongestMinimumSideList.Add(triangle);
                }
            }

            return triangleWithLongestMinimumSideList;
        }

        private static int[] CreateTestInput()
        {
            int[] array =
            {
                1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 
                1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 
                1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 
                1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 
                1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 
                1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 
                1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 
                1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 1_000_000_000, 
                1_000_000_000, 1_000_000_000
            };

            return array;
        }
    }
}
