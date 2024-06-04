using System.ComponentModel.DataAnnotations;



namespace taskify.Models
{


    public class LoginViewModel
    {

        [Required(ErrorMessage = "Please enter your email")]
        public required string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password")]
        public required string Password { get; set; }
    }
}