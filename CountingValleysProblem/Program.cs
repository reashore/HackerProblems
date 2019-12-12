using static System.Console;

namespace CountingValleysProblem
{
    public class Program
    {
        public static void Main()
        {
            const string s = "UDDDUDUU";
            int n = s.Length;
            int numberValleys = CountingValleys(n, s);                      // 1
            WriteLine($"numberValleys = {numberValleys}");
        }

        private static int CountingValleys(int n, string s)
        {
            int height = 0;
            int numberValleys = 0;

            foreach (char step in s)
            {
                if (step == 'D')
                {
                    height--;
                }
                else
                {
                    height++;
                }

                bool endValley = height == 0 && step == 'U';

                if (endValley)
                {
                    numberValleys++;
                }
            }

            return numberValleys;
        }
    }
}
