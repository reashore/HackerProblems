using System;

namespace JumpingCloudsProblem
{
    public class JumpingClouds
    {
        private int[] _cloudArray;
        private int _lastIndex;

        public int GetMinimiumJumps(int[] cloudArray)
        {
            _cloudArray = cloudArray;
            _lastIndex = _cloudArray.Length - 1;

            if (_cloudArray[0] != 0)
            {
                throw new ArgumentException("First value of cloudArray must be 0");
            }

            if (_cloudArray[_lastIndex] != 0)
            {
                throw new ArgumentException("Last value of cloudArray must be 0");
            }

            int minimumJumps = GetMinimumJumps(0);

            return minimumJumps;
        }

        private int GetMinimumJumps(int n)
        {
            if (_cloudArray[n] == 1)
            {
                throw new Exception("Path array elements must be 0");
            }

            int index1 = n + 1;
            int index2 = n + 2;

            // check for cloudArrayend
            if (index2 == _lastIndex)
            {
                return 1;
            }

            if (index1 == _lastIndex)
            {
                return 1;
            }

            int next1 = _cloudArray[index1];
            int next2 = _cloudArray[index2];

            // next1, next2
            //   0,      0     2 choices
            //   0,      1     1 choice
            //   1,      0     1 choice
            //   1,      1     impossible

            if (next1 == 1 && next2 == 1)
            {
                throw new Exception("Invalid path");
            }

            if (next1 == 0 && next2 == 1)
            {
                return 1 + GetMinimumJumps(index1);
            }

            if (next1 == 1 && next2 == 0)
            {
                return 1 + GetMinimumJumps(index2);
            }

            // next1 == 0 && next2 == 0
            int minimumJumps1 = GetMinimumJumps(index1);
            int minimumJumps2 = GetMinimumJumps(index2);

            if (minimumJumps1 <= minimumJumps2)
            {
                return 1 + minimumJumps1;
            }

            return 1 + minimumJumps2;
        }
    }
}