namespace API.Controllers;

[Authorize]
public class UserController(IUserRepository repo, IMapper mapper) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        return Ok(await repo.GetMembersAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MemberDto>> GetUser(int id)
    {
        var user = await repo.GetUserByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(mapper.Map<MemberDto>(user));
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUserByUsername(string username)
    {
        var user = await repo.GetMemberByUsernameAsync(username);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
    {
        var username = User.FindFirst(ClaimTypes.Name)?.Value;

        if (username == null)
            return BadRequest("No username found in token");

        var user = await repo.GetUserByUsernameAsync(username);

        if (user == null) return BadRequest("Could not find user");

        mapper.Map(memberUpdateDto, user);

        if (await repo.SaveAllAsync()) return NoContent();

        return BadRequest("Failed to update the user");
    }
}