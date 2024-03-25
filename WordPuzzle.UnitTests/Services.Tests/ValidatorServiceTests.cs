using FluentAssertions;
using Moq;
using WordPuzzle.Exceptions;
using WordPuzzle.Interfaces;
using WordPuzzle.Services;

namespace WordPuzzle.UnitTests.Services.Tests
{
    public class ValidatorServiceTests
    {
        private readonly Mock<IValidatorService> validatorServiceMock;

        public ValidatorServiceTests()
        {
            this.validatorServiceMock = new Mock<IValidatorService>();
        }

        [Fact]
        public void InvalidLengthWord_ShouldThrowWordValidationException_WhenWordLengthIsNotFour()
        {
            // Arrange
            string word = "tes";
            this.validatorServiceMock.Setup(x => x.InvalidLengthWord(It.IsAny<string>()))
                .Throws(new WordValidationException($"The word '{word}' does not have the required length of 4 characters."));
            var validatorService = this.validatorServiceMock.Object;

            // Act
            Action act = () => validatorService.InvalidLengthWord(word);

            // Assert
            act.Should().Throw<WordValidationException>()
               .WithMessage($"The word '{word}' does not have the required length of 4 characters.");
        }

        [Fact]
        public void InvalidLengthWord_ShouldNotThrowException_WhenWordLengthIsFour()
        {
            // Arrange
            string word = "abcd";
            this.validatorServiceMock.Setup(x => x.InvalidLengthWord(It.IsAny<string>()));
            var validatorService = this.validatorServiceMock.Object;

            // Act
            Action act = () => validatorService.InvalidLengthWord(word);

            // Assert
            act.Should().NotThrow<WordValidationException>();
        }

        [Fact]
        public void WordNotExistOnDictionary_ShouldThrowWordValidationException_WhenWordDoesNotExistInDictionary()
        {
            // Arrange

            string word = "test";
            var dictionary = new List<string> { "word", "game", "play" };
            this.validatorServiceMock.Setup(x => x.WordNotExistOnDictionary(word, dictionary)).Throws(new WordValidationException($"The word '{word}' does not exist in the dictionary."));

            var validatorService = this.validatorServiceMock.Object;

            // Act
            Action act = () => validatorService.WordNotExistOnDictionary(word, dictionary);

            // Assert
            act.Should().Throw<WordValidationException>()
               .WithMessage($"The word '{word}' does not exist in the dictionary.");
        }

        [Fact]
        public void WordNotExistOnDictionary_ShouldNotThrowException_WhenWordExistsInDictionary()
        {
            // Arrange
            string word = "word";
            var dictionary = new List<string> { "word", "game", "play" };

            this.validatorServiceMock.Setup(x => x.WordNotExistOnDictionary(word, dictionary));

            var validatorService = this.validatorServiceMock.Object;

            // Act
            Action act = () => validatorService.WordNotExistOnDictionary(word, dictionary);

            // Assert
            act.Should().NotThrow<WordValidationException>();
        }
    }
}
