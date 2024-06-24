using static hackathon_prefinal_build.User;

namespace HackathonTests
{
    [TestClass]
    public class User_Tests
    {
        [TestMethod]
        public void GetRoleID_WithValidLogin()
        {
            // Arrange
            string login = "log1";
            int expected = 1;

            // Act
            int role_id = GetRoleID(login);

            // Assert
            int actual = role_id;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRoleID_WithNonExistentLogin()
        {
            // Arrange
            string login = "cooljoker";
            int expected = 0;

            // Act
            int role_id = GetRoleID(login);

            // Assert
            int actual = role_id;
            Assert.AreEqual(expected, actual);
        }
    }
}
