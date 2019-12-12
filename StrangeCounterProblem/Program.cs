using System;

namespace StrangeCounterProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            TestStrangeCounter();
        }

        private static void TestStrangeCounter()
        {
            long t;
            long result;
            long expectedResult;
            string testResult;

            t = 1;
            result = StrangeCounter(t);
            expectedResult = 3;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 3;
            result = StrangeCounter(t);
            expectedResult = 1;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 4;
            result = StrangeCounter(t);
            expectedResult = 6;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 6;
            result = StrangeCounter(t);
            expectedResult = 4;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 9;
            result = StrangeCounter(t);
            expectedResult = 1;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 10;
            result = StrangeCounter(t);
            expectedResult = 12;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 10;
            result = StrangeCounter(t);
            expectedResult = 12;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 15;
            result = StrangeCounter(t);
            expectedResult = 7;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 21;
            result = StrangeCounter(t);
            expectedResult = 1;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 22;
            result = StrangeCounter(t);
            expectedResult = 24;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 23;
            result = StrangeCounter(t);
            expectedResult = 23;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");

            t = 24;
            result = StrangeCounter(t);
            expectedResult = 22;
            testResult = result == expectedResult ? "passed" : "failed";
            Console.WriteLine($"StrangeCount({t}) = {result}, {testResult}");
        }

        private static long StrangeCounter(long t)
        {
            long time = t;
            long factor = 3;
            //long groupStart = 1;
            long value;

            while (true)
            {
                long previousTime = time;
                time -= factor;
                //Console.WriteLine($"({groupStart, 6}, {factor,6}), time = {time,6}");

                if (time <= 0)
                {
                    value = factor - previousTime + 1;
                    break;
                }

                //groupStart += factor;
                factor *= 2;
            }

            return value;
        }
    }
}
