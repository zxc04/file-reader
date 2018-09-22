using FileReader.Common;
using System;
using System.IO;

namespace FileReader
{
    public class Reader
    {
        private readonly IEncryptionProvider encryptionProvider;
        private readonly IRoleProvider roleProvider;

        public Reader()
        {
            encryptionProvider = null;
            roleProvider = null;
        }

        public Reader(IEncryptionProvider encryptionProvider, IRoleProvider roleProvider)
        {
            this.encryptionProvider = encryptionProvider;
            this.roleProvider = roleProvider;
        }

        public string ReadTextFile(string path)
        {
            return ReadFile(FileTypes.Text, path);
        }

        public string ReadTextFile(string path, bool isEncrypted)
        {
            return ReadFile(FileTypes.Text, path, isEncrypted: true);
        }

        public string ReadXmlFile(string path)
        {
            return ReadFile(FileTypes.Xml, path);
        }

        public string ReadXmlFile(string path, string role)
        {
            return ReadFile(FileTypes.Xml, path, role: role);
        }

        public string ReadFile(FileTypes fileType, string path, bool isEncrypted = false, string role = null)
        {
            if (roleProvider != null && !roleProvider.HasAccess(path, role))
                throw new UnauthorizedAccessException();

            IContentReader reader = ContentReaderFactory.GetReader(fileType);

            string content = reader.ReadContent(path);

            if (isEncrypted && encryptionProvider != null)
                content = encryptionProvider.Decrypt(content);

            return content;
        }
    }
}
