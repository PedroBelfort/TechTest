using FluentAssertions;
using Moq;
using WordPuzzle.Interfaces;

namespace WordPuzzle.UnitTests.Services.Tests
{
    public class FileServiceTests
    {
        private readonly Mock<IFileService> fileServiceMock;

        public FileServiceTests()
        {
            fileServiceMock = new Mock<IFileService>();
        }

        [Fact]
        public void ExportFile_ShouldThrowArgumentException_WhenListIsNull()
        {
            // Arrange
            var fileService = fileServiceMock.Object;
            List<string> result = null;
            string path = "test.txt";

            fileServiceMock.Setup(x => x.ExportFile(It.IsAny<List<string>>(), It.IsAny<string>()))
          .Throws(new ArgumentException("The list is empty. Nothing to export to txt."));

            // Act
            Action action = () => fileService.ExportFile(result, path);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("The list is empty. Nothing to export to txt.");
        }

        [Fact]
        public void ExportFile_ShouldThrowArgumentException_WhenListIsEmpty()
        {
            // Arrange
            var fileService = fileServiceMock.Object;
            var result = new List<string>();
            string path = "test.txt";

            fileServiceMock.Setup(x => x.ExportFile(It.IsAny<List<string>>(), It.IsAny<string>()))
        .Throws(new ArgumentException("The list is empty. Nothing to export to txt."));

            // Act
            Action action = () => fileService.ExportFile(result, path);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("The list is empty. Nothing to export to txt.");
        }

        [Fact]
        public void ExportFile_ShouldCatchException_WhenFileWriteFails()
        {
            // Arrange
            var fileService = fileServiceMock.Object;
            var result = new List<string> { "word1", "word2" };
            string path = "invalidpath/invalidfile.txt";

            // Act
            Action action = () => fileService.ExportFile(result, path);

            // Assert
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void ReadFile_ShouldReturnContent_WhenFileExists()
        {
            // Arrange
            var fileService = fileServiceMock.Object;
            var expectedContent = new List<string> { "line1", "line2", "line3" };
            var path = "testfile.txt";
            fileServiceMock.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(expectedContent);

            // Act
            var result = fileService.ReadFile(path);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedContent);
        }

        [Fact]
        public void ReadFile_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
        {
            // Arrange
            var fileService = fileServiceMock.Object;
            var path = "nonexistentfile.txt";
            fileServiceMock.Setup(x => x.ReadFile(It.IsAny<string>())).Throws(new FileNotFoundException($"The file '{path}' was not found."));

            // Act
            Action action = () => fileService.ReadFile(path);

            // Assert
            action.Should().Throw<FileNotFoundException>()
                .WithMessage($"The file '{path}' was not found.");
        }

        [Fact]
        public void GetFilePath_ShouldReturnsCorrectPath()
        {
            // Arrange
            string baseDirectory = @"C:\Test\WordPuzzle\bin\Debug\net8.0\";
            string filePath = "Assets/words-english.txt";
            string modifiedPath = @"C:\Test\WordPuzzle\";
            string expectedPath = Path.Combine(modifiedPath, filePath);
            var fileService = fileServiceMock.Object;
           
            fileServiceMock.Setup(m => m.GetFilePath()).Returns(expectedPath);

            // Act
            string actualPath = fileService.GetFilePath();

            // Assert
            actualPath.Should().Be(expectedPath);
        }
    }
}
