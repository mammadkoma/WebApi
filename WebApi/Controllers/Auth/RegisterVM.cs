namespace WebApi.Controllers.Auth;

public class RegisterVM
{
    [Display(Name = "یوزر نیم")]
    [Required(ErrorMessage = Constants.RequireMsg)]
    [StringLength(maximumLength: 50, ErrorMessage = Constants.MaxLengthMsg)]
    public string UserName { get; set; }

    [Display(Name = "پسورد")]
    [Required(ErrorMessage = Constants.RequireMsg)]
    [StringLength(maximumLength: 20, ErrorMessage = Constants.MaxLengthMsg)]
    public string Password { get; set; }

    [Display(Name = "نام")]
    [StringLength(maximumLength: 50, ErrorMessage = Constants.MaxLengthMsg)]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [StringLength(maximumLength: 50, ErrorMessage = Constants.MaxLengthMsg)]
    public string LastName { get; set; }

    [Display(Name = "موبایل")]
    [StringLength(maximumLength: 11, ErrorMessage = Constants.MaxLengthMsg)]
    public string Mobile { get; set; }

    [Display(Name = "ایمیل")]
    [StringLength(maximumLength: 50, ErrorMessage = Constants.MaxLengthMsg)]
    [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = Constants.RegularExpressionMsg)]
    public string Email { get; set; }
}