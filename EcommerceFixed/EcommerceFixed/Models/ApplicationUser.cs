using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceFixed.Models
{
    public class ApplicationUser : IdentityUser
    {
        // ✅ PROPIEDADES BÁSICAS PARA EL REGISTRO/LOGIN
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")]
        [Display(Name = "Apellido")]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        // ❌ ELIMINADA: Propiedad FullName completamente
        // En tu código, usa $"{user.FirstName} {user.LastName}" directamente

        // ✅ PROPIEDADES DE PERFIL (OPCIONALES)
        [Display(Name = "Foto de Perfil")]
        public string? ProfilePicture { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [PersonalData]
        public DateTime? DateOfBirth { get; set; }

        // ✅ INFORMACIÓN DE DIRECCIÓN (OPCIONAL)
        public string? ShippingAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        // ✅ INFORMACIÓN DE LA CUENTA
        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; } = true;

        // ✅ PROPIEDADES DE PREFERENCIAS
        public bool ReceiveEmailNotifications { get; set; } = true;
        public bool ReceiveSpecialOffers { get; set; } = true;

        // ✅ PROPIEDADES DE NAVEGACIÓN
        public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
        public virtual ICollection<ProductVote> ProductVotes { get; set; } = new List<ProductVote>();

        // ✅ MÉTODO PARA ACTUALIZAR ÚLTIMO LOGIN
        public void UpdateLastLogin()
        {
            LastLogin = DateTime.UtcNow;
        }

        // ✅ MÉTODO QUE FALTABA (ahora vacío)
        public void UpdateFullName()
        {
            // Vacío - ya no se usa
        }

        // ✅ MÉTODO DE CONVENIENCIA para obtener nombre completo
        [NotMapped]
        public string DisplayName => $"{FirstName} {LastName}".Trim();
    }
}