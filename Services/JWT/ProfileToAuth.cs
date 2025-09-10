namespace ProvaJavaMalu.Services.JWT;
public record ProfileToAuth(
    Guid UserId,
    string Username
);