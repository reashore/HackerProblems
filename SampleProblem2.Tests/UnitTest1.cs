using Xunit;

namespace SampleProblem2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            int[] array = { 2, 3, 4, 5, 6 };

            // Act
            int gcd = Problem2.GeneralizedGreatestCommonDivisor(array);

            // Assert
            const int expectedGcd = 1;
            Assert.Equal(expectedGcd, gcd);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            int[] array = { 2, 4, 6, 8, 10 };

            // Act
            int gcd = Problem2.GeneralizedGreatestCommonDivisor(array);

            // Assert
            const int expectedGcd = 2;
            Assert.Equal(expectedGcd, gcd);
        }
    }
}
