using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using taskify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace taskify.Controllers
{

    public class TodoController(ILogger<TodoController> logger, UserManager<User> userManager, SignInManager<User> signInManager) : Controller
    {

        private readonly ILogger<TodoController> _logger = logger;
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManager;



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost]
        public async Task<IActionResult> New(TodoViewModel model)
        {
            return View("New");
        }




        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            return View("Edit");
        }




        [HttpPost]
        public async Task<IActionResult> Edit(TodoViewModel model)
        {
            return View("Edit");
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return View("Delete");
        }



    }
}