using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart.Models
{
    public class OrderDetail : ShareModel
    {
        [Required]
        public string OrderId { get; set; }

        // Navigation property for the order to which this detail belongs
        public Order Order { get; set; }

        [Required]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int QuantityDemanded { get; set; }
        public int? QuantitySent { get; set; }

        // Additional relevant details
    }
}
