using System.ComponentModel.DataAnnotations;


namespace taskify.Models
{

    public class SignupViewModel
    {
        [Required(ErrorMessage = "Please enter your fullname")]
        public required string Fullname { get; set; }


        [Required(ErrorMessage = "Please enter your email"), EmailAddress]
        public required string Email { get; set; }


        [Required(ErrorMessage = "Please enter your password")]
        public required string Password { get; set; }


    }
}