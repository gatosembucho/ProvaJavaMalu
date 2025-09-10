using ProvaJavaMalu.Entities;

namespace ProvaJavaMalu.UseCases.CreateTrip;

public class CreateTripUseCase(ProvaJavaMaluDbContext ctx)
{
    public async Task<Result<CreateTripResponse>> Do(CreateTripRequest request)
    {
        var trip = new Trip
        {
            Title = request.Title,
            Description = request.Description,
            UserID = request.OwnerID
        };
        ctx.Trips.Add(trip);
        await ctx.SaveChangesAsync();

        return Result<CreateTripResponse>.Success(new());
    }
}