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

        public string ReadTextFile(string path, bool isEncrypted = false, string role = null)
        {
            return ReadFile(FileTypes.Text, path, role: role, isEncrypted: isEncrypted);
        }
        
        public string ReadXmlFile(string path, string role = null, bool isEncrypted = false)
        {
            return ReadFile(FileTypes.Xml, path, role: role, isEncrypted: isEncrypted);
        }

        public string ReadJsonFile(string path, bool isEncrypted = false)
        {
            return ReadFile(FileTypes.Json, path, isEncrypted: isEncrypted);
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
