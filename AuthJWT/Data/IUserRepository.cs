namespace AuthJWT.Data;

public interface IUserRepository
{
    bool SaveChanges();
    User GetUserByEmail(string email);
    User CreateUser(User user);
    bool UserWithEmailExists(string email);
}
