using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Model.Ship;
namespace BattleShip.API.Models.Ships
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            Size = 4;
            BattleShipType = BattleShipType.Battleship;
        }
    }
}
