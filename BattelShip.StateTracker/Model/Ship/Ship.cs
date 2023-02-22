namespace BattleShip.StateTracker.Api.Model.Ship
{
    public abstract class Ship
    {
        public BattleShipType BattleShipType { get; set; }
        public int Size { get; set; }
    }
}
