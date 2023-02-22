using BattleShip.StateTracker.Api.Implementation;
using Xunit;

namespace BattleShip.Test
{
    public class BoardTests
    {
        //this test creates a board and tests if a valid board was created
        [Theory]
        //rows, columns
        [InlineData(10, 10)]
        [InlineData(20, 20)]
        public void ShouldReturnValidBoard_WhenBoardCreated(int rows, int columns)
        {
            //arrange
            var boardCreator = new BoardCreator();

            //act
            var board = boardCreator.CreateBoard(rows, columns);

            //assert
            Assert.Equal(rows * columns, board.BoardCellStatuses.Length);
        }
    }
}
