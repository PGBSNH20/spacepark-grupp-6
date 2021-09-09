using System;
using System.Collections.Generic;
using ClassLibrary;
using Xunit;

namespace SpaceTests
{
    public class ParkTests
    {
        [Fact]
        public void When_Calling_ParkingLots_Expect_5()
        {
            // Arrange
            IParking parking = new Parking();
            // Act
            var parkingLots = parking.ParkingLots();
            // Assert
            Assert.Equal(5, parkingLots.Result.Count);
        }
    }
}
