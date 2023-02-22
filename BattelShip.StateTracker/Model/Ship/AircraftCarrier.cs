using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Model.Ship;
namespace BattleShip.API.Models.Ships
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Size = 5;
            BattleShipType = BattleShipType.Carrier;
        }
    }
}
