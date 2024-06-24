using static hackathon_prefinal_build.Building;

namespace HackathonTest
{ 
    [TestClass]
    public class Building_Tests
    {
        [TestMethod]
        public void GetColumn_WithIncorrectIndex()
        {
            // Arrange
            int index = 20;
            string expected = "0";

            // Act
            string columnName = GetColumn(index);

            // Assert
            string actual = columnName;
            Assert.AreEqual(expected, actual);
        }
    }
}
