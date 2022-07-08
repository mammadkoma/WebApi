namespace WebApi.Services.UserService;

public class UserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext appDbContext)
    {
        _db = appDbContext;
    }


    public async Task Add(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.UserRoles.AddAsync(new UserRole
        {
            User = user,
            RoleId = 2, // 1:Admin 2:Customer
        });
        await _db.SaveChangesAsync();
    }

    public async Task<User> GetByUserName(string userName)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);
    }
}