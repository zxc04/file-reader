using FileReader.Common;
using System.IO;

namespace FileReader.ContentReaders
{
    public class JsonFileReader : IContentReader
    {        
        public string ReadContent(string path)
        {
            if (!File.Exists(path))
                return null;

            return File.ReadAllText(path);
        }
    }
}
