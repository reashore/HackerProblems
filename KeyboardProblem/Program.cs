using static System.Console;

namespace KeyboardProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        public static void Main()
        {
            const string keyboardInput = "123456789";
            const string keyboard = "123456789";
            int totalTypingTime = KeyboardTypingTimeProblem.GetTotalTypingTime(keyboardInput, keyboard);
            string message = $"Total typing time = {totalTypingTime}";
            WriteLine(message);

            ReadKey();
        }
    }
}
