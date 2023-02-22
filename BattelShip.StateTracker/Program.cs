using BattleShip.StateTracker.Api.Implementation;
using BattleShip.StateTracker.Api.Interface;
using BattleShip.StateTracker.Api.Middleware;
using System.Text.Json.Serialization;
using System.Text.Json;
using FluentValidation.AspNetCore;
using FluentValidation;
using BattleShip.StateTracker.Api.Model;
using BattleShip.StateTracker.Api.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(jsonOptions =>
    {
        var enumAsStringConverter = new JsonStringEnumConverter();
        jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        jsonOptions.JsonSerializerOptions.Converters.Add(enumAsStringConverter);
    }); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBoardCreator, BoardCreator>();
builder.Services.AddScoped<IShipCreator, ShipCreator>();
builder.Services.AddScoped<IShipPlacer, ShipPlacer>();

builder.Services.AddScoped<IAttacker, Attacker>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddTransient<IValidator<CreateBoardRequest>, CreateBoardRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
