using System;

namespace TimeConversionProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string twelveHourTime = "12:00:00AM";                                   // midnight
            string twentyFourHourTime = ConvertTime(twelveHourTime);                // 00:00:00
            Console.WriteLine($"twentyFourHourTime = {twentyFourHourTime}");

            twelveHourTime = "07:05:45AM";
            twentyFourHourTime = ConvertTime(twelveHourTime);                       // 07:05:45
            Console.WriteLine($"twentyFourHourTime = {twentyFourHourTime}");

            twelveHourTime = "12:00:00PM ";                                         // noon
            twentyFourHourTime = ConvertTime(twelveHourTime);                       // 12:00:00
            Console.WriteLine($"twentyFourHourTime = {twentyFourHourTime}");

            twelveHourTime = "07:05:45PM";
            twentyFourHourTime = ConvertTime(twelveHourTime);                       // 19:05:45
            Console.WriteLine($"twentyFourHourTime = {twentyFourHourTime}");
        }

        private static string ConvertTime(string twelveHourTime)
        {
            string hoursString = twelveHourTime.Substring(0, 2);
            string minutesString = twelveHourTime.Substring(3, 2);
            string secondsString  = twelveHourTime.Substring(6, 2);
            string ampmString  = twelveHourTime.Substring(8, 2);

            bool isPm = ampmString.ToUpper() == "PM";
            int hours = Convert.ToInt32(hoursString);

            string hours24String = "00";

            if (!isPm && hours == 12)
            {
                hours24String = "00";
            }
            else if (!isPm && hours < 12)
            {
                hours24String = hoursString;
            }
            else if (isPm && hours == 12)
            {
                hours24String = "12";
            }
            else if (isPm && hours < 12)
            {
                hours += 12;
                hours24String = hours.ToString();
            }

            string twentyFourHourTime = $"{hours24String}:{minutesString}:{secondsString}";

            return twentyFourHourTime;
        }
    }
}
