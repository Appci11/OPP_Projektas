using OPP_Projektas.Client.Models.Roulette;

namespace UnitTests.RouletteClient
{
    public class ChipsKeeperShould
    {
        ChipsKeeper Keeper = new ChipsKeeper();

        [Fact]
        public void Adds300ChipsCorrectly()
        {
            // Arrange
            Keeper.AddChips(300);
            // Act
            int actual = Keeper.Chips;
            // Assert
            Assert.Equal(expected: 800, actual: actual);
        }

        [Fact]
        public void Removes300ChipsCorrectly()
        {
            // Arrange
            Keeper.RemoveChips(300);
            // Act
            int actual = Keeper.Chips;
            // Assert
            Assert.Equal(expected: 200, actual: actual);
        }

        [Theory]
        [InlineData(5, 505)]
        [InlineData(50, 550)]
        [InlineData(500, 1000)]
        public void AddChipsCorrectly(int n, int exp)
        {
            // Arrange
            Keeper.AddChips(n);
            // Act
            int actual = Keeper.Chips;
            // Assert
            Assert.Equal(expected: exp, actual: actual);
        }

        [Theory]
        [InlineData(5, 495)]
        [InlineData(50, 450)]
        [InlineData(500, 0)]
        public void RemovesChipsCorrectly(int n, int exp)
        {
            // Arrange
            Keeper.RemoveChips(n);
            // Act
            int actual = Keeper.Chips;
            // Assert
            Assert.Equal(expected: exp, actual: actual);
        }
    }
}
