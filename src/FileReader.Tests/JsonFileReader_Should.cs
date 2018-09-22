using FileReader.ContentReaders;
using Xunit;

namespace FileReader.Tests
{
    public class JsonFileReader_Should
    {
        [Fact]
        public void ReadContent_WhenFileExists()
        {
            var reader = new TextFileReader();
            var path = "TestFiles/JsonFile.txt";

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
