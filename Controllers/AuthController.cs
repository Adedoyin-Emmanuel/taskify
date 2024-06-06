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
                TempData["Message"] = "There was an error with your login.";
                TempData["State"] = "error";

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

                TempData["Message"] = "Login failed";
                TempData["State"] = "error";

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

                TempData["Message"] = "There was an error with your signup.";
                TempData["State"] = "error";

                return View("Signup", model);
            }


            var user = new User { UserName = model.Email, Email = model.Email, Fullname = model.Fullname, };
            var result = await _userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                TempData["State"] = "success";
                TempData["Message"] = "Signup successful.";

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

                TempData["State"] = "error";
                TempData["Message"] = lastError.Length > 0 ? lastError : "There was an error with your signup.";

                return View("Signup", model);
            }

        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            TempData["Message"] = "Logout successful";
            TempData["State"] = "success";

            return RedirectToAction("Index", "Auth");
        }


    }
}