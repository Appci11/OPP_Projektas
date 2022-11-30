using OPP_Projektas.Shared.Models.Roulette;

namespace UnitTests
{
    public class WheelShould
    {
        Wheel Wheel = new Wheel();

        [Fact]
        public void GetsCorrectNumberAndValueOfWheelNumberIndex0()
        {
            // Arrange
            WheelNumber number = Wheel.WheelNumbers[0];
            // Act
            int actual1 = number.Number;
            string actual2 = number.Colour.ToString();
            // Assert
            Assert.Equal(expected: 0, actual: actual1);
            Assert.Equal(expected: "Green", actual: actual2);
        }

        [Fact]
        public void GetsCorrectNumberAndValueOfWheelNumberIndex5()
        {
            // Arrange
            WheelNumber number = Wheel.WheelNumbers[5];
            // Act
            int actual1 = number.Number;
            string actual2 = number.Colour.ToString();
            // Assert
            Assert.Equal(expected: 21, actual: actual1);
            Assert.Equal(expected: "Red", actual: actual2);
        }

        [Fact]
        public void GetsCorrectNumberAndValueOfWheelNumberIndex10()
        {
            // Arrange
            WheelNumber number = Wheel.WheelNumbers[10];
            // Act
            int actual1 = number.Number;
            string actual2 = number.Colour.ToString();
            // Assert
            Assert.Equal(expected: 6, actual: actual1);
            Assert.Equal(expected: "Black", actual: actual2);
        }

        [Fact]
        public void GetsCorrectNumberAndValueOfWheelNumberIndex36()
        {
            // Arrange
            WheelNumber number = Wheel.WheelNumbers[36];
            // Act
            int actual1 = number.Number;
            string actual2 = number.Colour.ToString();
            // Assert
            Assert.Equal(expected: 26, actual: actual1);
            Assert.Equal(expected: "Black", actual: actual2);
        }
    }
}
