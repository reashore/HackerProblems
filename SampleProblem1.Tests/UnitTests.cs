using System;
using Xunit;

namespace SampleProblem1.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            int[] state = { 1, 0, 0, 0, 0, 1, 0, 0 };
            int days = 1;

            // Act
            int[] result = Problem1.EvolveState(state, days);

            // Assert
            int[] expectedResult = {0, 1, 0, 0, 1, 0, 1, 0};
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            int[] state = { 1, 1, 1, 0, 1, 1, 1, 1 };
            int days = 2;

            // Act
            int[] result = Problem1.EvolveState(state, days);

            // Assert
            int[] expectedResult = { 0, 0, 0, 0, 0, 1, 1, 0 };
            Assert.Equal(expectedResult, result);
        }
    }
}
