using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models
{
    public class AppUser : ShareModel
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public string EncryptedPassword { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        // Navigation property for roles
        public List<AppRole> Roles { get; set; }

        // Navigation property for shopping cart
        public ShoppingCart ShoppingCart { get; set; }

        // Additional identification details
    }

    public class AppUserViewModel : ShareModel
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
