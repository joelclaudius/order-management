using System.ComponentModel.DataAnnotations;

namespace WpfApp
{
    internal class Product
    {
        [Key] // Specifies this property as the primary key
        public int IdProduct { get; set; }

        [Required] // Specifies that the ProductName property is required
        [StringLength(50)] // Specifies the maximum length of the ProductName property
        public string ProductName { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)] // Specifies that the Price property must be non-negative
        public decimal Price { get; set; }
    }
}
