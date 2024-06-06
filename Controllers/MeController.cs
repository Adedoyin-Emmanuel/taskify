using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using taskify.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;





namespace taskify.Controllers
{



    public class MeController(ILogger<MeController> logger, UserManager<User> userManager, SignInManager<User> signInManger, AppContext context) : Controller
    {

        private readonly ILogger<MeController> _logger = logger;
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManger;
        private readonly AppContext _context = context;




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
        [Authorize]
        public async Task<IActionResult> Edit()
        {

            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                await _signInManager.SignOutAsync();
                return Redirect("/auth/login");
            }

            var user = await _userManager.FindByIdAsync(userId);

            return View("Edit", user);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(MeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "There was an error updating your profile.";
                TempData["State"] = "error";

                return View("Edit", model);
            }

            var userId = _userManager.GetUserId(User);

            if (userId is null)
            {
                await _signInManager.SignOutAsync();
                return Redirect("/auth/login");
            }

            var user = await _userManager.FindByIdAsync(userId);

            user.Fullname = model.Fullname ?? user.Fullname;
            user.UserName = model.UserName ?? user.UserName;
            user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;


            await _context.SaveChangesAsync();


            TempData["Message"] = "Profile updated successfully";
            TempData["State"] = "success";


            return RedirectToAction("Index", "Me");
        }

    }
}