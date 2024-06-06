using System.ComponentModel.DataAnnotations;



namespace taskify.Models
{


    public class MeViewModel
    {


        [Required(ErrorMessage = "Please enter your user id")]
        public required Guid Id { get; set; }


        [Required(ErrorMessage = "Please enter your email"), EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public required String Email { get; set; }


        [Required(ErrorMessage = "Please enter your username"), MinLength(3), MaxLength(20)]
        public required string UserName { get; set; }


        [Required(ErrorMessage = "Please enter your fullname")]
        public required string Fullname { get; set; }


        [Required(ErrorMessage = "Please enter your phone number")]
        public required string PhoneNumber { get; set; }


    }
}