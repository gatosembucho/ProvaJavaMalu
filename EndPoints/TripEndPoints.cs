using Microsoft.AspNetCore.Mvc;
using ProvaJavaMalu.UseCases.CreateTrip;
using ProvaJavaMalu.UseCases.ViewTrip;
using ProvaJavaMalu.UseCases.EditTrip;
using System.Security.Claims;

namespace ProvaJavaMalu.EndPoints;

public static class TripEndPoints
{
    public static void ConfigureTripEndPoints(this WebApplication app)
    {
        app.MapPost("trip", async (
            [FromBody] CreateTripRequest request,
            [FromServices] CreateTripUseCase useCase) =>
            {
                var result = await useCase.Do(request);
                if (result.IsSuccess)
                    return Results.Created();
                return Results.BadRequest(result.Reason);

            });

        app.MapPost("trip/newpoint", async (
            [FromBody] EditTripRequest request,
            [FromServices] EditTripUseCase useCase) =>
            {
                var result = await useCase.Do(request);
                if (result.IsSuccess)
                    return Results.Created();
                return Results.BadRequest(result.Reason);

            });
        app.MapGet("trip/{userId}/", async (
          HttpContext http,
          int TripID,
          [FromBody] ViewTripRequest request,
          [FromServices] ViewTripUseCase useCase) =>
          {
              var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
              if (claim is null)
                  return Results.Unauthorized();
              var userId = Guid.Parse(claim.Value);
              var result = await useCase.Do(request)
              if (result.IsSuccess)
                    return Results.Created();
                return Results.BadRequest(result.Reason)
              ;      
          });
    }
}