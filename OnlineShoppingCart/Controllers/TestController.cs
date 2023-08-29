using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace OnlineShoppingCart.Controllers
{
    public class TestController : Controller
    {

        public IActionResult Vue()
        {
            return View();
        }

        public IActionResult Vue2()
        {
            return View();
        }
        public IActionResult OneTech()
        {
            return View();
        }

        public IActionResult Pullux()
        {
            return View();
        }
        
        public IActionResult ThemeOneTech()
        {
            return View();
        }
        

        public IActionResult ThemePullux()
        {
            return View();
        }

        public IActionResult ExtensionMethods()
        {
            string obj = "some data in string";
            //obj = string.Join(" ", obj.Split(' ').Select(m => m[..1].ToUpper() + m[1..]));
            // CultureInfo.CurrentCulture.TextInfo.ToTitleCase(obj);
            // abc-def-ghi
            obj = obj = obj.ToTitleCase();
            obj.WordCount('-');
            //obj.AlphaNumeric();
            return View();
        }
    }
}
