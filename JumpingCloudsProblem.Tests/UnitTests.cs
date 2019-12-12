using Xunit;

namespace JumpingCloudsProblem.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            int[] cloudArray = { 0, 1, 0, 0, 0, 1, 0 };
            JumpingClouds jumpingClouds = new JumpingClouds();

            // Act
            int minimumJumps = jumpingClouds.GetMinimiumJumps(cloudArray);

            // Assert
            Assert.Equal(3, minimumJumps);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            int[] cloudArray = { 0, 1, 0, 0, 0, 1, 0 };

            // Act
            int minimumJumps = JumpingCloudStatic.GetMinimiumJumps(cloudArray);

            // Assert
            Assert.Equal(3, minimumJumps);
        }
    }
}
