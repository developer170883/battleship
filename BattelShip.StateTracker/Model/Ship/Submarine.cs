using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Model.Ship;
namespace BattleShip.API.Models.Ships
{
    public class Submarine : Ship
    {
        public Submarine()
        {
            Size = 3;
            BattleShipType = BattleShipType.Submarine;
        }
    }
}
