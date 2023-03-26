namespace AuthJWT.Data;

public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
