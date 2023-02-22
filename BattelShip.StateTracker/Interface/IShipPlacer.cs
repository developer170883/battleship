using BattleShip.StateTracker.Api.Model.Board;
using BattleShip.StateTracker.Api.Model.Ship;

namespace BattleShip.StateTracker.Api.Interface
{
    public interface IShipPlacer
    {
        void AddShipToBoard(Ship ship, Board board, int row, int column);
    }
}
