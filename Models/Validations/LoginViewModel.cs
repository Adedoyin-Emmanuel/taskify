using System.ComponentModel.DataAnnotations;



namespace taskify.Models
{


    public class LoginViewModel : BaseModel
    {

        [Required(ErrorMessage = "Please enter your email")]
        public required string Email { get; set; }


        [MaxLength(20, ErrorMessage = "Password cannot be more than 20 characters"), MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password")]
        public required string Password { get; set; }
    }
}