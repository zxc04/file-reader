using FileReader.ContentReaders;
using Xunit;

namespace FileReader.Tests
{
    public class TextFileReader_Should
    {
        [Fact]
        public void ReadContent_WhenFileExists()
        {
            var reader = new TextFileReader();
            var path = "TestFiles/TextFile.txt";

            string content = reader.ReadContent(path);

            Assert.NotEmpty(content);
        }

        [Fact]
        public void ReturnNull_WhenFileDoesntExist()
        {
            var reader = new TextFileReader();
            var path = string.Empty;

            string content = reader.ReadContent(path);

            Assert.Null(content);
        }
    }
}
