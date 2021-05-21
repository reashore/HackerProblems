using static System.Console;

namespace DrawingBookProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int numberPages = 6;
            int page = 2;
            int minimumPageTurns = PageCount(numberPages, page);            // 1
            WriteLine($"minimumPageTurns = {minimumPageTurns}");

            numberPages = 5;
            page = 4;
            minimumPageTurns = PageCount(numberPages, page);                // 0
            WriteLine($"minimumPageTurns = {minimumPageTurns}");

            Test();
        }

        private static int PageCount(int numberPages, int page)
        {
            bool evenNumberPages = numberPages % 2 == 0;
            int numberPageTurnsFromFront = page / 2;
            int numberPageTurnsFromBack = (numberPages - page + (evenNumberPages ? 1 : 0)) / 2;
            return numberPageTurnsFromFront < numberPageTurnsFromBack ? numberPageTurnsFromFront : numberPageTurnsFromBack;
        }

        private static void Test()
        {
            int numberPages = 4;

            for (int page = 1; page <= numberPages; page++)
            {
                int pageTurns = PageCount(numberPages, page);
                WriteLine($"numberPages = {numberPages}, page = {page}, pageTurns = {pageTurns}");
            }

            WriteLine();

            numberPages = 5;

            for (int page = 1; page <= numberPages; page++)
            {
                int pageTurns = PageCount(numberPages, page);
                WriteLine($"numberPages = {numberPages}, page = {page}, pageTurns = {pageTurns}");
            }
        }
    }
}
