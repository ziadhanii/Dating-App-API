namespace API.Controllers;

public class MembersController(AppDbContext context) : BaseApiController
{
    [HttpGet("")]
    [AllowAnonymous]
    public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
    {
        return Ok(await context.Users.ToListAsync());
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetMember(string id)
    {
        var member = await context.Users.FindAsync(id);

        if (member == null)
            return NotFound();

        return Ok(member);
    }
}