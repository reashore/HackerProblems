using System.IO;
using System.Reflection;

namespace Common
{
    public static class Utilities
    {
        private static string[] ReadData(string fileName)
        {
            string location = Assembly.GetExecutingAssembly().Location;
            string rootDirectory = Path.GetDirectoryName(location);
            string fullFileName = Path.Combine(rootDirectory, fileName);
            string[] fileLines = File.ReadAllLines(fullFileName);

            return fileLines;
        }
    }
}
