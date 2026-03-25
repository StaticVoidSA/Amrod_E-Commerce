using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amrod_E_Commerce.Data.Entities {
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid CartId { get; set; }

        public Cart? Cart { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        [Required]
        public int Quantity { get; set; } = 1;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // store price at the time of adding
    }
}