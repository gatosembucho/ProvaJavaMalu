using Microsoft.EntityFrameworkCore;
using ProvaJavaMalu.Entities;

namespace ProvaJavaMalu.UseCases.EditTrip;

public class EditTripUseCase(ProvaJavaMaluDbContext ctx)
{
    public async Task<Result<EditTripResponse>> Do(EditTripRequest request)
    {
        var IDOwner = request.OwnerID;

        var trip = await ctx.Trips.FirstOrDefaultAsync(
           t => t.ID == request.TripID
        );
        if (trip.UserID != IDOwner)
            return Result<EditTripResponse>.Fail("Voce não pode acessar esse passeio");


        ctx.Add(IDOwner);
        await ctx.SaveChangesAsync();

        return Result<EditTripResponse>.Success(new());
    }
}