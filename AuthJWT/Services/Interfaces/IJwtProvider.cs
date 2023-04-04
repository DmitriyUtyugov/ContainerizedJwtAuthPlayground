using AuthJWT.Models;

namespace AuthJWT.Services.Interfaces;

public interface IJwtProvider
{
    string CreateAccessToken(User user);
    RefreshToken CreateRefreshToken();
}
