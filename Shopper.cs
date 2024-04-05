using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WpfApp
{
    internal class Shopper
    {
        [Key] // Specifies this property as the primary key
        public int IdShopper { get; set; }

        [Required] // Specifies that the Email property is required
        [StringLength(50)] // Specifies the maximum length of the Email property
        public string Email { get; set; }

        [StringLength(15)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(40)]
        public string Address { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        public string StateProvince { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [StringLength(15)]
        public string ZipCode { get; set; }

        // Navigation property (relationship)
        public ICollection<Basket> Baskets { get; set; }
    }
}

