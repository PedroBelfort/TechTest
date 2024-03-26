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
            string start = "cata";
            List<string> dictionary = new List<string> { "bate", "cota", "cata", "cabe", "mati" };
            List<string> solution = new List<string> { "cota" };
            var expectedValidWords = new List<string> { "bate", "cabe", "mati" };
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
            string start = "cata";
            string end = "cute";
            List<string> dictionary = new List<string> { "bate", "cota", "cata", "cabe", "mati" };
            this.manipulatorServiceMock.Setup(x => x.ReplaceCharBySameIndex(start, end)).Returns("cute");
            var manipulatorService = this.manipulatorServiceMock.Object;

            // Act
            string replacedWord = manipulatorService.ReplaceCharBySameIndex(start, end);

            // Assert
            replacedWord.Should().Be("cute");
        }

        [Fact]
        public void ReplaceCharBySameIndex_ShouldReturnEmptyString_WhenStartIsNull()
        {
            // Arrange
            string start = null;
            string end = "cute";
            List<string> dictionary = new List<string> { "bate", "cota", "cata", "cabe", "mati" };
            this.manipulatorServiceMock.Setup(x => x.ReplaceCharBySameIndex(start, end)).Returns(string.Empty);
            var manipulatorService = this.manipulatorServiceMock.Object;

            // Act
            string replacedWord = manipulatorService.ReplaceCharBySameIndex(start, end);

            // Assert
            replacedWord.Should().BeEmpty();
        }

        [Fact]
        public void ReplaceCharBySameIndex_ShouldReturnEmptyString_WhenNoReplacementFound()
        {
            // Arrange
            string start = "dogg";
            string end = "cata";
            List<string> dictionary = new List<string> { "bate", "cota", "cata", "cabe", "mati" };
            this.manipulatorServiceMock.Setup(x => x.ReplaceCharBySameIndex(start, end)).Returns(string.Empty);
            var manipulatorService = this.manipulatorServiceMock.Object;

            // Act
            string replacedWord = manipulatorService.ReplaceCharBySameIndex(start, end);

            // Assert
            replacedWord.Should().BeEmpty();
        }

    }
}
