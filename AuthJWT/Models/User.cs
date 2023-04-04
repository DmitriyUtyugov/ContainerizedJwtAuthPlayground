namespace AuthJWT.Models;

public class User
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public DateTime RegistrationDate { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    public int DeviceId { get; set; }

    public RefreshToken RefreshToken { get; set; }
}
