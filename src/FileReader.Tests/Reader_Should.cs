using Xunit;

namespace FileReader.Tests
{
    public class Reader_Should
    {
        [Fact]
        public void ReadText_WhenFileExists()
        {
            var reader = new Reader();
            var path = "TestFiles/TextFile.txt";

            string content = reader.ReadTextFile(path);

            Assert.NotEmpty(content);
        }

        [Fact]
        public void ReturnNull_WhenTextFileDoesntExist()
        {
            var reader = new Reader();
            var path = string.Empty;

            string content = reader.ReadTextFile(path);

            Assert.Null(content);
        }
    }
}
