using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Utils;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BattleShip.StateTracker.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ErrorHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (IndexOutOfRangeException ex)
            {
                var errorResponse = new ApiResponseBuilder<string>()
              .WithError(new Error
              {

                  Code = 1001,
                  Description = ex.Message,
                  Message = ex.Message
              })
              .WithHttpStatus(context.Response, System.Net.HttpStatusCode.BadRequest).Build();

                var errorJson = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });

                await context.Response.WriteAsync(errorJson);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseBuilder<string>()
               .WithError(new Error
               {

                   Code = 10000,
                   Description = _env.IsProduction() ? "Unhandled error" : ex.ToString(),
                   Message = "Unhandled error"
               })
               .WithHttpStatus(context.Response, System.Net.HttpStatusCode.InternalServerError).Build();

                var errorJson = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });

                await context.Response.WriteAsync(errorJson);
            }
        }
    }
}
