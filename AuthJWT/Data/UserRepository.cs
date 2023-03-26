namespace AuthJWT.Data;

public class UserRepository : IUserRepository
{
    private readonly IdentityDbContext _context;

    public UserRepository(IdentityDbContext context) 
        => _context = context;

    public User CreateUser(User user)
    {
        if(user is null) throw new ArgumentNullException(nameof(user));

        _context.Users.Add(user);
        return user;
    }

    public bool UserWithEmailExists(string email)
    {
        return _context.Users.Any(u => u.Email == email);
    }

    public bool SaveChanges() 
        => _context.SaveChanges() >= 0;

    public User GetUserByEmail(string email)
        => _context.Users.FirstOrDefault(u => u.Email == email);
}
