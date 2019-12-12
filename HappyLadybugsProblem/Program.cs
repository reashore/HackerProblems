using System;

namespace HappyLadybugsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            //TestIsHappy();

            //string board = "AABBC_C";
            //string result = HappyLadybugs(board);
            //Console.WriteLine($"result = {result}");


        }

        private static void TestIsHappy()
        {
            bool isHappy = IsHappy("AABBCC");
            Console.WriteLine(isHappy);

            isHappy = IsHappy("A");
            Console.WriteLine(isHappy);

            isHappy = IsHappy("AA");
            Console.WriteLine(isHappy);

            isHappy = IsHappy("AAB");
            Console.WriteLine(isHappy);

            isHappy = IsHappy("AABC");
            Console.WriteLine(isHappy);
        }

        private static string HappyLadybugs(string board)
        {
            int len = board.Length;
            char[] boardArray = board.ToCharArray();

            return "";
        }

        private static bool IsHappy(string board)
        {
            int len = board.Length;

            if (len < 2)
            {
                return false;
            }

            for (int n = 0; n < len; n++)
            {
                char c = board[n];

                if (c == '_')
                {
                    continue;
                }

                if (n == 0)
                {
                    if (c != board[1])
                    {
                        return false;
                    }
                }

                if (n == len - 1)
                {
                    if (c != board[len - 2])
                    {
                        return false;
                    }
                }

                if (0 < n && n < len)
                {
                    bool condition = c == board[n - 1] || c == board[n + 1];

                    if (!condition)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
