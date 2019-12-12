using static System.Console;

namespace JumpingCloudsProblem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        // https://www.hackerrank.com/challenges/jumping-on-the-clouds/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=warmup

        public static void Main()
        {
            int[] cloudArray = {0, 1, 0, 0, 0, 1, 0};
            JumpingClouds jumpingClouds = new JumpingClouds();

            int minimumJumps = jumpingClouds.GetMinimiumJumps(cloudArray);

            WriteLine($"minimumJumps = {minimumJumps}");
            ReadKey();
        }
    }
}
