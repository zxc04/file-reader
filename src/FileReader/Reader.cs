using System.IO;

namespace FileReader
{
    public class Reader
    {
        public string ReadTextFile(string path)
        {
            if (!File.Exists(path))
                return null;

            return File.ReadAllText(path);
        }
    }
}
