using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Models;

namespace EcommerceFixed.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserCart> UserCarts { get; set; }
        public DbSet<UserWishlist> UserWishlists { get; set; }
        public DbSet<Order> Orders { get; set; }

        // NUEVOS DbSets
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductVote> ProductVotes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuración para el modelo ProductReview
            builder.Entity<ProductReview>(entity =>
            {
                entity.HasOne(pr => pr.Product)
                      .WithMany(p => p.Reviews)
                      .HasForeignKey(pr => pr.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pr => pr.User)
                      .WithMany(u => u.ProductReviews)
                      .HasForeignKey(pr => pr.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración para el modelo ProductVote
            builder.Entity<ProductVote>(entity =>
            {
                entity.HasKey(pv => pv.Id);

                entity.HasOne(pv => pv.Product)
                      .WithMany(p => p.Votes)
                      .HasForeignKey(pv => pv.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pv => pv.User)
                      .WithMany(u => u.ProductVotes)
                      .HasForeignKey(pv => pv.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Un usuario solo puede votar una vez por producto
                entity.HasIndex(pv => new { pv.ProductId, pv.UserId }).IsUnique();
            });

            // Configuración para UserCart
            builder.Entity<UserCart>(entity =>
            {
                entity.HasKey(uc => uc.UserId);
            });

            // Configuración para UserWishlist
            builder.Entity<UserWishlist>(entity =>
            {
                entity.HasKey(uw => uw.UserId);
            });

            // Configuración para ApplicationUser - CORREGIDO
            builder.Entity<ApplicationUser>(entity =>
            {
                // ✅ CORREGIDO: Eliminada referencia a FullName que ya no existe
                // En su lugar, configuramos las propiedades que SÍ existen

                entity.Property(u => u.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(u => u.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(u => u.ProfilePicture)
                    .HasMaxLength(500);

                entity.Property(u => u.ShippingAddress)
                    .HasMaxLength(500);

                entity.Property(u => u.City)
                    .HasMaxLength(100);

                entity.Property(u => u.State)
                    .HasMaxLength(100);

                entity.Property(u => u.PostalCode)
                    .HasMaxLength(20);

                // Índices para mejor rendimiento
                entity.HasIndex(u => u.Email).IsUnique();
                entity.HasIndex(u => u.UserName).IsUnique();
            });

            // Configuración para Product - AGREGAR campos del chatbot
            builder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Style)
                    .HasMaxLength(50)
                    .HasDefaultValue("Casual");

                entity.Property(p => p.Season)
                    .HasMaxLength(50)
                    .HasDefaultValue("Todo el año");

                entity.Property(p => p.Occasion)
                    .HasMaxLength(50)
                    .HasDefaultValue("Diario");

                entity.Property(p => p.Color)
                    .HasMaxLength(100)
                    .HasDefaultValue("Negro");

                entity.Property(p => p.Size)
                    .HasMaxLength(50)
                    .HasDefaultValue("M");

                entity.Property(p => p.Material)
                    .HasMaxLength(100)
                    .HasDefaultValue("Algodón");

                entity.Property(p => p.ClothingType)
                    .HasMaxLength(50)
                    .HasDefaultValue("Camiseta");

                entity.Property(p => p.Tags)
                    .HasMaxLength(500);

                entity.Property(p => p.CompatibleWith)
                    .HasMaxLength(500);

                entity.Property(p => p.FormalityLevel)
                    .HasDefaultValue(3);

                entity.Property(p => p.MinTemperature)
                    .HasDefaultValue(15);

                entity.Property(p => p.MaxTemperature)
                    .HasDefaultValue(30);
            });
        }
    }
}