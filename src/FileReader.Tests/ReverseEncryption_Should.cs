using FileReader.EncryptionProviders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FileReader.Tests
{
    public class ReverseEncryption_Should
    {
        [Fact]
        public void DecryptString()
        {
            ReverseEncryption provider = new ReverseEncryption();
            string input = "Test";
            string expected = "tseT";

            string actual = provider.Decrypt(input);

            Assert.Equal(expected, actual);
        }
    }
}
