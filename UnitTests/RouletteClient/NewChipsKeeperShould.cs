using OPP_Projektas.Client.Models.Roulette;

namespace UnitTests.RouletteClient
{
    public class NewChipsKeeperShould
    {

        [Fact]
        public void SetsCorrectValueOnDefaultConstructor()
        {
            // Arrange
            NewChipsKeeper keeper = new NewChipsKeeper();
            // Act
            int[] arr = keeper.Chips;

            // Assert
            Assert.Equal(expected: 0, actual: arr[0]);
            Assert.Equal(expected: 0, actual: arr[1]);
            Assert.Equal(expected: 0, actual: arr[2]);
            Assert.Equal(expected: 0, actual: arr[3]);
            Assert.Equal(expected: 0, actual: arr[4]);
            Assert.Equal(expected: 5, actual: arr[5]);
        }


        [Theory]
        [InlineData(1, 1, 1, 1, 1, 1)]
        [InlineData(5, 5, 5, 5, 5, 5)]
        [InlineData(1, 2, 3, 4, 5, 6)]
        public void SetsCorrectValueOnOverloadedConstructor(int sk1, int sk2, int sk3, int sk4, int sk5, int sk6)
        {

            // Arrange
            int[] arr = new int[] { sk1, sk2, sk3, sk4, sk5, sk6 };
            // Act
            NewChipsKeeper keeper = new NewChipsKeeper(arr);
            // Assert
            Assert.Equal(expected: arr, actual: keeper.Chips);
        }
    }
}
