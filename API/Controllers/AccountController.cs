namespace API.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        // if (await UserExists(registerDto.UserName))
        //     return BadRequest("Username is taken");
        //
        // using var hmac = new HMACSHA512();
        // var user = new AppUser
        // {
        //     UserName = registerDto.UserName.ToLower(),
        //     PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        //     PasswordSalt = hmac.Key
        // };
        // context.Add(user);
        // await context.SaveChangesAsync();
        //
        // return new UserDto
        // {
        //     UserName = user.UserName,
        //     Token = await tokenService.CreateToken(user)
        // };
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

        if (user == null)
            return Unauthorized("Invalid username");

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i])
                return Unauthorized("Invalid password");
        }

        return new UserDto
        {
            UserName = user.UserName,
            Token = await tokenService.CreateToken(user)
        };
    }

    private async Task<bool> UserExists(string username) =>
        await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
}