using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;



namespace taskify.Models
{


    public class CreateTodoViewModel
    {



        [Required(ErrorMessage = "Please enter todo title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Please enter todo description")]
        public required string Description { get; set; }
        public required bool IsDone { get; set; }

    }



    public class UpdateTodoViewModel
    {


        public Guid Id { get; set; }
        public string ?Title { get; set; }
        public  string ?Description { get; set; }
        public  bool IsDone { get; set; }

    }
}