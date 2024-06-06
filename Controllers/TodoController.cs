using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using taskify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;



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
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var userTodos = await _context.Todo.Where(todo => todo.UserId == user.Id).ToListAsync();

                return View("Index", userTodos);


            }

            return View();
        }



        [HttpGet]
        [Authorize]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost]

        public async Task<IActionResult> New(CreateTodoViewModel model)
        {
            if (!ModelState.IsValid)
            {

                TempData["Message"] = "There was an error creating your todo.";
                TempData["State"] = "error";

                return View("Todo", model);
            }
            var user = await _userManager.GetUserAsync(User);
            var userId = user != null ? await _userManager.GetUserIdAsync(user) : null;



            var todo = new Todo
            {
                Title = model.Title,
                Description = model.Description,
                IsDone = model.IsDone,
                UserId = Guid.Parse(userId ?? throw new ArgumentNullException(nameof(userId))),
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
            var todo = await _context.Todo.FindAsync(id);

            return View("Edit", todo);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTodoViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "An error occurred while updating todo";
                TempData["State"] = "error";
            }

            var todo = await _context.Todo.FindAsync(model.Id);

            if (todo is not null)
            {
                todo.Title = model.Title ?? todo.Title;
                todo.Description = model.Description ?? todo.Description;
                todo.IsDone = model.IsDone;
            }

            await _context.SaveChangesAsync();

            TempData["Message"] = "Todo updated successfully";
            TempData["State"] = "success";

            return RedirectToAction("Index", "Todo");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var todo = await _context.Todo.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

            if (todo is not null)
            {
                _context.Todo.Remove(todo);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Todo deleted successfully";
                TempData["State"] = "success";

                return RedirectToAction("Index", "Todo");

            }

            TempData["Message"] = "An error occurred while deleting todo";
            TempData["State"] = "error";

            return RedirectToAction("Edit", "Todo");
        }



    }
}