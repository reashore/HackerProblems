using System;

namespace JumpingCloudsProblem
{
    public static class JumpingCloudStatic
    {
        public static int GetMinimiumJumps(int[] cloudArray)
        {
            int lastIndex = cloudArray.Length - 1;

            if (cloudArray[0] != 0)
            {
                throw new ArgumentException("First value must be 0");
            }

            if (cloudArray[lastIndex] != 0)
            {
                throw new ArgumentException("Last value must be 0");
            }

            const int index = 0;
            int minimumJumps = GetMinimumJumps(index, cloudArray, lastIndex);

            return minimumJumps;
        }

        private static int GetMinimumJumps(int index, int[] cloudArray, int lastIndex)
        {
            if (cloudArray[index] == 1)
            {
                throw new Exception("Path array elements must be 0");
            }

            int index1 = index + 1;
            int index2 = index + 2;

            // check for cloudArray end
            if (index2 == lastIndex)
            {
                return 1;
            }

            if (index1 == lastIndex)
            {
                return 1;
            }

            int next1 = cloudArray[index1];
            int next2 = cloudArray[index2];

            // next1, next2
            //   0,     0     2 choices
            //   0,     1     1 choice
            //   1,     0     1 choice
            //   1,     1     impossible

            if (next1 == 1 && next2 == 1)
            {
                throw new Exception("Invalid path");
            }

            if (next1 == 0 && next2 == 1)
            {
                return 1 + GetMinimumJumps(index1, cloudArray, lastIndex);
            }

            if (next1 == 1 && next2 == 0)
            {
                return 1 + GetMinimumJumps(index2, cloudArray, lastIndex);
            }

            // next1 == 0 && next2 == 0
            int minimumJumps1 = GetMinimumJumps(index1, cloudArray, lastIndex);
            int minimumJumps2 = GetMinimumJumps(index2, cloudArray, lastIndex);

            if (minimumJumps1 <= minimumJumps2)
            {
                return 1 + minimumJumps1;
            }

            return 1 + minimumJumps2;
        }
    }
}
