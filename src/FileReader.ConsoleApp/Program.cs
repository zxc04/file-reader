using FileReader.Common;
using FileReader.EncryptionProviders;
using FileReader.RoleProviders;
using System;

namespace FileReader.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;

            while (!done)
            {
                string input;
                FileTypes fileType = FileTypes.Text;
                bool isEncrypted = false;
                bool useRoles = false;
                string role = null;
                string path = null;

                Console.Write("File type (0 = text, 1 = xml, 2 = json): ");
                input = Console.ReadLine();
                fileType = (FileTypes)int.Parse(input);

                Console.Write("Use encryption (y = Yes, n = No)? ");
                input = Console.ReadLine();
                isEncrypted = input == "y";

                if (isEncrypted)
                {
                }

                Console.Write("Use role based security (y = Yes, n = No)? ");
                input = Console.ReadLine();
                useRoles = input == "y";

                if (useRoles)
                {
                    Console.Write("Enter your role: ");
                    input = Console.ReadLine();
                    role = input;
                }

                Console.Write("Enter file path: ");
                input = Console.ReadLine();
                path = input;

                Console.WriteLine($"Reading file {path}");

                string content = ReadFile(fileType, path, isEncrypted, useRoles, role);
                Console.WriteLine(content);

                Console.Write("Do you want to read another file (y = Yes, n = No)? ");
                input = Console.ReadLine();
                done = input == "n";
            }
        }

        static string ReadFile(FileTypes fileType, string path, bool isEncrypted, bool useRoles, string role)
        {
            IEncryptionProvider encryptionProvider = null;
            IRoleProvider roleProvider = null;

            if (isEncrypted)
                encryptionProvider = new ReverseEncryption();

            if (useRoles)
                roleProvider = new SimpleRoleProvider();

            Reader reader = new Reader(encryptionProvider, roleProvider);

            try
            {
                return reader.ReadFile(fileType, path, isEncrypted: isEncrypted, role: role);
            }
            catch(UnauthorizedAccessException)
            {
                return $"ERROR: Role \"{role}\" is not authorized to access this file";
            }
        }
    }
}
