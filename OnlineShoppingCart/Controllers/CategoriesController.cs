using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCart.Data;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string k)
        {
            //var data = _context.Categories
            //    //.Where(m => m.Name == k)
            //    //.Where(m => m.Name.StartsWith(k))
            //    //.Where(m => m.Name.EndsWith(k))
            //    //.Where(m => m.Name.Contains(k))
            //    //.Where(m => (m.Name.StartsWith(k) || m.Description.Contains(k)) && m.Status)
            //    //.Where(m => m.Name.StartsWith(k) || m.Description.Contains(k))
            //    //.Where(m => string.IsNullOrEmpty(k) || m.Name.StartsWith(k) || m.Description.Contains(k))
            //    .OrderByDescending(m => m.DbEntryTime).ToList();
            //return View(data);

            var categoryQuery = _context.Categories.AsQueryable();
            if (!string.IsNullOrWhiteSpace(k))
            {
                categoryQuery = categoryQuery.Where(m => m.Name.StartsWith(k) || m.Description.Contains(k));
            }
            ViewBag.searchUrl = "/Categories";
            ViewBag.searchKeyword = k;

            var data = categoryQuery.ToList();
            return View(data);
        }

        //[HttpGet]
        public IActionResult Create(bool iar)
        {
            if (iar)
            {
                Thread.Sleep(1500);
                return PartialView();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                if (model.Logo != null && model.Logo.Length > 0)
                {
                    string basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    string appPath = Path.Combine("images", "categories");
                    string fileName = Path.GetRandomFileName().Replace(".", "") + Path.GetExtension(model.Logo.FileName);
                    string directryPath = Path.Combine(basePath, appPath);
                    Directory.CreateDirectory(directryPath);

                    using var stream = new FileStream(Path.Combine(directryPath, fileName), FileMode.Create);
                    model.Logo.CopyTo(stream);
                    model.LogoUrl = Path.Combine(appPath, fileName).Replace("\\", "/");
                }
                //_context.Categories.Add(model);
                _context.Add(model);
                _context.SaveChanges();

                //return RedirectToAction("index");
                return RedirectToAction(nameof(Index));
            }

            //ModelState.AddModelError("Name", "Custom error");
            //ModelState.AddModelError("", "Custom error");
            return View(model);
        }

        public IActionResult Edit(string id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        //public IActionResult Edit(Category model)
        //{
        //    if (ModelState.IsValid)
        //    {


        //        _context.Update(model);
        //        _context.SaveChanges();

        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(model);
        //}
        public IActionResult Edit(Category model, IFormFile Logo)
        {
            if (ModelState.IsValid)
            {
                if (Logo != null && Logo.Length > 0)
                {
                    string fileName = Path.GetRandomFileName().Replace(".", "") + Path.GetExtension(Logo.FileName);
                    string basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    string appPath = Path.Combine("images", "categories");
                    string filePath = Path.Combine(basePath, appPath, fileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    Logo.CopyTo(stream);

                    // Update the LogoPath property of the category
                    model.LogoUrl = Path.Combine(appPath, fileName).Replace("\\", "/");
                }

                _context.Update(model);
                int r = _context.SaveChanges();

                if (r > 0 && Logo!= null)
                {
                    try
                    {
                        // Delete the old logo file, if applicable
                        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images","categories", model.LogoUrl));
                    }
                    catch (Exception)
                    {
                        // Handle deletion error if necessary
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(string id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            _context.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
