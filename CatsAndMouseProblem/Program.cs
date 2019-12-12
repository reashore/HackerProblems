using System;

namespace CatsAndMouseProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int catPosition1 = 2;
            int catPosition2 = 5;
            int mousePosition = 4;
            string result = CatAndMouse(catPosition1, catPosition2, mousePosition);                 // Cat B
            Console.WriteLine($"result = {result}");

            catPosition1 = 1;
            catPosition2 = 2;
            mousePosition = 3;
            result = CatAndMouse(catPosition1, catPosition2, mousePosition);                        // Cat B
            Console.WriteLine($"result = {result}");

            catPosition1 = 1;
            catPosition2 = 3;
            mousePosition = 2;
            result = CatAndMouse(catPosition1, catPosition2, mousePosition);                        // Mouse C
            Console.WriteLine($"result = {result}");
        }

        private static string CatAndMouse(int catPosition1, int catPosition2, int mousePosition)
        {
            int distance1 = Math.Abs(catPosition1 - mousePosition);
            int distance2 = Math.Abs(catPosition2 - mousePosition);
            string result = "Mouse C";

            if (distance1 < distance2)
            {
                result = "Cat A";
            }
            else if (distance1 > distance2)
            {
                result = "Cat B";
            }
            else if (distance1 == distance2)
            {
                result = "Mouse C";
            }

            return result;
        }
    }
}
