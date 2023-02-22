using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Model.Board;

namespace BattleShip.StateTracker.Api.Interface
{
    public interface IAttacker
    {
        AttackStatus Attack(Board board, int row, int column);
    }
}
