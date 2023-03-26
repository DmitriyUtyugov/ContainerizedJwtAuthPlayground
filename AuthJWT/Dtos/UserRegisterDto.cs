namespace AuthJWT.Dtos;

public class UserRegisterDto
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
