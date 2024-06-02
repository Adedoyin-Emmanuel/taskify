using System.ComponentModel.DataAnnotations;



namespace taskify.Models
{


    public class LoginViewModel
    {

        [Required(ErrorMessage = "Please enter your email")]
        public required string Email { get; set; }


        [Required(ErrorMessage = "Please enter your email address")]
        public required string Password { get; set; }
    }
}