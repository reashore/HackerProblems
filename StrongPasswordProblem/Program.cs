using System;

namespace StrongPasswordProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            string password;
            const int notUsed = -1;
            int minCharsForStrongPassword;

            password = "Ab1";
            minCharsForStrongPassword = MinimumNumber(notUsed, password);                       // 3
            Console.WriteLine($"minCharsForStrongPassword = {minCharsForStrongPassword}");

            password = "#HackerRank";
            minCharsForStrongPassword = MinimumNumber(notUsed, password);                       // 1
            Console.WriteLine($"minCharsForStrongPassword = {minCharsForStrongPassword}");
        }

        private static int MinimumNumber(int n, string password)
        {
            int originalPasswordLength = password.Length;
            int newPasswordLength = originalPasswordLength;
            const int requiredPasswordlength = 6;

            if (!HasDigit(password))
            {
                newPasswordLength++;
            }

            if (!HasLowerCaseCharacter(password))
            {
                newPasswordLength++;
            }

            if (!HasUpperCaseCharacter(password))
            {
                newPasswordLength++;
            }

            if (!HasSpecialCharacter(password))
            {
                newPasswordLength++;
            }

            if (newPasswordLength < requiredPasswordlength)
            {
                int difference = requiredPasswordlength - newPasswordLength;
                newPasswordLength += difference;
            }

            return newPasswordLength - originalPasswordLength;
        }

        private static bool HasDigit(string password)
        {
            const string digits = "0123456789";
            return HasCharacterInCharacterSet(password, digits);
        }

        private static bool HasLowerCaseCharacter(string password)
        {
            const string lowerCaseCharacters = "abcdefghijklmnopqrstuvwxyz";
            return HasCharacterInCharacterSet(password, lowerCaseCharacters);
        }

        private static bool HasUpperCaseCharacter(string password)
        {
            const string upperCaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return HasCharacterInCharacterSet(password, upperCaseCharacters);
        }

        private static bool HasSpecialCharacter(string password)
        {
            const string specialCharacters = "!@#$%^&*()-+";
            return HasCharacterInCharacterSet(password, specialCharacters);
        }

        private static bool HasCharacterInCharacterSet(string password, string characterSet)
        {
            bool hasCharacterInCharacterSet = false;

            foreach (char c in characterSet)
            {
                if (password.IndexOf(c) >= 0)
                {
                    hasCharacterInCharacterSet = true;
                    break;
                }
            }

            return hasCharacterInCharacterSet;
        }
    }
}
