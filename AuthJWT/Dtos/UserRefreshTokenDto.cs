namespace AuthJWT.Dtos;

public class UserRefreshTokenDto
{
    public string Email { get; set; }
    public RefreshToken RefreshToken { get; set; }
}
