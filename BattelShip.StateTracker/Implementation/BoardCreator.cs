using BattleShip.StateTracker.Api.Interface;
using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Model.Board;

namespace BattleShip.StateTracker.Api.Implementation
{
    public class BoardCreator : IBoardCreator
    {
        public Board CreateBoard(int rows, int columns)
        {
            BoardCellStatus[,] statusArray = new BoardCellStatus[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    statusArray[row, column] = BoardCellStatus.Unoccupied;
                }
            }

            //return the board
            return new Board
            {
                BoardCellStatuses = statusArray,
                Rows = rows,
                Columns = columns
            };
        }
    }
}
