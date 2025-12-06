using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Data;
using EcommerceFixed.Helpers;
using EcommerceFixed.Models;

namespace EcommerceFixed.Pages.wishlist
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationDbContext Context { get; set; }

        public string CartTotal { get; set; }

        public IndexModel(ApplicationDbContext context,
                         UserManager<ApplicationUser> userManager,
                         SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IList<Product> ProductWishlist { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    CartTotal = CartHelper.GetCartTotalDb(user.Id, _context).ToString("c2");

                    if (_context != null)
                    {
                        ProductWishlist = await Task.Run(() => WishlistHelper.GetUserWishlist(user.Id, _context));
                    }
                }
            }
        }

        public async Task<IActionResult> OnPostAddToCart(int productId)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                TempData["error"] = "Debes iniciar sesión para agregar productos al carrito.";
                return RedirectToPage();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["error"] = "Usuario no encontrado.";
                return RedirectToPage();
            }

            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                TempData["error"] = "Producto no encontrado.";
                return RedirectToPage();
            }

            CartHelper.AddToCartDb(product, _context, user.Id);
            WishlistHelper.RemoveFromWishlist(product, _context, user.Id);

            ProductWishlist = WishlistHelper.GetUserWishlist(user.Id, _context);
            TempData["success"] = $"{product.Name} agregado al carrito.";

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveFromWishlist(int productId)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                TempData["error"] = "Debes iniciar sesión para modificar tu lista de deseos.";
                return RedirectToPage();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["error"] = "Usuario no encontrado.";
                return RedirectToPage();
            }

            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                TempData["error"] = "Producto no encontrado.";
                return RedirectToPage();
            }

            WishlistHelper.RemoveFromWishlist(product, _context, user.Id);
            ProductWishlist = WishlistHelper.GetUserWishlist(user.Id, _context);
            TempData["success"] = $"{product.Name} eliminado de tu lista de deseos.";

            return RedirectToPage();
        }
    }
}