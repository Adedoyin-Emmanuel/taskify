using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using taskify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace taskify.Controllers
{

    public class TodoController(ILogger<TodoController> logger, UserManager<User> userManager, SignInManager<User> signInManager, AppContext context) : Controller
    {

        private readonly ILogger<TodoController> _logger = logger;
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManager;
        private readonly AppContext _context = context;



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
            if (!ModelState.IsValid)
            {

                model.Message = "There was an error with your signup.";
                model.State = "error";

                return View("Signup", model);
            }
            var user = await _userManager.GetUserAsync(User);
            var userId = user != null ? await _userManager.GetUserIdAsync(user) : null;



            var todo = new Todo
            {
                Title = model.Title,
                Description = model.Description,
                IsDone = model.IsDone,
                UserId = userId ?? throw new ArgumentNullException(nameof(userId)),
            };


            var result = await _context.Todo.AddAsync(todo);

            if (result != null)
            {
                int saveResult = await _context.SaveChangesAsync();

                if (saveResult > 0)
                {
                    TempData["Message"] = "Todo created successfully.";
                    TempData["State"] = "success";
                    return RedirectToAction("Index", "Todo");
                }
            }


            TempData["Message"] = "An error occured while saving todo";
            TempData["State"] = "error";

            return View(todo);

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