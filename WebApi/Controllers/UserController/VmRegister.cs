namespace WebApi.Controllers.UserController;

public class VmRegister
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

    [Display(Name = "نام")]
    [MaxLength(50, ErrorMessage = Constants.MaxLengthMsg)]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [MaxLength(50, ErrorMessage = Constants.MaxLengthMsg)]
    public string LastName { get; set; }

    [Display(Name = "موبایل")]
    [RegularExpression("09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = Constants.MobileMsg)]
    public string Mobile { get; set; }

    [Display(Name = "ایمیل")]
    [MaxLength(50, ErrorMessage = Constants.MaxLengthMsg)]
    [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = Constants.RegularExpressionMsg)]
    public string Email { get; set; }
}
