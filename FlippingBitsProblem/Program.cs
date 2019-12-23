using System;

namespace FlippingBitsProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            long number = 0;
            long bitFlippedNumber = FlippingBits(number);                       // 4294967295
            Console.WriteLine($"bitFlippedNumber = {bitFlippedNumber}");

            number = 1;
            bitFlippedNumber = FlippingBits(number);                            // 4294967294
            Console.WriteLine($"bitFlippedNumber = {bitFlippedNumber}");

            number = 2147483647;
            bitFlippedNumber = FlippingBits(number);                            // 2147483648
            Console.WriteLine($"bitFlippedNumber = {bitFlippedNumber}");
        }

        private static long FlippingBits(long number)
        {
            uint unsignedNumber = (uint) number;
            const uint maxUint = uint.MaxValue;
            uint unsignedResult = unsignedNumber ^ maxUint;
            long result = unsignedResult;
            return result;
        }
    }
}
