using System;
using System.Text;
using static System.Console;

namespace EncryptionProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            string value = "aaaaa bbbbb ccccc ddddd";
            string expectedValue = "abcd abcd abcd abcd abcd";
            Test(value, expectedValue);

            value = "haveaniceday";
            expectedValue = "hae and via ecy";
            Test(value, expectedValue);

            value = "feedthedog ";
            expectedValue = "fto ehg ee dd";
            Test(value, expectedValue);

            value = "chillout";
            expectedValue = "clu hlt io";
            Test(value, expectedValue);

            value = "if man was meant to stay on the ground god would have given us roots";
            expectedValue = "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau";
            Test(value, expectedValue);
        }

        private static void Test(string value, string expectedValue)
        {
            string actualValue = Encryption(value);

            if (actualValue != expectedValue)
            {
                WriteLine($"Failed: actual = {actualValue}, expected = {expectedValue}");
            }
            else
            {
                WriteLine("Passed");
            }
        }

        private static string Encryption(string value)
        {
            value = value.Replace(" ", "");
            int length = value.Length;
            double sqrtLength = Math.Sqrt(length);
            int rows = (int)Math.Floor(sqrtLength);
            int cols = (int)Math.Ceiling(sqrtLength);

            if (rows * cols < length)
            {
                rows++;
            }

            StringBuilder stringBuilder = new StringBuilder();

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    int index = row + col + (cols - 1) * row;

                    if (index < length)
                    {
                        stringBuilder.Append(value[index]);
                    }
                }

                stringBuilder.Append(" ");
            }

            return stringBuilder.ToString().Trim();
        }

        //private static string Encryption(string value)
        //{
        //    value = value.Replace(" ", "");
        //    int length = value.Length;
        //    (int rows, int cols) = GetRowsAndCols(length);
        //    StringBuilder stringBuilder = new StringBuilder();

        //    //WriteLine($"rows = {rows}, cols = {cols}");

        //    for (int col = 0; col < cols; col++)
        //    {
        //        for (int row = 0; row < rows; row++)
        //        {
        //            int index = row + col + (cols - 1) * row;

        //            if (index < length)
        //            {
        //                stringBuilder.Append(value[index]);
        //            }

        //            //WriteLine($"rows = {rows}, cols = {cols}, row = {row}, col = {col}, index = {index}");
        //        }

        //        stringBuilder.Append(" ");
        //    }

        //    return stringBuilder.ToString().Trim();
        //}

        private static string RemoveSpaces(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char character in value)
            {
                if (character != ' ')
                {
                    stringBuilder.Append(character);
                }
            }

            return stringBuilder.ToString();
        }

        private static void GetRowsAndCols(int length, out int rows, out int cols)
        {
            double sqrtLength = Math.Sqrt(length);
            rows = (int)Math.Floor(sqrtLength);
            cols = (int)Math.Ceiling(sqrtLength);

            if (rows * cols < length)
            {
                rows++;
            }

            //return (rows, cols);
        }

        //private static (int, int) GetRowsAndCols(int length)
        //{
        //    double sqrtLength = Math.Sqrt(length);

        //    int rows = (int)Math.Floor(sqrtLength);
        //    int cols = (int)Math.Ceiling(sqrtLength);

        //    if (rows * cols < length)
        //    {
        //        rows++;
        //        return (rows, cols);
        //    }
        //    return (rows, cols);



        //    int row1 = rows - 1;
        //    int row2 = rows + 1;

        //    int col1 = cols - 1;
        //    int col2 = cols + 1;

        //    // Choose row and col such that:
        //    // 1) row x col > length and
        //    // 2) area = row x col is minimum

        //    int minArea = int.MaxValue;
        //    int minRow = 0;
        //    int minCol = 0;

        //    for (int row = row1; row < row2; row++)
        //    {
        //        for (int col = col1; col < col2; col++)
        //        {
        //            int area = row * col;

        //            if (area < length)
        //            {
        //                continue;
        //            }

        //            if (area < minArea)
        //            {
        //                minArea = area;
        //                minRow = row;
        //                minCol = col;
        //            }
        //        }
        //    }

        //    //if (minRow * minCol < length)
        //    //{
        //    //    WriteLine($"maxRow x maxCol = {minRow}x{minCol} < {length}");
        //    //    throw new Exception("maxRows * maxCol > length");
        //    //}

        //    if (minRow >= minCol)
        //    {
        //        WriteLine($"maxRow = {minRow}, cols = {minCol}");
        //        throw new Exception("maxRow >= maxCol");
        //    }

        //    return (minRow, minCol);
        //}
    }
}
