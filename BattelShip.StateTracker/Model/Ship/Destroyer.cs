using BattleShip.StateTracker.Api.Model.Ship;

namespace BattleShip.API.Models.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Size = 2;
            BattleShipType = StateTracker.Api.Model.BattleShipType.Destroyer;
        }
    }
}
