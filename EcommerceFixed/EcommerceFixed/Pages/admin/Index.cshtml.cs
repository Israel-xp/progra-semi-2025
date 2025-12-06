using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using EcommerceFixed.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerceFixed.Pages.admin
{
    // ? IMPORTANTE: Protegemos la página para que solo entre el Admin
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- PROPIEDADES PARA LAS TARJETAS DEL DASHBOARD ---
        public int ProductsCount { get; set; }
        public int CategoriesCount { get; set; }
        public int UsersCount { get; set; }
        public int ReviewsCount { get; set; } // Para la tarjeta de reseñas

        public async Task OnGetAsync()
        {
            // Consultamos la base de datos para llenar los contadores
            ProductsCount = await _context.Products.CountAsync();
            CategoriesCount = await _context.Categories.CountAsync();
            UsersCount = await _context.Users.CountAsync();

            // Si aún no tienes tabla de reseñas, puedes poner esto en 0 o comentar la línea
            // Pero asumo que ya tienes el modelo ProductReview
            try
            {
                ReviewsCount = await _context.ProductReviews.CountAsync();
            }
            catch
            {
                ReviewsCount = 0; // Por si acaso falla
            }
        }
    }
}