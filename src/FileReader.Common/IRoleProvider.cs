namespace FileReader.Common
{
    public interface IRoleProvider
    {
        bool HasAccess(string filePath, string role);
    }
}
