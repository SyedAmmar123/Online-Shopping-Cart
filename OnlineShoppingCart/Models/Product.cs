using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models
{
    public class Product : ShareModel
    {
        public Product()
        {
            Images = new();
        }
        [Required(ErrorMessage = "The Slug field is required.")]
        [StringLength(150)]
        [RegularExpression("^[a-z0-9-]{1,150}$", ErrorMessage = "The Slug must contain only lowercase alphabets, numerics, and hyphens.")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price must be greater than 0.")]
        public decimal Price { get; set; }

        [ForeignKey("Brand")]
        public string BrandId { get; set; }
        public virtual Category Brand { get; set; }

        [Required(ErrorMessage = "The Stock field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The Stock must be a non-negative number.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "The ReleaseDate field is required.")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "The CategoryId field is required.")]

        [ForeignKey("Category")]
        public string CategoryId { get; set; }

        // Navigation property for the category to which this product belongs
        //[ForeignKey("CategoryId")]
        public Category Category { get; set; }

        // Navigation property for cart items containing this product
        public List<CartItem> CartItems { get; set; }

        // Navigation property for order details containing this product
        public List<OrderDetail> OrderDetails { get; set; }
        public virtual List<ProductImage> Images { get; set; }

        [NotMapped]
        public List<IFormFile> Uploads { get; set; }
        // Additional relevant details for the product

        //public List<string> DeletedImagesIds { get; set; }
    }

    public class ProductImage : ShareModel
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string URL { get; set; }
        public int Rank { get; set; }
    }
}
