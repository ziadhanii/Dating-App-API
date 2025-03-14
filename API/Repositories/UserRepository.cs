namespace API.Repositories;

public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
{
    public async Task<MemberDto?> GetMemberByUsernameAsync(string username) => await
        context.Users
            .Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();


    public async Task<IEnumerable<MemberDto>> GetMembersAsync() => await
        context.Users
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .ToListAsync();


    public async Task<AppUser?> GetUserByIdAsync(int id) => await context.Users.FindAsync(id);


    public async Task<AppUser?> GetUserByUsernameAsync(string username) => await
        context.Users
            .Include(x => x.Photos)
            .SingleOrDefaultAsync(x => x.UserName == username);


    public async Task<IEnumerable<AppUser>> GetUsersAsync() => await
        context.Users
            .Include(x => x.Photos)
            .ToListAsync();


    public async Task<bool> SaveAllAsync() => await context.SaveChangesAsync() > 0;


    public void Update(AppUser user) => context.Entry(user).State = EntityState.Modified;
}