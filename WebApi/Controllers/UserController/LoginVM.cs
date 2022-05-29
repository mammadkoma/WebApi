namespace WebApi.Controllers.UserController;

public class LoginVM
{
    [Display(Name = "یوزر نیم")]
    [Required(ErrorMessage = Constants.RequireMsg)]
    [MaxLength(50, ErrorMessage = Constants.MaxLengthMsg)]
    [RegularExpression("[A-Za-z0-9][A-Za-z0-9._]{2,50}", ErrorMessage = Constants.UserNameMsg)]
    public string UserName { get; set; }

    [Display(Name = "پسورد")]
    [Required(ErrorMessage = Constants.RequireMsg)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = Constants.PasswordMsg)]
    public string Password { get; set; }
}