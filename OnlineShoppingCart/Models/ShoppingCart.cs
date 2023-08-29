using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart.Models
{
    public class ShoppingCart
    {
        [Key]
        public string Id { get; set; } = Path.GetRandomFileName().Replace(".", "");

        [Required]
        public string UserId { get; set; }

        // Navigation property for the user associated with this shopping cart
        public AppUser User { get; set; }

        // Navigation property for the cart items
        public List<CartItem> CartItems { get; set; }
    }
}
