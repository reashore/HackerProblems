using static System.Console;

namespace FibonacciFindingProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        // https://en.wikipedia.org/wiki/Fibonacci_number#Matrix_form

        internal static void Main()
        {
            int f0 = 2;
            int f1 = 3;
            int n = 3;
            int fibonacci = Solve(f0, f1, n);                  // 3
            WriteLine($"fibonacciN = {fibonacci}");

            f0 = 9;
            f1 = 1;
            n = 7;
            fibonacci = Solve(f0, f1, n);                      // 85
            WriteLine($"fibonacciN = {fibonacci}");

            f0 = 9;
            f1 = 8;
            n = 3;
            fibonacci = Solve(f0, f1, n);                      // 25
            WriteLine($"fibonacciN = {fibonacci}");

            f0 = 2;
            f1 = 4;
            n = 9;
            fibonacci = Solve(f0, f1, n);                      // 178
            WriteLine($"fibonacciN = {fibonacci}");

            f0 = 1;
            f1 = 7;
            n = 2;
            fibonacci = Solve(f0, f1, n);                      // 8
            WriteLine($"fibonacciN = {fibonacci}");

            f0 = 1;
            f1 = 8;
            n = 1;
            fibonacci = Solve(f0, f1, n);                      // 8
            WriteLine($"fibonacciN = {fibonacci}");

            f0 = 4;
            f1 = 3;
            n = 1;
            fibonacci = Solve(f0, f1, n);                      // 3
            WriteLine($"fibonacciN = {fibonacci}");

            f0 = 3;
            f1 = 7;
            n = 5;
            fibonacci = Solve(f0, f1, n);                      // 44
            WriteLine($"fibonacciN = {fibonacci}");
        }

        private static int Solve(int f0, int f1, int n)
        {
            const long modulo = 9_000_000_007;
            long fibPrevious = f0;
            long fibCurrent = f1;
            long fibNext = 0;

            if (n == 1)
            {
                return (int) (f1 % modulo);
            }

            for (int i = 1; i < n; i++)
            {
                fibNext = (fibCurrent + fibPrevious) % modulo;
                //WriteLine($"fibNext = {fibNext} -> fibCurrent = {fibCurrent} + fibPrevious = {fibPrevious} ");
                fibPrevious = fibCurrent % modulo;
                fibCurrent = fibNext % modulo;
            }

            return (int) (fibNext % modulo);
        }
    }
}
