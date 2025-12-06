using EcommerceFixed.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceFixed.Models
{
    public class ProductVote
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public bool IsLike { get; set; } = true; // true = like, false = dislike

        public DateTime DateVoted { get; set; } = DateTime.UtcNow;
    }
}