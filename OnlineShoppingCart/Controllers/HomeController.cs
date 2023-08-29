using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCart.Models;
using System.Diagnostics;

namespace OnlineShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var userName = HttpContext.Session.GetString("UN");
            //if(string.IsNullOrEmpty(userName)) return RedirectToAction("Index", "Login");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AdminBody()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Error2()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}