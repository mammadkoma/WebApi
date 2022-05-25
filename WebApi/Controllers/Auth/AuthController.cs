namespace WebApi.Controllers.Auth;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        var user = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.Email,
            Email = model.Email
        };
        //await _userManager.CreateAsync(user, model.Password);
        //await _userManager.AddToRoleAsync(user, "user");
        return StatusCode(201);
    }
}