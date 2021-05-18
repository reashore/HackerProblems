using System.Collections.Generic;
using System.Numerics;
using static System.Console;

namespace RussianPeasantExponentiationProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            int real = 2;
            int imaginary = 0;
            int exponent = 9;
            int modulo = 1000;
            List<int> result = Solve(real, imaginary, exponent, modulo);
            int realPart = result[0];
            int imaginaryPart = result[1];
            WriteLine($"{realPart} {imaginaryPart}");

            real = 0;
            imaginary = 1;
            exponent = 5;
            modulo = 10;
            result = Solve(real, imaginary, exponent, modulo);
            realPart = result[0];
            imaginaryPart = result[1];
            WriteLine($"{realPart} {imaginaryPart}");

            real = 8;
            imaginary = 2;
            exponent = 10;
            modulo = 1_000_000_000;
            result = Solve(real, imaginary, exponent, modulo);
            realPart = result[0];
            imaginaryPart = result[1];
            WriteLine($"{realPart} {imaginaryPart}");
        }

        private static List<int> Solve(int real, int imaginary, long exponent, int modulo)
        {
            Complex complex = new Complex(real, imaginary);
            Complex exponentiatedComplex = Complex.Pow(complex, exponent);

            double realPart1 = exponentiatedComplex.Real;
            double imaginaryPart1 = exponentiatedComplex.Imaginary;

            int realPart2 = (int) realPart1 % modulo;
            int imaginaryPart2 = (int) imaginaryPart1 % modulo;

            List<int> result = new List<int>();
            result.Add(realPart2);
            result.Add(imaginaryPart2);

            return result;
        }
    }
}
