using FileReader.Common;
using System.IO;

namespace FileReader
{
    public class Reader
    {
        public string ReadTextFile(string path)
        {
            return ReadFile(FileTypes.Text, path);
        }

        public string ReadXmlFile(string path)
        {
            return ReadFile(FileTypes.Xml, path);
        }

        private string ReadFile(FileTypes fileType, string path)
        {
            IContentReader reader = ContentReaderFactory.GetReader(fileType);

            return reader.ReadContent(path);
        }
    }
}
