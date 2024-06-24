using static hackathon_prefinal_build.Searcher;

namespace HackathonTests
{
    [TestClass]
    public class Searcher_Tests
    {
        [TestMethod]
        public void Is_There_WithValidParameters()
        {
            // Arrange
            string par1 = "Solution";
            string par2 = "Description";
            string par3 = "its solution5";

            bool expected = true;

            // Act
            bool isFound = IsThere(par1, par2, $"'{par3}'");

            // Assert
            bool actual = isFound;
            Assert.AreEqual(expected, actual, "Results are wrong");
        }

        [TestMethod]
        public void Is_There_WithIncorrectParameters()
        {
            // Arrange
            string par1 = "Solution";
            string par2 = "Description";
            string par3 = "its solution5";


            // Act and Assert
            Assert.ThrowsException<Microsoft.Data.SqlClient.SqlException>(() => IsThere(par1, par2, par3));
        }
    }
}
