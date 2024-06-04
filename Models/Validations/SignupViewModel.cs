using System.ComponentModel.DataAnnotations;


namespace taskify.Models
{

    public class SignupViewModel
    {
        [Required(ErrorMessage = "Please enter your fullname")]
        public required string Fullname { get; set; }


        [Required(ErrorMessage = "Please enter your email"), EmailAddress]
        public required string Email { get; set; }


        [Required(ErrorMessage = "Please enter your password"), MaxLength(20, ErrorMessage = "Password can not be more than 20 characters"), MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public required string Password { get; set; }


        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public required string ConfirmPassword { get; set; }
    }
}