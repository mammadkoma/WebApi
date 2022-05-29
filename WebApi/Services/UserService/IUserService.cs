namespace WebApi.Services.UserService;

public interface IUserService
{
    Task Add(User user);
    Task<User> GetByUserName(string userName);
}
