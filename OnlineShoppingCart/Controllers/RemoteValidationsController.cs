using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCart.Data;
using OnlineShoppingCart.Models;
using System.Net.Http.Headers;

namespace OnlineShoppingCart.Controllers
{
    public class RemoteValidationsController : Controller
    {
        private readonly AppDbContext _context;

        public RemoteValidationsController(AppDbContext context)
        {
            _context = context;
        }

        //public IActionResult CategoryNameCheck(Category category)
        //{
        //    var isExisting = _context.Categories.Where(m => m.Id != category.Id && m.Name.Trim() == category.Name.Trim()).Any();
        //    return Json(!isExisting);
        //}

        public IActionResult CategoryNameCheck(Category category)
        {
            if (!string.IsNullOrEmpty(category.Id))
            {
                var result = !_context.Categories.Any(m => m.Id != category.Id && m.Name == category.Name);
                return Json(result);
            }
            else
            {
                //"".Replace(" ", "");
                //string.Join("", "".Where(m => m != ' '));
                var names = _context.Categories.Select(m => m.Name).ToList();
                names.ForEach(m => m = string.Join("", m.Where(c => char.IsLetterOrDigit(c))));
                category.Name = string.Join("", category.Name.Where(c => char.IsLetterOrDigit(c)));

                var result = !names.Any(m => m.ToLower() == category.Name.ToLower());
                return Json(result);
            }
        }
    }
}
