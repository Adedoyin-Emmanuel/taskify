using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using taskify.Models;


namespace taskify.Controllers
{

    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;



        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

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


        [HttpGet]
        public IActionResult Signup()
        {
            return View("Signup");
        }


        [HttpPost]
        public IActionResult Signup(SignupViewModel model)
        {

            Console.WriteLine(model);

            if (!ModelState.IsValid)
            {
                return View("Signup", model);
            }

            Console.WriteLine(HttpContext.Request.Form["Fullname"]);
            Console.WriteLine(HttpContext.Request.Form["Email"]);
            Console.WriteLine(HttpContext.Request.Form["Password"]);


            Console.WriteLine("This is seperate ---------");



            Console.WriteLine($"{model.Fullname}, {model.Email}, {model.Password}");

            return View("Signup");
        }


    }
}