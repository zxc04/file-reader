using FileReader.RoleProviders;
using Xunit;

namespace FileReader.Tests
{
    public class SimpleRoleProvider_Should
    {
        [Fact]
        public void AllowAdmin()
        {
            SimpleRoleProvider provider = new SimpleRoleProvider();
            string path = "C:/user_test.txt";
            string role = "admin";
            bool expected = true;

            bool actual = provider.HasAccess(path, role);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AllowUser_WhenFileStartsWithUser()
        {
            SimpleRoleProvider provider = new SimpleRoleProvider();
            string path = "C:/user_test.txt";
            string role = "user";
            bool expected = true;

            bool actual = provider.HasAccess(path, role);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DenyUser_WhenFileDoesntStartWithUser()
        {
            SimpleRoleProvider provider = new SimpleRoleProvider();
            string path = "C:/admin_test.txt";
            string role = "user";
            bool expected = false;

            bool actual = provider.HasAccess(path, role);

            Assert.Equal(expected, actual);
        }
    }
}
