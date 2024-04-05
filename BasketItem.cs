using System.ComponentModel.DataAnnotations;

namespace WpfApp
{
    internal class BasketItem
    {
        [Key] // Specifies this property as the primary key
        public int IdBasketItem { get; set; }

        [Required] // Specifies that the IdProduct property is required
        public int IdProduct { get; set; } // Foreign key

        [Required] // Specifies that the Quantity property is required
        public byte Quantity { get; set; }

        [Required] // Specifies that the IdBasket property is required
        public int IdBasket { get; set; } // Foreign key

        // Navigation properties (relationships)
        public Product Product { get; set; } // Represents the associated Product
        public Basket Basket { get; set; } // Represents the associated Basket
    }
}
