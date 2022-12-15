using OPP_Projektas.Client.Models.Roulette;
using OPP_Projektas.Server.Models.Roulette;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RouletteServer
{
    public class RouletteChipMoverShould
    {
        List<RouletteUser> users = new List<RouletteUser>();

        [Fact]
        public void SendCorrectWinningIfUserWonBettingOnColour()
        {
            // Arrange
            RouletteUser user = new RouletteUser("User1");
            user.BetType = 3;
            user.BetValue = 1;
            user.BetAmmount = 10;
            users.Add(user);
            RouletteChipMover rouletteChipMover = new RouletteChipMover(users, 1);
            // Act
            rouletteChipMover.DecideChipMovement();
            // Assert
            Assert.Equal(expected: 20, actual: users[0].Winnings);
        }
        [Fact]
        public void SendCorrectWinningIfUserWonBettingOnThird()
        {
            // Arrange
            RouletteUser user = new RouletteUser("User1");
            user.BetType = 2;
            user.BetValue = 3;
            user.BetAmmount = 10;
            users.Add(user);
            RouletteChipMover rouletteChipMover = new RouletteChipMover(users, 1);
            // Act
            rouletteChipMover.DecideChipMovement();
            // Assert
            Assert.Equal(expected: 30, actual: users[0].Winnings);
        }
        [Fact]
        public void SendCorrectWinningIfUserWonBettingOnNumber()
        {
            // Arrange
            RouletteUser user = new RouletteUser("User1");
            user.BetType = 1;
            user.BetValue = 32;
            user.BetAmmount = 10;
            users.Add(user);
            RouletteChipMover rouletteChipMover = new RouletteChipMover(users, 1);
            // Act
            rouletteChipMover.DecideChipMovement();
            // Assert
            Assert.Equal(expected: 360, actual: users[0].Winnings);
        }

        [Fact]
        public void SendCorrectWinningIfUserLostBettingOnColour()
        {
            // Arrange
            RouletteUser user = new RouletteUser("User1");
            user.BetType = 3;
            user.BetValue = 2;
            user.BetAmmount = 10;
            users.Add(user);
            RouletteChipMover rouletteChipMover = new RouletteChipMover(users, 1);
            // Act
            rouletteChipMover.DecideChipMovement();
            // Assert
            Assert.Equal(expected: 0, actual: users[0].Winnings);
        }
        [Fact]
        public void SendCorrectWinningIfUserLostBettingOnThird()
        {
            // Arrange
            RouletteUser user = new RouletteUser("User1");
            user.BetType = 2;
            user.BetValue = 2;
            user.BetAmmount = 10;
            users.Add(user);
            RouletteChipMover rouletteChipMover = new RouletteChipMover(users, 1);
            // Act
            rouletteChipMover.DecideChipMovement();
            // Assert
            Assert.Equal(expected: 0, actual: users[0].Winnings);
        }
        [Fact]
        public void SendCorrectWinningIfUserLostBettingOnNumber()
        {
            // Arrange
            RouletteUser user = new RouletteUser("User1");
            user.BetType = 1;
            user.BetValue = 10;
            user.BetAmmount = 10;
            users.Add(user);
            RouletteChipMover rouletteChipMover = new RouletteChipMover(users, 1);
            // Act
            rouletteChipMover.DecideChipMovement();
            // Assert
            Assert.Equal(expected: 0, actual: users[0].Winnings);
        }

        [Fact]
        public void ThrowExceptionOnBadUserValuesFound()
        {
            // Arrange
            RouletteUser user = new RouletteUser("User1");
            user.BetType = -999;
            user.BetValue = -999;
            user.BetAmmount = -999;
            users.Add(user);
            RouletteChipMover rouletteChipMover = new RouletteChipMover(users, 1);
            // Act
            rouletteChipMover.DecideChipMovement();
            // Assert
            Assert.Throws<ArgumentException>(() => rouletteChipMover.DecideChipMovement());

        }
        [Fact]
        public void ThrowExceptionOnBadRollIndexValueFound()
        {
            // Arrange
            RouletteUser user = new RouletteUser("User1");
            user.BetType = -999;
            user.BetValue = -999;
            user.BetAmmount = -999;
            users.Add(user);
            RouletteChipMover rouletteChipMover = new RouletteChipMover(users, -99);
            // Act
            // Kazkaip galima gudriau, per Assert.Throws, bet neiseina
            bool caught = false;
            try {
                rouletteChipMover.DecideChipMovement();
            }
            catch(Exception e) { caught = true; }
            // Assert
            Assert.True(caught);
        }
    }
}
