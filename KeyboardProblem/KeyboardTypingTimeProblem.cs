using System;
using System.Collections.Generic;

namespace KeyboardProblem
{
    // Problem:
    // A secret facility uses a numeric 3x3 keyboard to input PINs.
    // The keyboard layout changes regularly.
    // The keyboard layout is defined by the string "keyboard".
    // The PIN is defined by the string "keyboardInput".
    // The time to type the same key repeatedly is 0.
    // The time to move from one key to an adjacent key is 1 unit. 
    // The time to move to a non-adjacent key is 2 units.
    // Calculate the total time to enter the PIN.

    public static class KeyboardTypingTimeProblem
    {
        public static int GetTotalTypingTime(string keyboardInput, string keyboard)
        {
            if (keyboard.Length != 9)
            {
                throw new ArgumentException("keyboard must be 9 characters");
            }

            List<Position> keyboardPositions = new List<Position>
            {
                new Position(1, 1), new Position(1, 2), new Position(1, 3),
                new Position(2, 1), new Position(2, 2), new Position(2, 3),
                new Position(3, 1), new Position(3, 2), new Position(3, 3)
            };
            Dictionary<string, Position> keyboardDictionary = new Dictionary<string, Position>();
            int index = 0;

            foreach (char digitChar in keyboard)
            {
                string digitString = digitChar.ToString();
                keyboardDictionary[digitString] = keyboardPositions[index];
                index++;
            }

            char previousInputChar = keyboardInput[0];
            string previousInputString = previousInputChar.ToString();
            Position previousPosition = keyboardDictionary[previousInputString];
            int totalTypingTime = 0;

            for (int n = 1; n < keyboardInput.Length; n++)
            {
                char nextInputChar = keyboardInput[n];
                string nextInputString = nextInputChar.ToString();
                Position nextPosition = keyboardDictionary[nextInputString];
                totalTypingTime += GetTypingTime(previousPosition, nextPosition);
                previousPosition = nextPosition;
            }

            return totalTypingTime;
        }

        private static int GetTypingTime(Position position1, Position position2)
        {
            int x1 = position1.X;
            int y1 = position1.Y;

            int x2 = position2.X;
            int y2 = position2.Y;

            int delta1 = x1 - x2;
            int delta2 = y1 - y2;

            if (delta1 == 0 && delta2 == 0)
            {
                return 0;
            }

            int distanceSquared = delta1 * delta1 + delta2 * delta2;
            bool isAdjacentTo = distanceSquared <= 2;

            return isAdjacentTo ? 1 : 2;
        }
    }
}