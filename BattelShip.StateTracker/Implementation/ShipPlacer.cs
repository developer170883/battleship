using BattleShip.StateTracker.Api.Interface;
using BattleShip.StateTracker.Api.Model.Board;
using BattleShip.StateTracker.Api.Model.Ship;

namespace BattleShip.StateTracker.Api.Implementation
{
    public class ShipPlacer : IShipPlacer
    {
        public void AddShipToBoard(Ship ship, Board board, int row, int column)
        {
            Validate(ship, board, row, column);

            for (int i = 0; i < ship.Size; i++)
            {
                //for each ship coordinate, update cell status to occupied
                board.BoardCellStatuses[row, column + i] = Model.BoardCellStatus.Occupied;

                board.OccupationCount++;
            }
        }
        private void Validate(Ship ship, Board board, int row, int column)
        {
            var errorMessage = "Ship's placement position is out of bounds";

            //validate if starting positions in bounds of the board
            if (row > board.Rows)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }

            if (column > board.Columns)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }

            for (var c = 0; c < ship.Size; c++)
            {
                if (column + c > board.Columns)
                {
                    throw new IndexOutOfRangeException(errorMessage);
                }
            }
        }
    }
}
