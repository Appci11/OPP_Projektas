using OPP_Projektas.Server.Models.Roulette;

namespace UnitTests.RouletteServer
{
    public class RouletteUserShould
    {
        [Fact]
        public void CorrectlyUseConstructorNr1()
        {
            // Arrange
            // Act
            RouletteUser user = new RouletteUser("User1");
            // Assert
            string actual = user.Username;
            Assert.Equal(expected: "User1", actual: actual);
        }

        [Fact]
        public void CorrectlyUseConstructorNr2()
        {
            // Arrange
            // Act
            RouletteUser user = new RouletteUser("u1" , "User1");
            // Assert
            string actualId = user.GameId;
            string actualUsername = user.Username;            
            Assert.Equal(expected: "u1", actual: actualId);
            Assert.Equal(expected: "User1", actual: actualUsername);
        }
    }
}
