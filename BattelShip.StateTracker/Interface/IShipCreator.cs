
using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Model.Ship;

namespace BattleShip.StateTracker.Api.Interface
{
    public interface IShipCreator
    {
        Ship CreateShip(BattleShipType battleShip);
    }
}
