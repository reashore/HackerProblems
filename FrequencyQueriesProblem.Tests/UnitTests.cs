using System.Collections.Generic;
using Xunit;

namespace FrequencyQueriesProblem.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            List<List<int>> queries = new List<List<int>>
            {
                new List<int>{1, 1},
                new List<int>{2, 2},
                new List<int>{3, 2},
                new List<int>{1, 1},
                new List<int>{1, 1},
                new List<int>{2, 1},
                new List<int>{3, 2}
            };

            // Act
            (Dictionary<int, int> dataDict, Dictionary<int, int> frequencyDict, List<int> resultList) = FrequencyQueries.FrequeryQuery(queries);          // [0, 1]

            // Assert
            Dictionary<int, int> expectedDataDict = new Dictionary<int, int>
            {
                [1] = 2
            };
            Dictionary<int, int> expectedFrequencyDict = new Dictionary<int, int>
            {
                [1] = 1
            };
            List<int> expectedResultList = new List<int> {0, 1};

            Assert.Equal(expectedResultList, resultList);
            Assert.Equal(expectedResultList, resultList);
            Assert.Equal(expectedResultList, resultList);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            List<List<int>> queries = new List<List<int>>
            {
                new List<int>{1, 5},
                new List<int>{1, 6},
                new List<int>{3, 2},
                new List<int>{1, 10},
                new List<int>{1, 10},
                new List<int>{1, 6},
                new List<int>{2, 5},
                new List<int>{3, 2}
            };

            // Act
            (Dictionary<int, int> dataDict, Dictionary<int, int> frequencyDict, List<int> resultList) = FrequencyQueries.FrequeryQuery(queries);                    // [0, 1]

            // Assert
            List<int> expectedResultList = new List<int> {0, 1};

            Assert.Equal(expectedResultList, resultList);
            Assert.Equal(expectedResultList, resultList);
            Assert.Equal(expectedResultList, resultList);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            List<List<int>> queries = new List<List<int>>
            {
                new List<int>{3, 4},
                new List<int>{2, 1003},
                new List<int>{1, 16},
                new List<int>{3, 1}
            };

            // Act
            (Dictionary<int, int> dataDict, Dictionary<int, int> frequencyDict, List<int> resultList) = FrequencyQueries.FrequeryQuery(queries);

            // Assert
            Dictionary<int, int> expectedDataDict = new Dictionary<int, int>
            {
                [16] = 1
            };
            Dictionary<int, int> expectedFrequencyDict = new Dictionary<int, int>
            {
                [1] = 1
            };
            List<int> expectedResultList = new List<int> {0, 1};

            Assert.Equal(expectedResultList, resultList);
            Assert.Equal(expectedResultList, resultList);
            Assert.Equal(expectedResultList, resultList);
        }

        [Fact]
        public void Test4()
        {
            // Arrange
            List<List<int>> queries = new List<List<int>>
            {
                new List<int>{1, 3},
                new List<int>{2, 3},
                new List<int>{3, 2},
                new List<int>{1, 4},
                new List<int>{1, 5},
                new List<int>{1, 5},
                new List<int>{1, 4},
                new List<int>{3, 2},
                new List<int>{2, 4},
                new List<int>{3, 2}
            };

            // Act
            (Dictionary<int, int> dataDict, Dictionary<int, int> frequencyDict, List<int> resultList) = FrequencyQueries.FrequeryQuery(queries);                    // [0, 1, 1]

            // Assert
            Dictionary<int, int> expectedDataDict = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 1,
                [3] = 1,
                [4] = 1,
                [5] = 1
            };
            Dictionary<int, int> expectedFrequencyDict = new Dictionary<int, int>
            {
                [1] = 5
            };
            List<int> expectedResultList = new List<int> {0, 1, 1};

            Assert.Equal(expectedFrequencyDict, frequencyDict);
            Assert.Equal(expectedResultList, resultList);
            Assert.Equal(expectedResultList, resultList);
        }

        [Fact]
        public void Test5()
        {
            // Arrange
            List<List<int>> queries = new List<List<int>>
            {
                new List<int>{1, 1},
                new List<int>{1, 2},
                new List<int>{1, 3},
                new List<int>{1, 4},
                new List<int>{1, 5},
                new List<int>{3, 1}
            };

            // Act
            (Dictionary<int, int> dataDict, Dictionary<int, int> frequencyDict, List<int> resultList) = FrequencyQueries.FrequeryQuery(queries);

            // Assert
            Dictionary<int, int> expectedDataDict = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 1,
                [3] = 1,
                [4] = 1,
                [5] = 1
            };
            Dictionary<int, int> expectedFrequencyDict = new Dictionary<int, int>
            {
                [1] = 5
            };
            List<int> expectedResultList = new List<int> {1};

            Assert.Equal(expectedDataDict, dataDict);
            Assert.Equal(expectedFrequencyDict, frequencyDict);
            Assert.Equal(expectedResultList, resultList);
        }

        [Fact]
        public void Test6()
        {
            // Arrange
            List<List<int>> queries = new List<List<int>>
            {
                new List<int>{1, 1},
                new List<int>{1, 2},
                new List<int>{1, 3},
                new List<int>{2, 3},
                new List<int>{3, 1}
            };

            // Act
            (Dictionary<int, int> dataDict, Dictionary<int, int> frequencyDict, List<int> resultList) = FrequencyQueries.FrequeryQuery(queries);

            // Assert
            Dictionary<int, int> expectedDataDict = new Dictionary<int, int>
            {
                [1] = 1, 
                [2] = 1
            };
            Dictionary<int, int> expectedFrequencyDict = new Dictionary<int, int>
            {
                [1] = 2
            };
            List<int> expectedResultList = new List<int> {1};

            Assert.Equal(expectedDataDict, dataDict);
            Assert.Equal(expectedFrequencyDict, frequencyDict);
            Assert.Equal(expectedResultList, resultList);
        }

        [Fact]
        public void Test7()
        {
            // Arrange
            List<List<int>> queries = new List<List<int>>
            {
                new List<int>{1, 1},
                new List<int>{1, 2},
                new List<int>{1, 3},
                new List<int>{3, 1},
                new List<int>{2, 3},
                new List<int>{2, 2},
                new List<int>{3, 1}
            };

            // Act
            (Dictionary<int, int> dataDict, Dictionary<int, int> frequencyDict, List<int> resultList) = FrequencyQueries.FrequeryQuery(queries);

            // Assert
            Dictionary<int, int> expectedDataDict = new Dictionary<int, int>
            {
                [1] = 1
            };
            Dictionary<int, int> expectedFrequencyDict = new Dictionary<int, int>
            {
                [1] = 1
            };
            List<int> expectedResultList = new List<int> {1, 1};

            Assert.Equal(expectedDataDict, dataDict);
            Assert.Equal(expectedFrequencyDict, frequencyDict);
            Assert.Equal(expectedResultList, resultList);
        }

        [Fact]
        public void Test8()
        {
            // Arrange
            List<List<int>> queries = new List<List<int>>
            {
                new List<int>{1, 2},
                new List<int>{3, 1},
                new List<int>{2, 1},
                new List<int>{2, 2},
                new List<int>{3, 1}
            };

            // Act
            (Dictionary<int, int> dataDict, Dictionary<int, int> frequencyDict, List<int> resultList) = FrequencyQueries.FrequeryQuery(queries);

            // Assert
            Dictionary<int, int> expectedDataDict = new Dictionary<int, int>();
            Dictionary<int, int> expectedFrequencyDict = new Dictionary<int, int>();
            List<int> expectedResultList = new List<int> {1, 0};

            Assert.Equal(expectedDataDict, dataDict);
            Assert.Equal(expectedFrequencyDict, frequencyDict);
            Assert.Equal(expectedResultList, resultList);
        }
    }
}
