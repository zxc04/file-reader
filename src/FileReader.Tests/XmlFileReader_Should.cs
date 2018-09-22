using FileReader.ContentReaders;
using Xunit;

namespace FileReader.Tests
{
    public class XmlFileReader_Should
    {
        [Fact]
        public void ReadContent_WhenFileExists()
        {
            var reader = new XmlFileReader();
            var path = "TestFiles/XmlFile.xml";

            string content = reader.ReadContent(path);

            Assert.NotEmpty(content);
        }

        [Fact]
        public void ReturnNull_WhenFileDoesntExist()
        {
            var reader = new XmlFileReader();
            var path = string.Empty;

            string content = reader.ReadContent(path);

            Assert.Null(content);
        }
    }
}
