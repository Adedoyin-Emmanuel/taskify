using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using taskify.Models;

namespace taskify.Controllers
{

    class TodoController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}