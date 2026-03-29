using System.ComponentModel.DataAnnotations;

namespace Amrod_E_Commerce.Data.Entities
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        public User? User { get; set; }

        public List<CartItem> Items { get; set; } = new();

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}