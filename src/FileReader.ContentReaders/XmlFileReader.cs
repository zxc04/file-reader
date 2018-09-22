using FileReader.Common;
using System.IO;

namespace FileReader.ContentReaders
{
    public class XmlFileReader : IContentReader
    {
        public string ReadContent(string path)
        {
            if (!File.Exists(path))
                return null;

            return File.ReadAllText(path);
        }
    }
}
