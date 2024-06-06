using System.ComponentModel.DataAnnotations;



namespace taskify.Models
{


    public class MeViewModel
    {

        [Required(ErrorMessage = "Please enter your username")]
        public required string Username { get; set; }


        [Required(ErrorMessage = "Please enter your fullname")]
        public required string Fullname { get; set; }


        [Required(ErrorMessage = "Please enter your phone number")]
        public required string PhoneNumber { get; set; }


    }
}