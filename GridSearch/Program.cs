using System.Collections.Generic;
using static System.Console;

namespace GridSearch
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            List<string> gridList = new()
            {
                "1234567890",
                "0987654321",
                "1111111111",
                "1111111111",
                "2222222222"
            };
            List<string> patternList = new()
            {
                "876543",
                "111111",
                "111111"
            };
            string expected = "YES";
            string actual = GridSearch(gridList, patternList);
            WriteLine($"actual = {actual}, expected = {expected}");

            gridList = new List<string>
            {
                "7283455864",
                "6731158619",
                "8988242643",
                "3830589324",
                "2229505813",
                "5633845374",
                "6473530293",
                "7053106601",
                "0834282956",
                "4607924137"
            };
            patternList = new List<string>
            {
                "9505",
                "3845",
                "3530"
            };
            expected = "YES";
            actual = GridSearch(gridList, patternList);
            WriteLine($"actual = {actual}, expected = {expected}");

            gridList = new List<string>
            {
                "400453592126560",
                "114213133098692",
                "474386082879648",
                "522356951189169",
                "887109450487496",
                "252802633388782",
                "502771484966748",
                "075975207693780",
                "511799789562806",
                "404007454272504",
                "549043809916080",
                "962410809534811",
                "445893523733475",
                "768705303214174",
                "650629270887160"
            };
            patternList = new List<string>
            {
                "99",
                "99"
            };
            expected = "NO";
            actual = GridSearch(gridList, patternList);
            WriteLine($"actual = {actual}, expected = {expected}");

            gridList = new List<string>
            {
                "123412",
                "561212",
                "123634",
                "781288"
            };
            patternList = new List<string>
            {
                "12",
                "34"
            };
            expected = "YES";
            actual = GridSearch(gridList, patternList);
            WriteLine($"actual = {actual}, expected = {expected}");

            gridList = new List<string>
            {
                "999999",
                "121211",
            };
            patternList = new List<string>
             {
                "99",
                "11"
            };
            expected = "YES";
            actual = GridSearch(gridList, patternList);
            WriteLine($"actual = {actual}, expected = {expected}");

            gridList = new List<string>
            {
                "123456",
                "567890",
                "234567",
                "194729"
            };
            patternList = new List<string>
             {
                 "2345",
                 "6789",
                 "3456",
                 "9472"
             };
            expected = "YES";
            actual = GridSearch(gridList, patternList);
            WriteLine($"actual = {actual}, expected = {expected}");
        }

        private static string GridSearch(List<string> gridList, List<string> patternList)
        {
            int gridRows = gridList.Count;
            int gridCols = gridList[0].Length;
            string pattern = patternList[0];
            int patternRows = patternList.Count;
            int patternCols = pattern.Length;

            if (gridRows < patternRows && gridCols < patternCols)
            {
                return "NO";
            }

            int rowMax = gridRows - patternRows + 1;
            int colMax = gridCols - patternCols + 1;
            bool found = false;

            for (int row = 0; row < rowMax; row++)
            {
                for (int col = 0; col < colMax; col++)
                {
                    if (SearchGridAtRowColumn(row, col, gridList, patternList, patternRows, patternCols))
                    {
                        found = true;
                        goto done;
                    }
                }
            }

            done:
            return found ? "YES" : "NO";
        }

        private static bool SearchGridAtRowColumn(int rowStart, int colStart, List<string> gridList, List<string> patternList, int patternRows, int patternCols)
        {
            bool found = true;

            for (int row = 0; row < patternRows ; row++)
            {
                string rowText = gridList[row + rowStart];
                string rowSubText = rowText.Substring(colStart, patternCols);
                string pattern = patternList[row];

                if (rowSubText != pattern)
                {
                    found = false;
                    break;
                }
            }

            return found;
        }
    }
}
