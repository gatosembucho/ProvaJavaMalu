using Microsoft.EntityFrameworkCore;
using ProvaJavaMalu.Entities;

namespace ProvaJavaMalu.UseCases.ViewTrip;

public class ViewTrip(ProvaJavaMaluDbContext ctx)
{
     public async Task<Result<ViewTripResponse>> Do(ViewTripRequest request)
    {
       var room = await ctx.Trips.Where(
                n => n.Title == request.Title
            ).ToListAsync();

        return Result<ViewTripResponse>.Success(null);
    }
}