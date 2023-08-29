using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart.Models
{
    public class Order :ShareModel
    {
        [Required]
        public string UserId { get; set; }

        // Navigation property for the user who placed this order
        public AppUser User { get; set; }

        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "The ShippingAddress field is required.")]
        [StringLength(500)]
        public string ShippingAddress { get; set; }
        public string ContactNumber { get; set; }   
        public string EmailAddress { get; set; }




        public List<OrderDetail> Details { get; set; }
    }
}
