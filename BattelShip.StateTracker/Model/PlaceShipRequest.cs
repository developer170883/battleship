namespace BattleShip.StateTracker.Api.Model
{
    public class PlaceShipRequest
    {
        public int BoardRows { get; set; }
        public int BoardColumns { get; set; }
        public int PlacementRow { get; set; }
        public int PlacementColumn { get; set; }
        public BattleShipType BattleShipType { get; set; }
    }
}
