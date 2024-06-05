using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using taskify.Models;
using System.Threading.Tasks;





namespace taskify.Controllers
{



    public class MeController(ILogger<MeController> logger, UserManager<User> userManager, SignInManager<User> signInManger) : Controller
    {

        private readonly ILogger<MeController> _logger = logger;
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManger;




        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
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