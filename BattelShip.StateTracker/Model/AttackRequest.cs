namespace BattleShip.StateTracker.Api.Model
{
    public class AttackRequest
    {
        public int BoardRows { get; set; }
        public int BoardColumns { get; set; }
        public int PlacementRow { get; set; }
        public int PlacementColumn { get; set; }
        public int AttackRow { get; set; }
        public int AttackColumn { get; set; }
        public BattleShipType BattleShipType { get; set; }
        public BoardCellStatus BoardCellStatus { get; set; }
    }
}
