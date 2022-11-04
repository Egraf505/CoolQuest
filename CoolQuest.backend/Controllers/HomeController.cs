using CoolQuest.backend.Models;
using CoolQuest.DbContext.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoolQuest.backend.Controllers
{
    public class HomeController : Controller
    {

        private readonly CoolQuestContex _db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CoolQuestContex contex)
        {
            _logger = logger;
            _db = contex;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Users.Count());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}