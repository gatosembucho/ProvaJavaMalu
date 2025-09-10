using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProvaJava.EndPoints;
using ProvaJavaMalu.EndPoints;
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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.ConfigureAuthEndpoints();
app.ConfigureTripEndPoints();


app.Run();