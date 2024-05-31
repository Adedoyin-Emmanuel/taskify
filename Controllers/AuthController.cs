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

        public IActionResult Index()
        {
            return View("Login");
        }


        public IActionResult Login()
        {
            return View("Login");
        }


        public IActionResult Signup()
        {
            return View("Signup");
        }


    }
}