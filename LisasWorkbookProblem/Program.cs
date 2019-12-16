using System;

namespace LisasWorkbookProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int numberChapters = 5;
            int numberProblemsPerPage = 3;
            int[] problemsArray = {4, 2, 6, 1, 10};
            int numberSpecialProblems = Workbook(numberChapters, numberProblemsPerPage, problemsArray);         // 4
            Console.WriteLine($"numberSpecialProblems = {numberSpecialProblems}");

            numberChapters = 2;
            numberProblemsPerPage = 3;
            problemsArray = new [] {4, 2};
            numberSpecialProblems = Workbook(numberChapters, numberProblemsPerPage, problemsArray);             // 1
            Console.WriteLine($"numberSpecialProblems = {numberSpecialProblems}");
        }

        private static int Workbook(int numberChapters, int numberProblemsPerPage, int[] problemsArray)
        {
            int totalNumberSpecialProblems = 0;
            int currentPageNumber = 1;

            for (int chapter = 1; chapter <= numberChapters; chapter++)
            {
                int index = chapter - 1;
                int numberProblemsInChapter = problemsArray[index];
                int numberSpecialProblems = GetNumberSpecialProblemsInChapter(numberProblemsPerPage, numberProblemsInChapter, ref currentPageNumber);
                totalNumberSpecialProblems += numberSpecialProblems;
            }

            return totalNumberSpecialProblems;
        }

        private static int GetNumberSpecialProblemsInChapter(int numberProblemsPerPage, int numberProblemsInChapter, ref int currentPageNumber)
        {
            int numberPages = numberProblemsInChapter / numberProblemsPerPage;
            int remainder = numberProblemsInChapter % numberProblemsPerPage;

            if (remainder > 0)
            {
                numberPages++;
            }

            int pageNumber = currentPageNumber;
            int numberSpecialProblems = 0;

            for (int problemNumber = 1; problemNumber <= numberProblemsInChapter; problemNumber++)
            {
                if (problemNumber == pageNumber)
                {
                    numberSpecialProblems++;
                }

                if (problemNumber % numberProblemsPerPage == 0)
                {
                    pageNumber++;
                }
            }

            currentPageNumber += numberPages;

            return numberSpecialProblems;
        }
    }
}
