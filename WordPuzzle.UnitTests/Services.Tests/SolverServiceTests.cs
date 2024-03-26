using FluentAssertions;
using Moq;
using WordPuzzle.Interfaces;
using WordPuzzle.Services;

namespace WordPuzzle.UnitTests.Services.Tests
{
    public class SolverServiceTests
    {
        private readonly Mock<IManipulatorService> manipulatorServiceMock;

        public SolverServiceTests()
        {
            manipulatorServiceMock = new Mock<IManipulatorService>();
        }

        [Fact]
        public void Solve_ShouldReturnSolutionList_WhenStartAndEndWordsAreSame()
        {
            // Arrange
            var start = "test";
            var end = "test";
            var dictionary = new List<string> { "test", "best", "rest" };
            var expectedSolution = new List<string> { "test" };
            manipulatorServiceMock.Setup(m => m.ReplaceCharByAlphabetIndex(start, dictionary, It.IsAny<List<string>>())).Returns(new List<string>());
            manipulatorServiceMock.Setup(m => m.FindClosestWord(end, It.IsAny<List<string>>())).Returns(end);
            manipulatorServiceMock.Setup(m => m.ReplaceCharBySameIndex(end, end)).Returns(string.Empty);
            var solverService = new SolverService(manipulatorServiceMock.Object);

            // Act
            var solution = solverService.Solve(start, end, dictionary);

            // Assert
            solution.Should().BeEquivalentTo(expectedSolution);
        }

        [Fact]
        public void Solve_ShouldReturnSolutionList_WhenEndWordNotFoundInDictionary()
        {
            // Arrange
            var start = "test";
            var end = "four";
            var dictionary = new List<string> { "test", "best", "rest" };
            var expectedSolution = new List<string> { "test", "No intermediate word found", "four" };
            manipulatorServiceMock.Setup(m => m.ReplaceCharByAlphabetIndex(start, dictionary, It.IsAny<List<string>>())).Returns(new List<string>());
            manipulatorServiceMock.Setup(m => m.FindClosestWord(end, It.IsAny<List<string>>())).Returns((string)null);
            manipulatorServiceMock.Setup(m => m.ReplaceCharBySameIndex(It.IsAny<string>(), end)).Returns(string.Empty);
            var solverService = new SolverService(manipulatorServiceMock.Object);

            // Act
            var solution = solverService.Solve(start, end, dictionary);

            // Assert
            solution.Should().BeEquivalentTo(expectedSolution);
        }

        [Fact]
        public void Solve_ShouldReturnSolutionList_WhenEndWordFoundAfterMultipleIterations()
        {
            // Arrange
            var start = "test";
            var end = "best";
            var dictionary = new List<string> { "test", "best", "rest" };
            var expectedSolution = new List<string> { "test", "best" };
            manipulatorServiceMock.SetupSequence(m => m.ReplaceCharByAlphabetIndex(start, dictionary, It.IsAny<List<string>>()))
                .Returns(new List<string> { "best" })
                .Returns(new List<string>());
            manipulatorServiceMock.Setup(m => m.FindClosestWord(end, It.IsAny<List<string>>())).Returns(end);
            manipulatorServiceMock.Setup(m => m.ReplaceCharBySameIndex(end, end)).Returns(string.Empty);
            var solverService = new SolverService(manipulatorServiceMock.Object);

            // Act
            var solution = solverService.Solve(start, end, dictionary);

            // Assert
            solution.Should().BeEquivalentTo(expectedSolution);
        }
    }
}
