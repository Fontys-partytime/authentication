using AuthenticationWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Partytime.Common.JwtAuthentication;
using Partytime.Party.Service.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
}); ;

builder.Services.AddDbContext<UseraccountContext>(opt =>
    opt
    .UseNpgsql(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"), providerOptions => providerOptions.EnableRetryOnFailure())
    .UseSnakeCaseNamingConvention());
builder.Services.AddScoped<IUseraccountRepository, UserRepository>();

builder.Services.AddSingleton<JwtTokenHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
