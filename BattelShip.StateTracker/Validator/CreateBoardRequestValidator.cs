using BattleShip.StateTracker.Api.Model;
using FluentValidation;

namespace BattleShip.StateTracker.Api.Validator
{
    public class CreateBoardRequestValidator: AbstractValidator<CreateBoardRequest>
    {
        public CreateBoardRequestValidator()
        {
            RuleFor(r => r.Columns)
              .GreaterThan(0);

            RuleFor(r => r.Rows)
              .GreaterThan(0);
        }
    }

    public class PlaceShipRequestValidator: AbstractValidator<PlaceShipRequest>
    {
        public PlaceShipRequestValidator()
        {
            RuleFor(x=>x.BoardRows)
                 .GreaterThan(0);
            RuleFor(x => x.BoardColumns)
              .GreaterThan(0);

            RuleFor(x=>x.PlacementRow)
                .LessThan(x=>x.BoardRows);
            RuleFor(x => x.PlacementColumn)
               .LessThan(x => x.BoardColumns);

        }
    }
}
