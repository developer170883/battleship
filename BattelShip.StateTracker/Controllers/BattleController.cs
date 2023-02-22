using BattleShip.StateTracker.Api.Interface;
using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BattleShip.StateTracker.Api.Controllers
{

    [Route("api/v1/battle")]
    public class BattleController : ControllerBase
    {
        private readonly IBoardCreator boardCreator;
        private readonly IShipCreator shipCreator;
        private readonly IShipPlacer shipPlacer;
        private readonly IAttacker attacker;

        public BattleController(IBoardCreator boardCreator, IShipCreator shipCreator, IShipPlacer shipPlacer, IAttacker attacker)
        {
            this.boardCreator = boardCreator;
            this.shipCreator = shipCreator;
            this.shipPlacer = shipPlacer;
            this.attacker = attacker;
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<CreateBoardResponse>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ApiError<CreateBoardResponse>),(int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ApiError<CreateBoardResponse>), (int)HttpStatusCode.BadRequest)]
        public ApiResponse<CreateBoardResponse> CreateBoard([FromBody] CreateBoardRequest request)
        {
            if(!ModelState.IsValid)
            {
                return new ApiResponseBuilder<CreateBoardResponse>()
                .WithHttpStatus(Response, HttpStatusCode.BadRequest)
                .WithError(new Error(1000,"Invalid request data","Invalid request Data"))
                .Build();
            }

            var board = boardCreator.CreateBoard(request.Rows, request.Columns);
            return new ApiResponseBuilder<CreateBoardResponse>()
                .WithHttpStatus(Response, HttpStatusCode.Created)
                .WithData(new CreateBoardResponse { Columns = board.Columns, Rows = board.Rows })
                .Build();

        }


        [Route("place")]
        [HttpPost]
        [ProducesResponseType(typeof(ApiError<PlaceShipResponse>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ApiResponse<PlaceShipResponse>), (int)HttpStatusCode.OK)]

        public ApiResponse<PlaceShipResponse> PlaceShip([FromBody] PlaceShipRequest body)
        {

            if (!ModelState.IsValid)
            {
                return new ApiResponseBuilder<PlaceShipResponse>()
                .WithHttpStatus(Response, HttpStatusCode.BadRequest)
                .WithError(new Error(1001, "Invalid request data", "Invalid request Data"))
                .Build();
            }
            var board = boardCreator.CreateBoard(body.BoardRows, body.BoardColumns);

            //then create a ship
            var ship = shipCreator.CreateShip(body.BattleShipType);


            //now place the ship on the board
            shipPlacer.AddShipToBoard(ship, board, body.PlacementRow, body.PlacementColumn);

            return new ApiResponseBuilder<PlaceShipResponse>()
                .WithHttpStatus(Response, HttpStatusCode.Created)
                .WithData(new PlaceShipResponse { BoardColumns = board.Columns, BoardRows = board.Rows })
                .Build();

        }

        [Route("attack")]
        [HttpPost]

        [ProducesResponseType(typeof(ApiError<AttackResponse>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ApiResponse<AttackResponse>), (int)HttpStatusCode.OK)]
        public ApiResponse<AttackResponse> Attacker([FromBody] AttackRequest attack)
        {

            var board = boardCreator.CreateBoard(attack.BoardRows, attack.BoardColumns);

            //then create a ship
            var ship = shipCreator.CreateShip(attack.BattleShipType);

            //place the ship on the board
            shipPlacer.AddShipToBoard(ship, board, attack.PlacementRow, attack.PlacementColumn);


            //now attack the ship at the given position
            var result = attacker.Attack(board, attack.AttackRow, attack.AttackColumn);

            return new ApiResponseBuilder<AttackResponse>()
                .WithHttpStatus(Response, HttpStatusCode.Created)
                .WithData(new AttackResponse { AttackStatus = result })
                .Build();

        }
    }
}
