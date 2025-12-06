using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Data;
using EcommerceFixed.Helpers;
using EcommerceFixed.Models;

namespace EcommerceFixed.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> Productos { get; set; } = new();
        public int HombreCount { get; set; }
        public int MujerCount { get; set; }
        public int UnisexCount { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                // Obtener productos destacados INCLUYENDO las relaciones necesarias
                Productos = await _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Reviews)  // ? INCLUIR REVIEWS para que AverageRating funcione
                    .Include(p => p.Votes)    // ? INCLUIR VOTES para que LikeCount funcione
                    .Where(p => p.IsFeatured && p.Quantity > 0)
                    .OrderByDescending(x => x.DateCreated)
                    .Take(8)
                    .ToListAsync();

                // Contar productos por género
                HombreCount = await _context.Products
                    .Where(p => p.Gender == "Hombre" && p.Quantity > 0)
                    .CountAsync();

                MujerCount = await _context.Products
                    .Where(p => p.Gender == "Mujer" && p.Quantity > 0)
                    .CountAsync();

                UnisexCount = await _context.Products
                    .Where(p => p.Gender == "Unisex" && p.Quantity > 0)
                    .CountAsync();
            }
        }

        // ? ELIMINAMOS los métodos GetProductAverageRating y GetProductReviewCount
        // porque YA EXISTEN en el modelo Product como propiedades [NotMapped]

        // Método para obtener reseñas destacadas
        public List<ProductReview> GetFeaturedReviews()
        {
            return _context.ProductReviews?
                .Include(r => r.Product)
                .Include(r => r.User)
                .Where(r => r.Rating >= 4 && !string.IsNullOrEmpty(r.Comment))
                .OrderByDescending(r => r.Rating)
                .ThenByDescending(r => r.DateCreated)
                .Take(3)
                .ToList() ?? new List<ProductReview>();
        }

        public IActionResult OnPostAgregarAlCarrito(int productoId)
        {
            if (!User.Identity?.IsAuthenticated ?? false)
            {
                TempData["error"] = "Debes iniciar sesión para agregar productos al carrito.";
                return RedirectToPage("/Account/Login");
            }

            var producto = _context.Products.FirstOrDefault(x => x.Id == productoId);
            if (producto == null)
            {
                TempData["error"] = "Producto no encontrado.";
                return RedirectToPage("/Index");
            }

            if (producto.Quantity == 0)
            {
                TempData["error"] = $"{producto.Name} está agotado.";
                return RedirectToPage("/Index");
            }

            try
            {
                CartHelper.AddToCartDb(producto, _context, User);
                TempData["success"] = $"{producto.Name} se añadió al carrito correctamente.";
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Error al agregar al carrito: {ex.Message}";
            }

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostAgregarAFavoritos(int productoId)
        {
            if (!User.Identity?.IsAuthenticated ?? false)
            {
                TempData["error"] = "Debes iniciar sesión para agregar productos a favoritos.";
                return RedirectToPage("/Account/Login");
            }

            var producto = _context.Products.FirstOrDefault(x => x.Id == productoId);
            if (producto == null)
            {
                TempData["error"] = "Producto no encontrado.";
                return RedirectToPage("/Index");
            }

            try
            {
                WishlistHelper.AddToWishlist(producto, _context, User);
                TempData["success"] = $"{producto.Name} se añadió a tu lista de deseos.";
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Error al agregar a favoritos: {ex.Message}";
            }

            return RedirectToPage("/Index");
        }
    }
}