using System.ComponentModel.DataAnnotations;

namespace Amrod_E_Commerce.Data.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
