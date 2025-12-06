using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Data;
using EcommerceFixed.Helpers;
using EcommerceFixed.Models;

namespace EcommerceFixed.Pages.products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Filtros
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Gender { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool OnSale { get; set; }

        // Paginación
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 12; // Cantidad de productos por carga
        public int TotalPages { get; set; }
        public bool ShowNextButton => CurrentPage < TotalPages;
        public bool ShowPrevButton => CurrentPage > 1;

        public IList<Product> Products { get; set; }
        public List<Category> Categories { get; set; } = new();

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();

            var query = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Reviews)
                .AsQueryable();

            // 1. Aplicar Filtros
            if (CategoryId.HasValue && CategoryId > 0)
            {
                query = query.Where(p => p.CategoryId == CategoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                query = query.Where(p => p.Name.Contains(SearchTerm) || p.Tags.Contains(SearchTerm));
            }

            if (!string.IsNullOrWhiteSpace(Gender) && Gender != "Todos")
            {
                query = query.Where(p => p.Gender == Gender);
            }

            if (OnSale)
            {
                query = query.Where(p => p.Discount > 0);
            }

            // 2. Calcular Paginación
            int totalItems = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            // Validar página actual
            if (CurrentPage < 1) CurrentPage = 1;

            // 3. Obtener datos paginados
            Products = await query
                .OrderByDescending(p => p.IsFeatured) // Destacados primero
                .ThenByDescending(p => p.DateCreated)
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }

        // Métodos POST (Carrito/Wishlist) se mantienen igual...
        public IActionResult OnPostAddToCart(int productId)
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Identity/Account/Login");
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null || product.IsOutOfStock) return Redirect("/products");
            CartHelper.AddToCartDb(product, _context, this.User);
            TempData["success"] = "Agregado al carrito";
            return Redirect($"/products?Gender={Gender}&CategoryId={CategoryId}&CurrentPage={CurrentPage}");
        }

        public IActionResult OnPostAddToWishlist(int productId)
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Identity/Account/Login");
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            WishlistHelper.AddToWishlist(product, _context, this.User);
            TempData["success"] = "Agregado a favoritos";
            return Redirect($"/products?Gender={Gender}&CategoryId={CategoryId}&CurrentPage={CurrentPage}");
        }
    }
}