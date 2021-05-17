using System.Collections.Generic;
using static System.Console;

namespace FillingJarsProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            Test1();
            Test2();
        }

        private static int Solve(int numberJars, List<List<int>> operations)
        {
            ulong[] jarList = new ulong[numberJars];
            double average;

            checked
            {
                for (int n = 0; n < numberJars; n++)
                {
                    jarList[n] = 0;
                }

                foreach (List<int> operation in operations)
                {
                    int firstJarIndex = operation[0];
                    int lastJarIndex = operation[1];
                    int value = operation[2];

                    for (int jarIndex = firstJarIndex; jarIndex <= lastJarIndex; jarIndex++)
                    {
                        jarList[jarIndex - 1] += (ulong)value;
                    }
                }

                ulong sum = 0;

                for (int jarIndex = 0; jarIndex < numberJars; jarIndex++)
                {
                    sum += jarList[jarIndex];
                }

                average = (double) sum / numberJars;
            }

            return (int) average;
        }

        private static void Test1()
        {
            const int numberJars = 5;
            List<List<int>> operationList = new List<List<int>>
            {
                new List<int> {1, 2, 100},
                new List<int> {2, 5, 100},
                new List<int> {3, 4, 100}
            };

            int average = Solve(numberJars, operationList);

            WriteLine($"average = {average}");
        }

        private static void Test2()
        {
            //const int numberJars = 4000;
            //List<List<int>> operationList = new List<List<int>>
            //{
            //};

            //int average = Solve(numberJars, operationList);

            //WriteLine($"average = {average}");
        }
    }
}
