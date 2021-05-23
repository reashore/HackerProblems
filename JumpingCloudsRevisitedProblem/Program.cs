using System;

namespace JumpingCloudsRevisitedProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            int jumpSize = 2;
            int[] cloudArray = {0, 0, 1, 0};
            int finalEnergy = JumpingOnClouds(cloudArray, jumpSize);                            // 96
            Console.WriteLine($"finalEnergy = {finalEnergy}");

            jumpSize = 2;
            cloudArray = new[] {0, 0, 1, 0, 0, 1, 1, 0};
            finalEnergy = JumpingOnClouds(cloudArray, jumpSize);                                // 92
            Console.WriteLine($"finalEnergy = {finalEnergy}");

            jumpSize = 19;
            cloudArray = new[] {1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1};
            finalEnergy = JumpingOnClouds(cloudArray, jumpSize);                                // 97
            Console.WriteLine($"finalEnergy = {finalEnergy}");
        }

        private static int JumpingOnClouds(int[] cloudArray, int jumpSize)
        {
            int energy = 100;
            int cloudArrayLength = cloudArray.Length;
            int cloudIndex = 0;

            while (true)
            {
                cloudIndex += jumpSize;
                cloudIndex %= cloudArrayLength;
                energy--;

                if (cloudArray[cloudIndex] == 1)
                {
                    energy -= 2;
                }

                if (cloudIndex == 0)
                {
                    break;
                }
            }

            return energy;
        }
    }
}
