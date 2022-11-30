using OPP_Projektas.Client.Models.Roulette;

namespace UnitTests
{
    public class ChipsAdapterShould
    {
        ChipsKeeper _chipsKeeper = new ChipsKeeper();

        [Fact]
        public void ReturnCorrectValuesOnGetChipsMinCall()
        {
            // Arrange
            ChipsAdapter Adapter = new ChipsAdapter(_chipsKeeper);
            // Act
            int[] actual = Adapter.GetChipsMin();
            // Assert
            int[] expected = { 0, 0, 0, 0, 0, 5 };
            Assert.Equal(expected: expected, actual: actual);
        }

        [Fact]
        public void ReturnCorrectValuesOnGetChipsMaxCall()
        {
            // Arrange
            ChipsAdapter Adapter = new ChipsAdapter(_chipsKeeper);
            // Act
            int[] actual = Adapter.GetChipsMax();
            // Assert
            int[] expected = { 500, 0, 0, 0, 0, 0 };
            Assert.Equal(expected: expected, actual: actual);
        }
        [Fact]
        public void ReturnCorrectValuesOnGetChipsCall()
        {
            // Arrange
            ChipsAdapter Adapter = new ChipsAdapter(_chipsKeeper);
            // Act
            int[] actual = Adapter.GetChips();
            // Assert
            int[] expected = { 25, 4, 3, 3, 3, 2 };
            Assert.Equal(expected: expected, actual: actual);
        }
    }
}
