﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models
{
    public class CartItem:ShareModel
    {
        [Required]
        public string ShoppingCartId { get; set; }

        // Navigation property for the shopping cart to which this item belongs
        public ShoppingCart ShoppingCart { get; set; }

        [Required]
        [ForeignKey("Product")]
        public string ProductId { get; set; }

        // Navigation property for the product in this cart item
        public Product Product { get; set; }

        public int Quantity { get; set; }

        // Additional relevant details for the cart item
    }
}
