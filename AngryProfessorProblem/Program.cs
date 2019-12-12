using System;

namespace AngryProfessorProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int k = 4;
            int[] arrivalTimes = {-1, -1, 0, 0, 1, 1};
            string result = AngryProfessor(k, arrivalTimes);                    // NO
            Console.WriteLine($"result = {result}");

            k = 5;
            arrivalTimes = new[] {-1, -1, 0, 0, 1, 1};
            result = AngryProfessor(k, arrivalTimes);                           // YES
            Console.WriteLine($"result = {result}");

            k = 3;
            arrivalTimes = new[] {-1, -3, 4, 2};
            result = AngryProfessor(k, arrivalTimes);                           // YES
            Console.WriteLine($"result = {result}");

            k = 2;
            arrivalTimes = new[] {0, -1, 2, 1};
            result = AngryProfessor(k, arrivalTimes);                           // NO
            Console.WriteLine($"result = {result}");
        }

        private static string AngryProfessor(int k, int[] arrivalTimes)
        {
            int numberStudentsOnTime = 0;

            foreach (int arrivalTime in arrivalTimes)
            {
                if (arrivalTime <= 0)
                {
                    numberStudentsOnTime++;
                }
            }

            bool classGoesOn = numberStudentsOnTime >= k;
            bool classIsCancelled = !classGoesOn;

            return classIsCancelled ? "YES" : "NO";
        }
    }
}
