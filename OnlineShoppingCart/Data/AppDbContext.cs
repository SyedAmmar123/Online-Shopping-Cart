using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Data
{
    public class AppDbContext : DbContext
    {
        //private  IHttpContextAccessor _contextAccessor;
        public IHttpContextAccessor HttpContextAccessor { get; }
        private AppUserViewModel LoggedInUser { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor contextAccessor)
            : base(options)
        {
            //_contextAccessor = contextAccessor;
            //ProcesLogin();
            HttpContextAccessor = contextAccessor;

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }

        public AppUserViewModel GetLoggedInUser(/*IHttpContextAccessor httpContextAccessor = null*/)
        {
            if(LoggedInUser !=null) return LoggedInUser;
            //HttpContextAccessor ??= httpContextAccessor;
            //var userId = HttpContextAccessor.HttpContext.Session.GetString(GlobalConfig.LoginSessionName);
           var Token = HttpContextAccessor.HttpContext.Request.Cookies[GlobalConfig.LoginCookieName]?.ToString();
            if(string.IsNullOrEmpty(Token) )
            {
                Token = HttpContextAccessor.HttpContext.Request.Headers[GlobalConfig.LoginCookieName].ToString();
            }
            if (!string.IsNullOrEmpty(Token))
            {
                var loginHistory = LoginHistory.Where(m => m.Token == Token).FirstOrDefault();
                if (loginHistory == null || loginHistory.ValidTill < DateTime.Now)
                {
                    HttpContextAccessor.HttpContext.Response.Cookies.Delete(GlobalConfig.LoginCookieName, new CookieOptions
                    {
                        IsEssential = true, 
                    });
                    return null;
                }
                var user = LoginHistory.Where(m => m.Token == Token).Select(m => m.User)
                    .Select(m => new AppUserViewModel 
                    {
                        Id = m.Id,
                        DbEntryTime = m.DbEntryTime,
                        Email = m.Email,
                        Name = m.Name,
                        Roles = m.Roles.Select(n => n.Name).ToList()
                    }).FirstOrDefault();

                LoggedInUser = user;
                return LoggedInUser;
            }
            return null;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(m => m.Brand).WithMany().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().HasOne(m => m.Category).WithMany().OnDelete(DeleteBehavior.Cascade);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
