namespace BattleShip.StateTracker.Api.Model
{
    public class CreateBoardRequest
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
    }

    public class CreateBoardResponse
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
    }
}
