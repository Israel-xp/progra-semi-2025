using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Data;
using EcommerceFixed.Models;
using EcommerceFixed.Helpers;
using System.ComponentModel.DataAnnotations;

namespace EcommerceFixed.Pages.products
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public DetailsModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }

        public Product Product { get; set; }
        public List<ProductReview> Reviews { get; set; } = new List<ProductReview>();
        public List<Product> RelatedProducts { get; set; } = new List<Product>();

        // ✅ NUEVO: Lista para pintar los botones de tallas
        public List<string> SizeList { get; set; } = new();

        // ✅ NUEVO: Capturar la talla que el usuario seleccionó
        [BindProperty]
        public string SelectedSize { get; set; }

        [BindProperty]
        public ReviewInputModel ReviewInput { get; set; }

        public class ReviewInputModel
        {
            [Required(ErrorMessage = "La calificación es requerida")]
            [Range(1, 5, ErrorMessage = "1 a 5 estrellas")]
            public int Rating { get; set; } = 5;

            [Required(ErrorMessage = "Escribe un comentario")]
            [MaxLength(1000)]
            public string Comment { get; set; }

            public IFormFile? ReviewImageFile { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Reviews).ThenInclude(r => r.User)
                .Include(p => p.Votes)
                .Include(p => p.Images) // ✅ Cargar galería de imágenes extra
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null) return NotFound();

            // Ordenar reseñas por fecha
            Reviews = Product.Reviews.OrderByDescending(r => r.DateCreated).ToList();

            // ✅ Lógica de Tallas: Convertir "S,M,L" a lista para la vista
            if (!string.IsNullOrEmpty(Product.AvailableSizes))
            {
                SizeList = Product.AvailableSizes.Split(',').Select(s => s.Trim()).ToList();
            }
            else
            {
                // Default si no se configuró nada en el admin
                SizeList = Product.ClothingType == "Zapatos"
                    ? new List<string> { "38", "39", "40", "41", "42" }
                    : new List<string> { "XS", "S", "M", "L", "XL" };
            }

            // Cargar productos relacionados (misma categoría)
            RelatedProducts = await _context.Products
                .Where(p => p.CategoryId == Product.CategoryId && p.Id != Product.Id)
                .Include(p => p.Category)
                .Take(4)
                .ToListAsync();

            return Page();
        }

        // --- ACCIONES ---

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Identity/Account/Login");

            // ✅ Validar que seleccionó talla
            if (string.IsNullOrEmpty(SelectedSize))
            {
                TempData["error"] = "⚠️ Por favor selecciona una talla antes de agregar.";
                return RedirectToPage(new { id = productId });
            }

            var product = await _context.Products.FindAsync(productId);
            if (product == null || product.IsOutOfStock) return RedirectToPage(new { id = productId });

            CartHelper.AddToCartDb(product, _context, User);
            TempData["success"] = $"Agregado al carrito (Talla: {SelectedSize})";
            return RedirectToPage(new { id = productId });
        }

        public async Task<IActionResult> OnPostAddToWishlistAsync(int productId)
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Identity/Account/Login");
            var product = await _context.Products.FindAsync(productId);
            WishlistHelper.AddToWishlist(product, _context, User);
            TempData["success"] = "Agregado a favoritos";
            return RedirectToPage(new { id = productId });
        }

        public async Task<IActionResult> OnPostAddReviewAsync(int productId)
        {
            if (!User.Identity.IsAuthenticated) return Challenge();

            var user = await _userManager.GetUserAsync(User);
            var existing = await _context.ProductReviews.AnyAsync(r => r.ProductId == productId && r.UserId == user.Id);

            if (existing)
            {
                TempData["error"] = "Ya has opinado sobre este producto.";
                return RedirectToPage(new { id = productId });
            }

            var review = new ProductReview
            {
                ProductId = productId,
                UserId = user.Id,
                Rating = ReviewInput.Rating,
                Comment = ReviewInput.Comment,
                DateCreated = DateTime.UtcNow
                // UserDisplayName se calcula solo en el modelo, no lo asignamos aquí
            };

            // Guardar imagen de reseña
            if (ReviewInput.ReviewImageFile != null && ReviewInput.ReviewImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "reviews");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ReviewInput.ReviewImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ReviewInput.ReviewImageFile.CopyToAsync(fileStream);
                }
                review.ReviewImage = "/uploads/reviews/" + uniqueFileName;
            }

            _context.ProductReviews.Add(review);
            await _context.SaveChangesAsync();
            TempData["success"] = "¡Gracias por tu opinión!";
            return RedirectToPage(new { id = productId });
        }

        public async Task<IActionResult> OnPostDeleteReviewAsync(int reviewId, int productId)
        {
            var review = await _context.ProductReviews.FindAsync(reviewId);
            var user = await _userManager.GetUserAsync(User);
            if (review != null && (review.UserId == user.Id || User.IsInRole("Admin")))
            {
                _context.ProductReviews.Remove(review);
                await _context.SaveChangesAsync();
                TempData["success"] = "Comentario eliminado.";
            }
            return RedirectToPage(new { id = productId });
        }

        // ✅ MANEJADOR DE VOTOS (AJAX)
        public async Task<JsonResult> OnPostVoteAsync(int productId, bool isLike)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return new JsonResult(new { success = false, message = "Debes iniciar sesión para votar" });
            }

            try
            {
                var user = await _userManager.GetUserAsync(User);
                var existingVote = await _context.ProductVotes.FirstOrDefaultAsync(v => v.ProductId == productId && v.UserId == user.Id);

                if (existingVote != null)
                {
                    if (existingVote.IsLike == isLike) _context.ProductVotes.Remove(existingVote);
                    else
                    {
                        existingVote.IsLike = isLike;
                        existingVote.DateVoted = DateTime.UtcNow;
                        _context.ProductVotes.Update(existingVote);
                    }
                }
                else
                {
                    var vote = new ProductVote { ProductId = productId, UserId = user.Id, IsLike = isLike, DateVoted = DateTime.UtcNow };
                    _context.ProductVotes.Add(vote);
                }

                await _context.SaveChangesAsync();

                var likes = await _context.ProductVotes.CountAsync(v => v.ProductId == productId && v.IsLike);
                var dislikes = await _context.ProductVotes.CountAsync(v => v.ProductId == productId && !v.IsLike);

                return new JsonResult(new { success = true, likes = likes, dislikes = dislikes });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Error: " + ex.Message });
            }
        }
    }
}