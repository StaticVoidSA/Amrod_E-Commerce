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
        public string Name { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Guid? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
