using System;
using System.Collections.Generic;

namespace GradingStudentsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            List<int> grades = new List<int> {73, 67, 38, 33};
            List<int> roundedGrades = GradeStudents(grades);
            PrintList(grades);
            PrintList(roundedGrades);
        }

        private static void PrintList(List<int> grades)
        {
            Console.Write(string.Join(" ", grades));
            Console.WriteLine();
        }

        private static List<int> GradeStudents(List<int> grades)
        {
            List<int> roundedGrades = new List<int>();

            foreach (int grade in grades)
            {
                int roundedGrade = grade < 38 ? grade : Round(grade);
                roundedGrades.Add(roundedGrade);
            }

            return roundedGrades;
        }

        private static int Round(int grade)
        {
            // grade = n * 5 + remainder
            int n = grade / 5;
            int next = (n + 1) * 5;
            int diff = next - grade;
            int roundedGrade = diff < 3 ? next: grade;
            return roundedGrade;
        }
    }
}
