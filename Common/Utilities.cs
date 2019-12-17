using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common
{
    public static class Utilities
    {
        public static string[] ReadTextFile(string fileName)
        {
            string location = Assembly.GetExecutingAssembly().Location;
            string rootDirectory = Path.GetDirectoryName(location);
            string fullFileName = Path.Combine(rootDirectory, fileName);
            string[] fileLines = File.ReadAllLines(fullFileName);

            return fileLines;
        }

        public static string Reverse(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int len = s.Length;

            for (int n = len - 1; 0 <= n; n--)
            {
                stringBuilder.Append(s[n]);
            }

            return stringBuilder.ToString();
        }

        public static string GetDistinctChars(string inputString)
        {
            return new string(inputString.Distinct().ToArray());
        }
    }
}
