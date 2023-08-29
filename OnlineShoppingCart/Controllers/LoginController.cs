using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCart.Data;
using OnlineShoppingCart.Handlers;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            var user = _context.Users.Where(m => m.Email == model.Email).FirstOrDefault();
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email address not exists");
                return View(model);
            }

            if ((user.Id + model.Password).Encrypt() == user.EncryptedPassword)
            {
                LoginHistory loginHistory = new()
                {
                    ClientInfo = _context.HttpContextAccessor.HttpContext.Request.Headers["user-Agent"].ToString(),
                    IPAddress = _context.HttpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                    UserId = user.Id,
                    ValidTill = model.RememberMe ? DateTime.Now.AddDays(7) : DateTime.Now.AddMinutes(20)

                };

                _context.Add(loginHistory);
                _context.SaveChanges();


                //HttpContext.Session.SetString(GlobalConfig.LoginSessionName, user.Id);
                //var id = HttpContent.Session.GetString(GlobalConfig.LoginSessionName);
                HttpContext.Response.Cookies.Append(GlobalConfig.LoginCookieName, loginHistory.Token, new CookieOptions
                {
                    IsEssential = true,
                    Expires = loginHistory.ValidTill,
                    //HttpOnly = true
                });
                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError("Password", "Invalid password");
            return View(model);
        }

        public IActionResult Logout()
        {
            //HttpContext.Session.SetString("UN", null);
            HttpContext.Session.Remove("UN");
            return RedirectToAction("Index", "Home");
        }

        
       
    }
}
