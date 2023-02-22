using BattleShip.StateTracker.Api.Model;

namespace BattleShip.StateTracker.Api.Utils
{
    public class ApiResponseBuilder<T>
    {
        private readonly ApiResponse<T> _apiResponse;

        public ApiResponse<T> Build() => _apiResponse;

        public ApiResponseBuilder()
        {
            _apiResponse = new ApiResponse<T>();
        }

        public ApiResponseBuilder<T> WithData(T data)
        {
            _apiResponse.Data = data;
            return this;
        }

        public ApiResponseBuilder<T> WithError(Error error)
        {
            if (_apiResponse.Errors == null)
            {
                _apiResponse.Errors = new List<Error>();
            }

            _apiResponse.Errors.Add(error);

            return this;
        }

        public ApiResponseBuilder<T> WithErrors(IEnumerable<Error> errors)
        {
            if (_apiResponse.Errors == null)
            {
                _apiResponse.Errors = new List<Error>();
            }

            foreach (var error in errors)
            {
                _apiResponse.Errors.Add(error);
            }

            return this;
        }

        public ApiResponseBuilder<T> WithHttpStatus(Microsoft.AspNetCore.Http.HttpResponse response, System.Net.HttpStatusCode statusCode)
        {
            response.StatusCode = (int)statusCode;
            return this;
        }


    }
}
