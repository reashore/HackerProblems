using System;
using System.Collections.Generic;

namespace BalancedBrackets
{
    public class Program
    {
        public static void Main()
        {
            TestString("{[()]}", "YES");
            TestString("{[(])}", "NO");
            TestString("{{[[(())]]}}", "YES");
            TestString("}][}}(}][))]", "NO");
            TestString("[](){()}", "YES");
            TestString("()", "YES");
            TestString("({}([][]))[]()", "YES");
            TestString("{)[](}]}]}))}(())(", "NO");
            TestString("([[)", "NO");
        }

        private static void TestString(string s, string expectedResult)
        {
            string result = IsBalanced(s);

            string message = result == expectedResult ? "Passed" : "Failed";
            Console.WriteLine(message);
        }

        private static string IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();
            bool isInvalid = false;

            foreach (char c in s)
            {
                char poppedChar = ' ';

                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }

                if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count > 0)
                    {
                        poppedChar = stack.Pop();
                    }
                    else
                    {
                        isInvalid = true;
                        break;
                    }
                }

                //---------------------------------------------------------

                if (poppedChar == '(' && c != ')')
                {
                    isInvalid = true;
                    break;
                }

                if (poppedChar == '{' && c != '}')
                {
                    isInvalid = true;
                    break;
                }

                if (poppedChar == '[' && c != ']')
                {
                    isInvalid = true;
                    break;
                }
            }

            string message;

            if (isInvalid)
            {
                message = "NO";
            }
            else
            {
                message = stack.Count == 0 ? "YES" : "NO";
            }

            return message;
        }

        //private static string IsBalanced2(string s)
                //{
                //    int len = s.Length;
                //    bool balanced = true;

                //    for (int n = 0; n < len; n++)
                //    {
                //        char first = s[n];
                //        char last = s[len - 1 - n];

                //        bool condition1 = first == '(' && last == ')';
                //        bool condition2 = first == '{' && last == '}';
                //        bool condition3 = first == '[' && last == ']';

                //        // only 1 condition can be true
                //        if (condition1 & !condition2 && !condition3)
                //        {
                //            balanced = true;
                //        }
                //    }
                //}

        private static string IsBalanced3(string s)
        {
            Stack<char> parenthesesStack = new Stack<char>();
            Stack<char> braclesStack = new Stack<char>();
            Stack<char> squareBracketsStack = new Stack<char>();

            bool parenthesesOpen = false;
            bool bracesOpen = false;
            bool squareBracketsOpen = false;
            bool invalid = false;

            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                        parenthesesOpen = true;
                        parenthesesStack.Push('(');
                        break;

                    case ')':
                        if (!parenthesesOpen)
                        {
                            invalid = true;
                        }
                        parenthesesOpen = false;
                        parenthesesStack.Pop();
                        break;

                    case '{':
                        bracesOpen = true;
                        braclesStack.Push('{');
                        break;

                    case '}':
                        if (!bracesOpen)
                        {
                            invalid = true;
                        }
                        bracesOpen = false;
                        braclesStack.Pop();
                        break;

                    case '[':
                        squareBracketsOpen = true;
                        squareBracketsStack.Push('[');
                        break;

                    case ']':
                        if (!squareBracketsOpen)
                        {
                            invalid = true;
                        }
                        squareBracketsOpen = false;
                        squareBracketsStack.Pop();
                        break;
                }

                if (invalid)
                {
                    break;
                }
            }

            string message;

            if (invalid)
            {
                message = "NO";
            }
            else
            {
                bool condition1 = parenthesesStack.Count == 0;
                bool condition2 = braclesStack.Count == 0;
                bool condition3 = squareBracketsStack.Count == 0;
                bool matched = condition1 && condition2 && condition3;
                message = matched ? "YES" : "NO";
            }

            return message;
        }
    }
}
