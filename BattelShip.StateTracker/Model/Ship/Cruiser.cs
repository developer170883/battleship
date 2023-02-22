using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Model.Ship;
namespace BattleShip.API.Models.Ships
{
    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Size = 3;
            BattleShipType = BattleShipType.Cruiser;
        }
    }
}
