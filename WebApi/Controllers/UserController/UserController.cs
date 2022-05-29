namespace WebApi.Controllers.UserController;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        var user = new User
        {
            UserName = model.UserName,
            PasswordHash = PasswordHash.HashPassword(model.Password),
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            Email = model.Email,
        };
        await _userService.Add(user);
        return StatusCode(201, user.Id);
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginVM model)
    {
        var user = await _userService.GetByUserName(model.UserName);

        if (user is null || !PasswordHash.VerifyPassword(model.Password, user.PasswordHash))
            throw new Exception("یوزرنیم یا پسورد اشتباه است.");

        return Ok();
    }
}