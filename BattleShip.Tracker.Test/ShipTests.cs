
using BattleShip.StateTracker.Api.Implementation;
using BattleShip.StateTracker.Api.Model;
using Xunit;

namespace BattleShip.Test
{
    public class ShipTests
    {
        [Theory]
        [InlineData(BattleShipType.Carrier)]
        public void ShouldReturnShip_WhenShipCreated(BattleShipType shipType)
        {
            //arrange
            var shipCreator = new ShipCreator();

            //act
            var ship = shipCreator.CreateShip(shipType);

            //assert
            Assert.NotNull(ship);
        }
    }
}
