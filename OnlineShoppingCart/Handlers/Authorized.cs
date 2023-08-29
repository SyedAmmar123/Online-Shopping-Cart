using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineShoppingCart.Data;

namespace OnlineShoppingCart.Handlers
{
    public class Authorized : ActionFilterAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
        private List<string> RolesList = new();
        private bool IsAuthenticated { get; set; } = false;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            RolesList = (Roles ?? "").Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var db = (AppDbContext)context.HttpContext.RequestServices.GetService(typeof(AppDbContext));
            var loggedInUser = db.GetLoggedInUser();
            if (loggedInUser != null)
            {
                if (RolesList.Any())
                {
                    //foreach (var requiredRole in RolesList)
                    //{
                    //    foreach (var userRole in db.LoggedInUser.Roles)
                    //    {
                    //        if (requiredRole == userRole)
                    //        {
                    //            IsAuthenticated = true;
                    //        }

                    //        if (IsAuthenticated) break;
                    //    }
                    //    if (IsAuthenticated) break;
                    //}

                    IsAuthenticated = RolesList.Any(rr => loggedInUser.Roles.Any(ur => rr == ur));
                }
                else
                {
                    IsAuthenticated = true;
                }
                // account status
                // some other check

            }

            if (!IsAuthenticated)
            {
                context.Result = new RedirectResult("~/Login");
            }
        }
    }
}
