using System;

namespace LibraryFineProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int returnedDay = 9;
            int returnedMonth = 6;
            int returnedYear = 2015;
            int dueDay = 6;
            int dueMonth = 6;
            int dueYear = 2015;
            int fine = GetLibraryFine(returnedDay, returnedMonth, returnedYear, dueDay, dueMonth, dueYear);         // 45
            Console.WriteLine($"fine = {fine}");

            returnedDay = 28;
            returnedMonth = 2;
            returnedYear = 2015;
            dueDay = 15;
            dueMonth = 4;
            dueYear = 2015;
            fine = GetLibraryFine(returnedDay, returnedMonth, returnedYear, dueDay, dueMonth, dueYear);             // 0
            Console.WriteLine($"fine = {fine}");
        }

        private static int GetLibraryFine(int returnedDay, int returnedMonth, int returnedYear, int dueDay, int dueMonth, int dueYear)
        {
            DateTime returnedDateTime = new DateTime(returnedYear, returnedMonth, returnedDay);
            DateTime dueDateTime = new DateTime(dueYear, dueMonth, dueDay);

            bool returnedBeforeDueDate = returnedDateTime <= dueDateTime;
            bool returnedInDueMonth = !returnedBeforeDueDate && returnedMonth == dueMonth && returnedYear == dueYear;
            bool returnedInDueYear = !returnedBeforeDueDate && returnedYear == dueYear;
            bool returnedAfterDueYear = !returnedBeforeDueDate && returnedYear > dueYear;

            int fine = 0;

            if (returnedInDueMonth)
            {
                fine = 15 * (returnedDay - dueDay);
            }
            else if (returnedInDueYear)
            {
                fine = 500 * (returnedMonth - dueMonth);
            }
            else if (returnedAfterDueYear)

            {
                fine = 10_000;
            }

            return fine;
        }
    }
}
