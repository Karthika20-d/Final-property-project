

using System.ComponentModel.DataAnnotations;

namespace OnlineRealEstate.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter your mail")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter valid mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [RegularExpression("^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*s).*$", ErrorMessage = "Please enter valid password like uppercase,lowecase,symbol and number")]
        [MinLength(8, ErrorMessage = "Password should atleast contain 8 characters")]
        public string Password { get; set; }
    }
}