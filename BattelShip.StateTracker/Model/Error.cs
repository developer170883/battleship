namespace BattleShip.StateTracker.Api.Model
{
    public class Error
    {

        public Error()
        {

        }
        public Error(int code, string message, string description)
        {
            Code = code;
            Message = message;
            Description = description;
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public string Description { get; set; }
    }
}
