using Microsoft.EntityFrameworkCore;
using ProvaJavaMalu.Entities;
using ProvaJavaMalu.Services.JWT;

namespace ProvaJavaMalu.UseCases.Login;

public class LoginUseCase(
    ProvaJavaMaluDbContext ctx,
    IJWTService jWTService
)
{
    public async Task<Result<LoginResponse>> Do(LoginRequest request)
    {
        var user = await ctx.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user is null)
            return Result<LoginResponse>
            .Fail("User not found!");

        var jwt = jWTService.CreateToken(new(
            user.ID, user.Username
        ));

        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}