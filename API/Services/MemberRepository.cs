namespace API.Services;

public class MemberRepository(AppDbContext context) : IMemberRepository
{
    public async Task<IReadOnlyList<Member>> GetMembersAsync() => await context.Members.ToListAsync();

    public async Task<Member?> GetMemberByIdAsync(string id) => await context.Members.FindAsync(id);

    public async Task<IReadOnlyList<Photo>> GetPhotosForMemberAsync(string memberId)
        => await context
            .Members
            .Where(x => x.Id == memberId)
            .SelectMany(x => x.Photos)
            .ToListAsync();

    public void Update(Member member) => context.Entry(member).State = EntityState.Modified;

    public async Task<bool> SaveAllAsync() => await context.SaveChangesAsync() > 0;
}