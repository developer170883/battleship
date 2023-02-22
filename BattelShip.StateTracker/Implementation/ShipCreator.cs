using BattleShip.API.Models.Ships;
using BattleShip.StateTracker.Api.Interface;
using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Model.Ship;


namespace BattleShip.StateTracker.Api.Implementation
{
    public class ShipCreator : IShipCreator
    {
        public Ship CreateShip(BattleShipType shipType)
        {

            switch (shipType)
            {
                case BattleShipType.Battleship:
                    return new Battleship();

                case BattleShipType.Destroyer:
                    return new Destroyer();
                case BattleShipType.Cruiser:
                    return new Cruiser();
                case BattleShipType.Submarine:
                    return new Submarine();

                case BattleShipType.Carrier:
                    return new Carrier();


                default:// Keep Default
                    return new Carrier();
            }

        }
    }
}
