using System;
using System.Text;

namespace BeautifulDaysAtMoviesProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            int startDay = 20;
            int endDay = 23;
            int divisor = 6;
            int numBeautifulDays = GetBeautifulDays(startDay, endDay, divisor);
            Console.WriteLine($"numBeautifulDays = {numBeautifulDays}");

            startDay = 949488;
            endDay = 1753821;
            divisor = 5005440;
            numBeautifulDays = GetBeautifulDays(startDay, endDay, divisor);
            Console.WriteLine($"numBeautifulDays = {numBeautifulDays}");
        }

        private static int GetBeautifulDays(int startDay, int endDay, int divisor)
        {
            int numBeautifulDays = 0;

            for (int day = startDay; day <= endDay; day++)
            {
                if (IsBeautifulDay(day, divisor))
                {
                    numBeautifulDays++;
                }
            }

            return numBeautifulDays;
        }

        private static bool IsBeautifulDay(int day, int divisor)
        {
            string dayString = day.ToString();
            string reversedDayString = Reverse(dayString);
            int reversedDay = Convert.ToInt32(reversedDayString);
            int diff = Math.Abs(day - reversedDay);
            bool isBeautiful = diff % divisor == 0;

            return isBeautiful;
        }

        private static string Reverse(string s)
        {
            int len = s.Length;
            StringBuilder sb = new StringBuilder();

            for (int n = len - 1; n >= 0; n--)
            {
                sb.Append(s[n]);
            }

            return sb.ToString();
        }        
    }
}
