using FileReader.Common;
using Moq;
using System;
using Xunit;

namespace FileReader.Tests
{
    public class Reader_Should
    {
        #region Text File
        [Fact]
        public void ReadText_WhenFileExists()
        {
            var reader = new Reader();
            var path = "TestFiles/TextFile.txt";

            string content = reader.ReadTextFile(path);

            Assert.NotEmpty(content);
        }

        [Fact]
        public void ReadEncryptedText_WhenFileExists()
        {
            var path = "TestFiles/TextFile.txt";
            string expected = "expected";
            var encryptionProviderMock = new Mock<IEncryptionProvider>();
            encryptionProviderMock.Setup(m => m.Decrypt(It.IsAny<string>())).Returns(expected);
            var reader = new Reader(encryptionProviderMock.Object, null);

            string actual = reader.ReadTextFile(path, true);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnNull_WhenTextFileDoesntExist()
        {
            var reader = new Reader();
            var path = string.Empty;

            string content = reader.ReadTextFile(path);

            Assert.Null(content);
        }

        [Fact]
        public void ReadTextWithRole_WhenFileExists()
        {
            var path = "TestFiles/TextFile.txt";
            var role = "role";
            var roleProviderMock = new Mock<IRoleProvider>();
            roleProviderMock.Setup(m => m.HasAccess(path, role)).Returns(true);
            var reader = new Reader(null, roleProviderMock.Object);

            string content = reader.ReadTextFile(path, role: role);

            Assert.NotEmpty(content);
        }

        [Fact]
        public void ThrowUnauthorizedException_WhenTextFileAndUserNotInRole()
        {
            var path = "TestFiles/TextFile.txt";
            var role = "role";
            var roleProviderMock = new Mock<IRoleProvider>();
            roleProviderMock.Setup(m => m.HasAccess(path, role)).Returns(false);
            var reader = new Reader(null, roleProviderMock.Object);

            Action act = () => reader.ReadTextFile(path, role: role);

            Assert.Throws<UnauthorizedAccessException>(act);
        }
        #endregion Text File

        #region XML File
        [Fact]
        public void ReadXml_WhenFileExists()
        {
            var reader = new Reader();
            var path = "TestFiles/XmlFile.xml";

            string content = reader.ReadXmlFile(path);

            Assert.NotEmpty(content);
        }

        [Fact]
        public void ReturnNull_WhenXmlFileDoesntExist()
        {
            var reader = new Reader();
            var path = string.Empty;

            string content = reader.ReadXmlFile(path);

            Assert.Null(content);
        }

        [Fact]
        public void ReadXmlWithRole_WhenFileExists()
        {
            var path = "TestFiles/XmlFile.xml";
            var role = "role";
            var roleProviderMock = new Mock<IRoleProvider>();
            roleProviderMock.Setup(m => m.HasAccess(path, role)).Returns(true);
            var reader = new Reader(null, roleProviderMock.Object);

            string content = reader.ReadXmlFile(path, role);

            Assert.NotEmpty(content);
        }

        [Fact]
        public void ThrowUnauthorizedException_WhenXmlFileAndUserNotInRole()
        {
            var path = "TestFiles/XmlFile.xml";
            var role = "role";
            var roleProviderMock = new Mock<IRoleProvider>();
            roleProviderMock.Setup(m => m.HasAccess(path, role)).Returns(false);
            var reader = new Reader(null, roleProviderMock.Object);

            Action act = () => reader.ReadXmlFile(path, role);

            Assert.Throws<UnauthorizedAccessException>(act);
        }

        [Fact]
        public void ReadEncryptedXml_WhenFileExists()
        {
            var path = "TestFiles/XmlFile.xml";
            string expected = "expected";
            var encryptionProviderMock = new Mock<IEncryptionProvider>();
            encryptionProviderMock.Setup(m => m.Decrypt(It.IsAny<string>())).Returns(expected);
            var reader = new Reader(encryptionProviderMock.Object, null);

            string actual = reader.ReadXmlFile(path, isEncrypted: true);

            Assert.Equal(expected, actual);
        }
        #endregion XML File

        #region Json File
        [Fact]
        public void ReadJson_WhenFileExists()
        {
            var reader = new Reader();
            var path = "TestFiles/JsonFile.txt";

            string content = reader.ReadJsonFile(path);

            Assert.NotEmpty(content);
        }

        [Fact]
        public void ReturnNull_WhenJsonFileDoesntExist()
        {
            var reader = new Reader();
            var path = string.Empty;

            string content = reader.ReadJsonFile(path);

            Assert.Null(content);
        }
        #endregion Json File
    }
}
