using System.ComponentModel.DataAnnotations;



namespace taskify.Models
{


    public class TodoViewModel : BaseModel
    {



        [Required(ErrorMessage = "Please enter todo title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Please enter todo description")]

        public required string Description { get; set; }

        [Required(ErrorMessage = "Please enter todo status")]

        public required bool IsDone { get; set; }


    }
}