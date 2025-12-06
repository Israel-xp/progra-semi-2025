using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Data;
using EcommerceFixed.Models;

namespace EcommerceFixed.Pages.Admin.Reviews
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IndexModel> _logger;

        public List<ProductReview> Reviews { get; set; } = new List<ProductReview>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "newest";

        [BindProperty(SupportsGet = true)]
        public string FilterBy { get; set; } = "all";

        public IndexModel(ApplicationDbContext context,
                          UserManager<ApplicationUser> userManager,
                          ILogger<IndexModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            await LoadReviews();
        }

        private async Task LoadReviews()
        {
            try
            {
                var query = _context.ProductReviews
                    .Include(r => r.User)
                    .Include(r => r.Product)
                    .AsQueryable();

                // Filtro de búsqueda
                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    query = query.Where(r =>
                        r.Comment.Contains(SearchTerm) ||
                        r.User.UserName.Contains(SearchTerm) ||
                        r.Product.Name.Contains(SearchTerm));
                }

                // Filtros adicionales
                if (FilterBy != "all")
                {
                    switch (FilterBy)
                    {
                        case "with_images":
                            query = query.Where(r => !string.IsNullOrEmpty(r.ReviewImage));
                            break;
                        case "high_rating":
                            query = query.Where(r => r.Rating >= 4);
                            break;
                        case "low_rating":
                            query = query.Where(r => r.Rating <= 2);
                            break;
                    }
                }

                // Ordenamiento
                query = SortOrder?.ToLower() switch
                {
                    "oldest" => query.OrderBy(r => r.DateCreated),
                    "rating_high" => query.OrderByDescending(r => r.Rating),
                    "rating_low" => query.OrderBy(r => r.Rating),
                    _ => query.OrderByDescending(r => r.DateCreated) // newest
                };

                Reviews = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar las reseñas");
                TempData["error"] = "Error al cargar las reseñas";
            }
        }

        public async Task<IActionResult> OnPostDeleteReviewAsync(int reviewId)
        {
            try
            {
                var review = await _context.ProductReviews
                    .Include(r => r.Product)
                    .FirstOrDefaultAsync(r => r.Id == reviewId);

                if (review == null)
                {
                    TempData["error"] = "Reseña no encontrada.";
                    return RedirectToPage();
                }

                var productName = review.Product.Name;
                _context.ProductReviews.Remove(review);
                await _context.SaveChangesAsync();

                TempData["success"] = $"Reseña del producto '{productName}' eliminada correctamente.";
                _logger.LogInformation("Reseña {ReviewId} eliminada por admin", reviewId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar reseña {ReviewId}", reviewId);
                TempData["error"] = "Error al eliminar la reseña.";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteMultipleReviewsAsync(int[] selectedReviews)
        {
            try
            {
                if (selectedReviews == null || selectedReviews.Length == 0)
                {
                    TempData["error"] = "No se seleccionaron reseñas para eliminar.";
                    return RedirectToPage();
                }

                var reviews = await _context.ProductReviews
                    .Where(r => selectedReviews.Contains(r.Id))
                    .Include(r => r.Product)
                    .ToListAsync();

                if (!reviews.Any())
                {
                    TempData["error"] = "No se encontraron las reseñas seleccionadas.";
                    return RedirectToPage();
                }

                _context.ProductReviews.RemoveRange(reviews);
                await _context.SaveChangesAsync();

                TempData["success"] = $"{reviews.Count} reseñas eliminadas correctamente.";
                _logger.LogInformation("{Count} reseñas eliminadas por admin", reviews.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar múltiples reseñas");
                TempData["error"] = "Error al eliminar las reseñas.";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleFeaturedAsync(int reviewId)
        {
            try
            {
                var review = await _context.ProductReviews.FindAsync(reviewId);
                if (review != null)
                {
                    // Si tienes una propiedad IsFeatured en ProductReview, la puedes usar aquí
                    // review.IsFeatured = !review.IsFeatured;
                    // await _context.SaveChangesAsync();
                    TempData["success"] = "Funcionalidad de destacar reseña implementada pronto.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cambiar estado de reseña {ReviewId}", reviewId);
                TempData["error"] = "Error al actualizar la reseña.";
            }

            return RedirectToPage();
        }
    }
}