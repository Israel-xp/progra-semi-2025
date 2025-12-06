using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EcommerceFixed.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Column(TypeName = "varchar(500)")]
        public string Desc { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string SKU { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public int? Discount { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Column(TypeName = "varchar(500)")]
        public string ImageLocation { get; set; }

        // Relación con Categoría
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public bool IsFeatured { get; set; } = false;

        // ========================================================================
        // 🧠 CAMPOS PARA EL CHATBOT E INTELIGENCIA ARTIFICIAL
        // ========================================================================

        [Column(TypeName = "varchar(10)")]
        public string Gender { get; set; } = "Unisex";

        // Estilo: "Casual", "Formal", "Gótico", "Aesthetic", "Old Money", etc.
        [Column(TypeName = "varchar(50)")]
        public string Style { get; set; } = "Casual";

        [Column(TypeName = "varchar(50)")]
        public string Season { get; set; } = "Todo el año";

        [Column(TypeName = "varchar(50)")]
        public string Occasion { get; set; } = "Diario";

        [Column(TypeName = "varchar(100)")]
        public string Color { get; set; } = "Negro";

        [Column(TypeName = "varchar(50)")]
        public string Size { get; set; } = "M";

        [Column(TypeName = "varchar(100)")]
        public string Material { get; set; } = "Algodón";

        // CRÍTICO: Tipo de prenda ("Camiseta", "Pantalón", "Zapatos")
        [Column(TypeName = "varchar(50)")]
        public string ClothingType { get; set; } = "Camiseta";

        // CRÍTICO: Tags para búsqueda semántica (ej: "dark, metal, noche, calavera")
        [Column(TypeName = "varchar(MAX)")]
        public string Tags { get; set; } = "";

        // Nivel de formalidad (1-5)
        public int FormalityLevel { get; set; } = 3;

        // Rango de temperatura ideal
        public double MinTemperature { get; set; } = 15;
        public double MaxTemperature { get; set; } = 30;

        // Compatibilidad: IDs o nombres de prendas que combinan
        [Column(TypeName = "varchar(500)")]
        public string CompatibleWith { get; set; } = "";

        // Relaciones existentes
        public virtual ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();
        public virtual ICollection<ProductVote> Votes { get; set; } = new List<ProductVote>();

        // ========================================================================
        // 🛠️ PROPIEDADES NO MAPEADAS (Helpers)
        // ========================================================================

        #region Not included in EF migrations

        [NotMapped]
        public decimal PriceAfterDiscount
        {
            get => Price - Price * Convert.ToDecimal($"0.{Discount ?? 0}");
        }

        [NotMapped]
        public int CartQuantity { get; set; }

        [NotMapped]
        public bool IsOutOfStock => Quantity == 0;

        [NotMapped]
        public bool HasDiscount => (Discount ?? 0) > 0;

        [NotMapped]
        public double AverageRating => Reviews?.Any() == true ? Reviews.Average(r => r.Rating) : 0.0;

        [NotMapped]
        public int LikeCount => Votes?.Count(v => v.IsLike) ?? 0;

        [NotMapped]
        public int DislikeCount => Votes?.Count(v => !v.IsLike) ?? 0;

        [NotMapped]
        public bool IsPopular => LikeCount >= 10;

        // Convierte el string de Tags en una lista lista para usar (CORREGIDO AQUI)
        [NotMapped]
        public List<string> TagList => string.IsNullOrEmpty(Tags)
            ? new List<string>()
            : Tags.Split(',').Select(t => t.Trim().ToLower()).ToList();

        [NotMapped]
        public List<string> CompatibleWithList => string.IsNullOrEmpty(CompatibleWith)
            ? new List<string>()
            : CompatibleWith.Split(',').Select(t => t.Trim()).ToList();

        // ✅ MÉTODO DE INTELIGENCIA: Detecta si el producto coincide con un estilo o palabra
        public bool MatchesVibe(string searchVibe)
        {
            if (string.IsNullOrEmpty(searchVibe)) return false;
            string search = searchVibe.ToLower();

            // Busca coincidencia en Estilo, Tags, Color o Nombre
            return (Style?.ToLower().Contains(search) ?? false) ||
                   (Tags?.ToLower().Contains(search) ?? false) ||
                   (Color?.ToLower().Contains(search) ?? false) ||
                   (Name?.ToLower().Contains(search) ?? false);
        }
      
        public string AvailableSizes { get; set; } = "S,M,L";

        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();

        #endregion
    }
}