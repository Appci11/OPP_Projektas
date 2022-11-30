using OPP_Projektas.Shared.Models.Roulette.Iterator;

namespace UnitTests
{
    public class MyItterableCollectionShould
    {
        MyIterableCollection Collection = new MyIterableCollection();

        [Fact]
        public void SuccessfullyAddsToLog()
        {
            // Arrange
            Collection.AddToLog("Log1");

            // Act
            string actual = Collection.GetItem(0);
            // Assert
            Assert.Equal(expected: "Log1", actual: actual);
        }
        [Fact]
        public void SuccessfullyAddsToUsers()
        {
            // Arrange
            Collection.AddUser("User1");
            // Act
            string actual = Collection.GetItem(0);
            // Assert
            Assert.Equal(expected: "User1", actual: actual);
        }
        [Fact]
        public void SuccessfullySetsStats()
        {
            // Arrange
            Collection.SetStats(1000, 2);
            // Act
            string actual = Collection.GetItem(0);
            // Assert
            Assert.Equal(expected: "Current balance: 1000", actual: actual);
        }

        [Fact]
        public void GetItemsCountReturns7()
        {
            // Arrange
            Collection.AddToLog("Log1");    //+1
            Collection.AddToLog("Log2");    //+1
            Collection.AddToLog("Log3");    //+1
            Collection.AddUser("User1");    //+1
            Collection.AddUser("User2");    //+1
            Collection.SetStats(1000, 2);   //+2
            // Act
            int actual = Collection.GetItemsCount();
            // Assert
            Assert.Equal(expected: 7, actual: actual);
        }
        [Fact]
        public void GetExpectedValueOfLog()
        {
            // Arrange
            Collection.AddToLog("Log1");
            Collection.AddToLog("Log2");
            Collection.AddToLog("Log3");
            Collection.AddUser("User1");
            Collection.AddUser("User2");
            Collection.SetStats(1000, 2);
            // Act
            string actual = Collection.GetItem(0);
            // Assert
            Assert.Equal(expected: "Log1", actual: actual);

        }
        [Fact]
        public void GetExpectedValueOfUser()
        {
            // Arrange
            Collection.AddToLog("Log1");
            Collection.AddToLog("Log2");
            Collection.AddToLog("Log3");
            Collection.AddUser("User1");
            Collection.AddUser("User2");
            Collection.SetStats(1000, 2);
            // Act
            string actual = Collection.GetItem(3);
            // Assert
            Assert.Equal(expected: "User1", actual: actual);

        }
        [Fact]
        public void GetExpectedValueOfStats()
        {
            // Arrange
            Collection.AddToLog("Log1");
            Collection.AddToLog("Log2");
            Collection.AddToLog("Log3");
            Collection.AddUser("User1");
            Collection.AddUser("User2");
            Collection.SetStats(1000, 2);
            // Act
            string actual = Collection.GetItem(5);
            // Assert
            Assert.Equal(expected: "Current balance: 1000", actual: actual);
        }
        [Fact]
        public void SuccessfullyReturnsIEnumerator()
        {
            // Arrange
            // Act
            var actual = Collection.GetEnumerator();
            // Assert
            // Bent jau ne null grazina, tiek uzteks patikrai...
            Assert.NotNull(actual);
        }
    }
}
