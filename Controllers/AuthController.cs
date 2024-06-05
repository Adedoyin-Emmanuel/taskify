using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using taskify.Models;


namespace taskify.Controllers
{

    public class AuthController(ILogger<AuthController> logger, UserManager<User> userManager, SignInManager<User> signInManager) : Controller
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManager;


        [HttpGet]
        public IActionResult Index()
        {
            return View("Login");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Message = "There was an error with your login.";
                model.State = "error";

                return View("Login", model);
            }


            model.Message = "Login successful";
            model.State = "success";


            Console.WriteLine($"{model.Email}, {model.Password}");
            return View("Login", model);

        }


        [HttpGet]
        public IActionResult Signup()
        {
            return View("Signup");
        }


        [HttpPost]
        public IActionResult Signup(SignupViewModel model)
        {



            if (!ModelState.IsValid)
            {

                model.Message = "There was an error with your signup.";
                model.State = "error";

                return View("Signup", model);
            }


            model.Message = "Signup successful.";
            model.State = "success";


            Console.WriteLine($"{model.Fullname}, {model.Email}, {model.Password}");

            return View("Signup", model);
        }


    }
}