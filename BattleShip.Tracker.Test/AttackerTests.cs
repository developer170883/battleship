using BattleShip.StateTracker.Api.Implementation;
using BattleShip.StateTracker.Api.Model;
using Xunit;

namespace BattleShip.Test
{
    public class AttackerTests
    {
        [Theory]
        [InlineData(10, 10, 0, 0, 0, 0, BattleShipType.Carrier, BoardCellStatus.Hit)]
        [InlineData(10, 10, 0, 0, 0, 1, BattleShipType.Carrier, BoardCellStatus.Hit)]
        [InlineData(10, 10, 0, 0, 0, 2, BattleShipType.Carrier, BoardCellStatus.Hit)]
        [InlineData(10, 10, 0, 0, 0, 3, BattleShipType.Carrier, BoardCellStatus.Hit)]
        [InlineData(10, 10, 0, 0, 0, 4, BattleShipType.Carrier, BoardCellStatus.Hit)]
        [InlineData(10, 10, 0, 0, 5, 5, BattleShipType.Carrier, BoardCellStatus.Miss)]
        [InlineData(10, 10, 0, 0, 0, 5, BattleShipType.Carrier, BoardCellStatus.Miss)]
        [InlineData(10, 10, 0, 0, 3, 8, BattleShipType.Carrier, BoardCellStatus.Miss)]
        public void ShouldReturnCorrectAttackStatus_WhenAttackLaunched(
            int boardRows, int boardColumns,
            int placementRow, int placementColumn,
            int attackRow, int attackColumn,
            BattleShipType shipType, BoardCellStatus boardCellStatus)
        {
            //arrange

            //first create a board
            var boardCreator = new BoardCreator();
            var board = boardCreator.CreateBoard(boardRows, boardColumns);

            //then create a ship
            var shipCreator = new ShipCreator();
            var ship = shipCreator.CreateShip(shipType);

            //place the ship on the board
            var shipPlacer = new ShipPlacer();
            shipPlacer.AddShipToBoard(ship, board, placementRow, placementColumn);

            //act
            //now attack the ship at the given position
            var attacker = new Attacker();
            attacker.Attack(board, attackRow, attackColumn);

            //assert
            /*check that the status on the board is hit*/
            Assert.True(
                board.BoardCellStatuses[attackRow, attackColumn] == boardCellStatus
            );
        }


        [Theory]
        [InlineData(10, 10, 0, 0, 11, 11, BattleShipType.Carrier)]
        [InlineData(10, 10, 0, 0, 17, 15, BattleShipType.Carrier)]
        public void ShouldReturnException_WhenIncorrectAttackCoordinatesProvided(
           int boardRows, int boardColumns,
           int placementRow, int placementColumn,
           int attackRow, int attackColumn,
           BattleShipType shipType)
        {
            //arrange

            //first create a board
            var boardCreator = new BoardCreator();
            var board = boardCreator.CreateBoard(boardRows, boardColumns);

            //then create a ship
            var shipCreator = new ShipCreator();
            var ship = shipCreator.CreateShip(shipType);

            //place the ship on the board
            var shipPlacer = new ShipPlacer();
            shipPlacer.AddShipToBoard(ship, board, placementRow, placementColumn);

            //act
            //now attack the ship at the given position
            var attacker = new Attacker();
            IndexOutOfRangeException ex = Assert.Throws<IndexOutOfRangeException>(() =>
                attacker.Attack(board, attackRow, attackColumn));

            //assert
            Assert.Equal("Attack position is out of bounds", ex.Message);
        }
    }
}
