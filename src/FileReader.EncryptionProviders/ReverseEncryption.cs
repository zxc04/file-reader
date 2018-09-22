using FileReader.Common;
using System;

namespace FileReader.EncryptionProviders
{
    public class ReverseEncryption : IEncryptionProvider
    {
        public string Decrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
