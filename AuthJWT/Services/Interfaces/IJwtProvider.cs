namespace AuthJWT.Services.Interfaces;

public interface IJwtProvider
{
    string CreateJwtToken(User user);
}
