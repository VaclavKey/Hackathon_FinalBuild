using static hackathon_prefinal_build.XML_loader;

namespace HackathonTests
{
    [TestClass]
    public class XML_Tests
    {
        [TestMethod]
        public void MakeQuery_WithNonExistentFile()
        {
            // Arrange
            string filename = "file123";

            // Act and Assert
            Assert.ThrowsException<System.IO.FileNotFoundException>(() => MakeQuery(filename));
        }
    }
}
