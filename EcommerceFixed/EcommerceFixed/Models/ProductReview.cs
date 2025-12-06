using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceFixed.Models
{
    public class ProductReview
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Calificación")]
        [Range(1, 5, ErrorMessage = "La calificación debe ser entre 1 y 5 estrellas")]
        public int Rating { get; set; } = 5;

        [Required]
        [Display(Name = "Comentario")]
        [MaxLength(1000, ErrorMessage = "El comentario no puede exceder 1000 caracteres")]
        public string Comment { get; set; }

        [Display(Name = "Imagen del Comentario")]
        public string? ReviewImage { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Display(Name = "Fecha de Modificación")]
        public DateTime? DateModified { get; set; }

        // Propiedades calculadas - CORREGIDO
        [NotMapped]
        public string UserDisplayName => User != null
            ? $"{User.FirstName} {User.LastName}".Trim()
            : User?.UserName ?? "Usuario Anónimo";
    }
}