using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using taskify.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;





namespace taskify.Controllers
{



    public class MeController(ILogger<MeController> logger, UserManager<User> userManager, SignInManager<User> signInManger) : Controller
    {

        private readonly ILogger<MeController> _logger = logger;
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManger;




        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                await _signInManager.SignOutAsync();
                return Redirect("/auth/login");
            }

            var user = await _userManager.FindByIdAsync(userId);

            return View(user);
        }



        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View("Edit");
        }


        [HttpPost]
        public async Task<IActionResult> Edit(MeViewModel model)
        {
            return View("Edit");
        }

    }
}