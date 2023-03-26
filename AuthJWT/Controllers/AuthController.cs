using AuthJWT.Services.Interfaces;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthJWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public AuthController(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    [HttpPost("register")]
    public ActionResult<User> RegisterUser(UserRegisterDto userRegisterDto)
    {
        bool userAlredyExists = _userRepository.UserWithEmailExists(userRegisterDto.Email);

        if (userAlredyExists is false)
        {
            var user = new User()
            {
                Username = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                RegistrationDate = DateTime.UtcNow,
                PasswordHash = HashPassword(userRegisterDto.Password),
                DeviceId = Random.Shared.Next(0, int.MaxValue) //random android device id
            };

            _userRepository.CreateUser(user);
            _userRepository.SaveChanges();

            return Ok(user);
        }

        return BadRequest("Failed to create user");
    }

    [HttpPost("login")]
    public ActionResult<string> LogInUser(UserLoginDto userLoginDto)
    {
        var userExists = _userRepository.UserWithEmailExists(userLoginDto.Email);
        var user = _userRepository.GetUserByEmail(userLoginDto.Email);
        var passwordValidationSuccessfull = BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.PasswordHash);

        if(userExists is false || passwordValidationSuccessfull is false)
        {
            return BadRequest("Login or password is incorrect");
        }

        var jwtToken = _jwtProvider.CreateJwtToken(user);

        return Ok(jwtToken);
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}
