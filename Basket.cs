using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WpfApp
{
    internal class Basket
    {
        [Key] // Specifies this property as the primary key
        public int IdBasket { get; set; }

        [Required] // Specifies that the IdShopper property is required
        public int IdShopper { get; set; } // Foreign key

        [Required] // Specifies that the Quantity property is required
        public byte Quantity { get; set; }

        [Required] // Specifies that the SubTotal property is required
        public decimal SubTotal { get; set; }

        [Required] // Specifies that the OrderDate property is required
        public DateTime OrderDate { get; set; }

        // Navigation property (relationship)
        public Shopper Shopper { get; set; } // Represents the associated Shopper
        public ICollection<BasketItem> BasketItems { get; set; } // Represents the collection of BasketItems associated with this Basket
    }
}

