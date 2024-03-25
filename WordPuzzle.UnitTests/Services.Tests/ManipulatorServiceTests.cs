using FluentAssertions;
using Moq;
using WordPuzzle.Interfaces;

namespace WordPuzzle.UnitTests.Services.Tests
{
    public class ManipulatorServiceTests
    {
        private readonly Mock<IManipulatorService> manipulatorServiceMock;

        public ManipulatorServiceTests()
        {
            this.manipulatorServiceMock = new Mock<IManipulatorService>();
        }

        [Fact]
        public void FindClosestWord_ShouldReturnClosestWord()
        {
            // Arrange
            string reference = "same";
            List<string> words = new List<string> { "none", "came", "baby" };
            this.manipulatorServiceMock.Setup(x => x.FindClosestWord(reference, words)).Returns("came");
            var manipulatorService = this.manipulatorServiceMock.Object;

            // Act
            string closestWord = manipulatorService.FindClosestWord(reference, words);

            // Assert
            closestWord.Should().Be("came");
        }
        [Fact]
        public void ReplaceCharByAlphabetIndex_ShouldReturnValidWords()
        {
            // Arrange
            string start = "cat";
            List<string> dictionary = new List<string> { "bat", "cot", "cat", "cab", "mat" };
            List<string> solution = new List<string> { "cot" };
            var expectedValidWords = new List<string> { "bat", "cab", "mat" };
            this.manipulatorServiceMock.Setup(x => x.ReplaceCharByAlphabetIndex(start, dictionary, solution)).Returns(expectedValidWords);
            var manipulatorService = this.manipulatorServiceMock.Object;

            // Act
            List<string> validWords = manipulatorService.ReplaceCharByAlphabetIndex(start, dictionary, solution);

            // Assert
            validWords.Should().BeEquivalentTo(expectedValidWords);
        }


        [Fact]
        public void ReplaceCharBySameIndex_ShouldReturnReplacedWord()
        {
            // Arrange
            string start = "cat";
            string end = "cut";
            List<string> dictionary = new List<string> { "bat", "cot", "cat", "cab", "mat" };
            this.manipulatorServiceMock.Setup(x => x.ReplaceCharBySameIndex(start, end, dictionary)).Returns("cut");
            var manipulatorService = this.manipulatorServiceMock.Object;

            // Act
            string replacedWord = manipulatorService.ReplaceCharBySameIndex(start, end, dictionary);

            // Assert
            replacedWord.Should().Be("cut");
        }

        [Fact]
        public void ReplaceCharBySameIndex_ShouldReturnEmptyString_WhenStartIsNull()
        {
            // Arrange
            string start = null;
            string end = "cut";
            List<string> dictionary = new List<string> { "bat", "cot", "cat", "cab", "mat" };
            this.manipulatorServiceMock.Setup(x => x.ReplaceCharBySameIndex(start, end, dictionary)).Returns(string.Empty);
            var manipulatorService = this.manipulatorServiceMock.Object;

            // Act
            string replacedWord = manipulatorService.ReplaceCharBySameIndex(start, end, dictionary);

            // Assert
            replacedWord.Should().BeEmpty();
        }

        [Fact]
        public void ReplaceCharBySameIndex_ShouldReturnEmptyString_WhenNoReplacementFound()
        {
            // Arrange
            string start = "dog";
            string end = "cat";
            List<string> dictionary = new List<string> { "bat", "cot", "cat", "cab", "mat" };
            this.manipulatorServiceMock.Setup(x => x.ReplaceCharBySameIndex(start, end, dictionary)).Returns(string.Empty);
            var manipulatorService = this.manipulatorServiceMock.Object;

            // Act
            string replacedWord = manipulatorService.ReplaceCharBySameIndex(start, end, dictionary);

            // Assert
            replacedWord.Should().BeEmpty();
        }

    }
}
