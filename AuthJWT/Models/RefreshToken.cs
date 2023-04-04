namespace AuthJWT.Models;

public class RefreshToken
{
    [Key]
    [Required]
    public int Id { get;set; }

    public string Token { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ExpiresAt { get; set; }
}
