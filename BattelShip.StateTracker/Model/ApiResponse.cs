namespace BattleShip.StateTracker.Api.Model
{
    public class ApiResponse<T>: ApiError<T>
    {
        public T Data { get; set; }

        //public IList<Error> Errors { get; set; }
    }

    public class ApiError<T>
    {
        public IList<Error> Errors { get; set; }
    }
}
