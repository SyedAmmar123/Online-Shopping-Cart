using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models
{
    public class Category : ShareModel
    {
        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(100)]
        [Display(Name = "Category Name")]
        [Remote("CategoryNameCheck", "RemoteValidations", AdditionalFields = "Id", ErrorMessage = "Name already exists")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Description must be 5 to 500 Character")]
        public string Description { get; set; }

        public bool Status { get; set; }

        [NotMapped]
        public IFormFile Logo { get; set; }

        [StringLength(200)]
        public string LogoUrl { get; set; }

        public List<Product> Products { get; set; }
        // Additional relevant details

        public CategoryType Type { get; set; }
    }

    public enum CategoryType
    {
        Category = 0,
        Brand = 10,
        Blogs = 20
    }
}
