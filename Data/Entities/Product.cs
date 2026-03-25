using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amrod_E_Commerce.Data.Entities
{
    public class Product
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        public string? Description { get; set; }
        public string? ImageURL { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
