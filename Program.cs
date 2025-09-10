using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProvaJavaMalu.Entities;
using ProvaJavaMalu.Services.JWT;
using ProvaJavaMalu.UseCases.CreateTrip;
using ProvaJavaMalu.UseCases.EditTrip;
using ProvaJavaMalu.UseCases.Login;
using ProvaJavaMalu.UseCases.ViewTrip;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProvaJavaMaluDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

builder.Services.AddTransient<IJWTService, JWTService>();

builder.Services.AddTransient<CreateTripUseCase>();
builder.Services.AddTransient<EditTripUseCase>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<ViewTripUseCase>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(Options =>
    {
        Options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "ProvaJavaMalu",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,

            IssuerSigningKey = key,
        };
    });

var app = builder.Build();



app.Run();

internal class JwtBearerDefaults
{
}