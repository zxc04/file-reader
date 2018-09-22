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

        public string ReadTextFile(string path, IEncryptionProvider encryptionProvider)
        {
            return ReadFile(FileTypes.Text, path, encryptionProvider);
        }

        public string ReadXmlFile(string path)
        {
            return ReadFile(FileTypes.Xml, path);
        }

        public string ReadFile(FileTypes fileType, string path, IEncryptionProvider encryptionProvider = null)
        {
            IContentReader reader = ContentReaderFactory.GetReader(fileType);

            string content = reader.ReadContent(path);

            if (encryptionProvider != null)
                content = encryptionProvider.Decrypt(content);

            return content;
        }
    }
}
