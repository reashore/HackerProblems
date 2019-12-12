namespace ReverseArrayProblem
{
    internal class Program
    {
        internal static void Main()
        {
            int[] array = {1, 4, 3, 2};
            int[] reversedArray = ReverseArray(array);
        }

        private static int[] ReverseArray(int[] array)
        {
            int len = array.Length;
            int[] reversedArray = new int[len];

            for (int n = 0; n < len; n++)
            {
                reversedArray[n] = array[len - 1 - n];
            }

            return reversedArray;
        }
    }
}
