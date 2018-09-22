using FileReader.Common;
using System.IO;

namespace FileReader.RoleProviders
{
    public class SimpleRoleProvider : IRoleProvider
    {
        public bool HasAccess(string filePath, string role)
        {
            if (string.Compare(role, "admin", true) == 0)
                return true;

            if (Path.GetFileName(filePath).StartsWith("user_"))
                return true;

            return false;
        }
    }
}
