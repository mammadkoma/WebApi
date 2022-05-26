namespace WebApi.Services.UserService;

public class UserService : IUserService
{
    private readonly AppDbContext _appDbContext;

    public UserService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }


    public async Task Add(User user)
    {
        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.UserRoles.AddAsync(new UserRole
        {
            User = user,
            RoleId = 2, // 1:Admin 2:Customer
        });
        await _appDbContext.SaveChangesAsync();
    }
}