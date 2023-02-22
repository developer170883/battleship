using BattleShip.StateTracker.Api.Model.Board;

namespace BattleShip.StateTracker.Api.Interface
{
    public interface IBoardCreator
    {
        Board CreateBoard(int rows, int columns);
    }
}
