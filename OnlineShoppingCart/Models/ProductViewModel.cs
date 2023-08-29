using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
