using OPP_Projektas.Client.Models.Roulette;
using OPP_Projektas.Server.Models.Roulette;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RouletteServer
{
    public class RouletteMessageCreatorShould
    {
        RouletteMessagesCreator rouletteMessagesCreator = new RouletteMessagesCreator();
        List<RouletteUser> Users = new List<RouletteUser>();

        [Theory]
        [InlineData(1, 10, 10)]
        [InlineData(0, 0, 0)]
        [InlineData(10, 1, 10)]
        [InlineData(-999, 0, 0)]
        public void CorrectlyFormsMessageForBiggestWin(int sk1, int sk2, int expect)
        {
            // Arrange
            Users.Add(new RouletteUser("User1"));
            Users.Add(new RouletteUser("User2"));
            Users[0].Winnings = sk1;
            Users[1].Winnings = sk2;
            // Act
            string actual = rouletteMessagesCreator.FormMessages(Users)[0];
            // Assert
            Assert.Equal(expected: $"Greatest winning: {expect}", actual: actual);
        }
        [Fact(Skip = "Not to implement")]
        public void ThrowsExceptionOnNegativeValueFound()
        {
            // Arrange
            Users.Add(new RouletteUser("User1"));
            Users.Add(new RouletteUser("User2"));
            Users[0].Winnings = 0;
            Users[1].Winnings = -10;
            // Act
            string actual = rouletteMessagesCreator.FormMessages(Users)[0];
            // Assert
            Assert.Throws<InvalidOperationException>(() => actual);
        }
    }
}
