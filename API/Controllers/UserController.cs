namespace API.Controllers;

[Authorize]
public class UserController(IUserRepository repo, IMapper mapper) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return Ok(await repo.GetMembersAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await repo.GetUserByIdAsync(id);

        if (user == null)
            return NotFound();

        var userToReturn = mapper.Map<MemberDto>(user);
        return Ok(userToReturn);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<AppUser>> GetUser(string username)
    {
        var user = await repo.GetMemberByUsernameAsync(username);

        if (user == null)
            return NotFound();

        return Ok(user);
    }
}