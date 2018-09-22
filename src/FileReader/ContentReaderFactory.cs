using FileReader.Common;
using FileReader.ContentReaders;
using System;

namespace FileReader
{
    public class ContentReaderFactory
    {
        public static IContentReader GetReader(FileTypes fileType)
        {
            if (fileType == FileTypes.Text)
            {
                return new TextFileReader();
            }

            if (fileType == FileTypes.Xml)
            {
                return new XmlFileReader();
            }

            if (fileType == FileTypes.Json)
            {
                return new JsonFileReader();
            }

            throw new NotImplementedException();
        }
    }
}
