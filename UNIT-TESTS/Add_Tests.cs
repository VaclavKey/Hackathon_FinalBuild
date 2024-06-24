using hackathon_prefinal_build;
using static hackathon_prefinal_build.Add;

namespace HackathonTests
{
    [TestClass]
    public class Add_Tests
    {
        [TestMethod]
        public void AddUser_WithNonAdminRole()
        {
            // Arrange
            Globals.currentRole = "Non-Admin";

            // Act and Assert
            Assert.ThrowsException<System.Exception>(() => Add.User());
        }
    }
}
