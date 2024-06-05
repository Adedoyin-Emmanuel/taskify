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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Message = "There was an error with your login.";
                model.State = "error";

                return View("Login", model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);


            if (result.Succeeded)
            {
                TempData["Message"] = "Login successful";
                TempData["State"] = "success";

                return RedirectToAction("Index", "Todo");
            }
            else
            {

                model.Message = "Login failed";
                model.State = "error";

                return View("Login", model);
            }

        }


        [HttpGet]
        public IActionResult Signup()
        {
            return View("Signup");
        }


        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel model)
        {
            var lastError = "";

            if (!ModelState.IsValid)
            {

                model.Message = "There was an error with your signup.";
                model.State = "error";

                return View("Signup", model);
            }


            var user = new User { UserName = model.Email, Email = model.Email, Fullname = model.Fullname, };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                model.State = "success";
                model.Message = "Signup successful.";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                    ModelState.AddModelError(string.Empty, error.Description);
                    lastError = error.Description;
                }

                model.State = "error";
                model.Message = lastError.Length > 0 ? lastError : "There was an error with your signup.";

                return View("Signup", model);
            }

        }


    }
}