using System;
using System.Collections.Generic;

namespace ConnectingTownsProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        internal static void Main()
        {
            List<int> numberRoadsList = new List<int>
            {
                3, 4, 5
            };
            int totalRoads = ConnectingTowns(numberRoadsList.Count, numberRoadsList);       // 60
            Console.WriteLine($"totalRoads = {totalRoads}");

            numberRoadsList = new List<int>
            {
                1, 3
            };
            totalRoads = ConnectingTowns(numberRoadsList.Count, numberRoadsList);           // 3
            Console.WriteLine($"totalRoads = {totalRoads}");

            numberRoadsList = new List<int>
            {
                2, 2, 2
            };
            totalRoads = ConnectingTowns(numberRoadsList.Count, numberRoadsList);           // 8
            Console.WriteLine($"totalRoads = {totalRoads}");

            numberRoadsList = new List<int>
            {
                3, 784, 945, 778, 736, 252, 406, 796, 252, 621, 298, 513, 826, 159, 
                396, 502, 818, 820, 959, 826, 880, 728, 729, 26, 665, 609, 31, 711, 
                950, 908, 50, 203, 940, 863, 662, 476, 50, 733, 825, 871, 234, 133, 
                395, 680, 95, 290, 125, 909, 361, 593, 946, 534, 133, 798, 305, 266, 
                683, 856, 876, 446, 510, 900, 947, 254, 228, 101, 445, 125, 729, 559, 
                632, 978, 224, 767, 151, 290, 481, 912, 462, 638, 892, 823, 570, 718, 
                129, 699, 602, 965, 838, 943, 355, 968, 779, 928
            };
            totalRoads = ConnectingTowns(numberRoadsList.Count, numberRoadsList);           // 868553
            Console.WriteLine($"totalRoads = {totalRoads}");
        }

        // ReSharper disable once UnusedParameter.Local
        private static int ConnectingTowns(int numberTowns, List<int> numberRoadsList)
        {
            int totalRoads = 1;
            const int modulo = 1234567;

            // (a * b) % c = ((a % c) * (b % c)) % c
            foreach (var numberRoads in numberRoadsList)
            {
                totalRoads = ((totalRoads % modulo) * (numberRoads % modulo)) % modulo;
            }

            return totalRoads;
        }
    }
}
