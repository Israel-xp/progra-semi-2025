using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Data;
using EcommerceFixed.Helpers;
using EcommerceFixed.Models;

namespace EcommerceFixed.Pages.cart
{
    public class IndexModel : PageModel
    {
        private readonly EcommerceFixed.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public string CartTotal { get; set; }

        public IList<Product> Products { get; set; } = new List<Product>();

        public IndexModel(EcommerceFixed.Data.ApplicationDbContext context,
                        UserManager<ApplicationUser> userManager,
                        SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task OnGetAsync()
        {
            try
            {
                if (_signInManager.IsSignedIn(User))
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        CartTotal = CartHelper.GetCartTotalDb(user.Id, _context).ToString("c2");
                        Products = CartHelper.GetGroupedCartItemsDb(user.Id, _context) ?? new List<Product>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error en OnGetAsync: {ex.Message}");
                TempData["error"] = "Error al cargar el carrito. Por favor, intenta nuevamente.";
                Products = new List<Product>();
            }
        }

        public async Task<IActionResult> OnPostAddToCart(int productId)
        {
            try
            {
                if (!_signInManager.IsSignedIn(User))
                {
                    TempData["error"] = "Debes iniciar sesión para agregar productos al carrito.";
                    return Redirect("/Identity/Account/Login");
                }

                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    TempData["error"] = "Usuario no encontrado.";
                    return Redirect("/cart");
                }

                var product = _context.Products.FirstOrDefault(x => x.Id == productId);
                if (product == null)
                {
                    TempData["error"] = "El producto que intentas agregar no existe o ha sido eliminado.";
                    return Redirect("/cart");
                }

                if (product.IsOutOfStock)
                {
                    TempData["error"] = $"{product.Name} está agotado y no se puede agregar al carrito.";
                    return Redirect("/cart");
                }

                CartHelper.AddToCartDb(product, _context, user.Id);
                TempData["success"] = $"{product.Name} agregado al carrito correctamente.";

                return Redirect("/cart");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error en OnPostAddToCart: {ex.Message}");
                TempData["error"] = "Error al agregar el producto al carrito. Por favor, intenta nuevamente.";
                return Redirect("/cart");
            }
        }

        public async Task<IActionResult> OnPostRemoveFromCart(int productId)
        {
            try
            {
                if (!_signInManager.IsSignedIn(User))
                {
                    TempData["error"] = "Debes iniciar sesión para modificar tu carrito.";
                    return Redirect("/Identity/Account/Login");
                }

                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    TempData["error"] = "Usuario no encontrado.";
                    return Redirect("/cart");
                }

                var product = _context.Products.FirstOrDefault(x => x.Id == productId);
                if (product == null)
                {
                    TempData["error"] = "El producto que intentas eliminar no existe o ya ha sido removido.";
                    return Redirect("/cart");
                }

                CartHelper.RemoveFromCartDb(product, _context, user.Id);
                TempData["success"] = $"{product.Name} eliminado del carrito correctamente.";

                return Redirect("/cart");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error en OnPostRemoveFromCart: {ex.Message}");
                TempData["error"] = "Error al eliminar el producto del carrito. Por favor, intenta nuevamente.";
                return Redirect("/cart");
            }
        }

        public async Task<IActionResult> OnPostRemoveAllFromCart(int productId)
        {
            try
            {
                if (!_signInManager.IsSignedIn(User))
                {
                    TempData["error"] = "Debes iniciar sesión para modificar tu carrito.";
                    return Redirect("/Identity/Account/Login");
                }

                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    TempData["error"] = "Usuario no encontrado.";
                    return Redirect("/cart");
                }

                var product = _context.Products.FirstOrDefault(x => x.Id == productId);
                if (product == null)
                {
                    TempData["error"] = "El producto que intentas eliminar no existe.";
                    return Redirect("/cart");
                }

                CartHelper.RemoveAllFromCartDb(product, _context, user.Id);
                TempData["success"] = $"Todos los items de {product.Name} eliminados del carrito.";

                return Redirect("/cart");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error en OnPostRemoveAllFromCart: {ex.Message}");
                TempData["error"] = "Error al eliminar los productos del carrito.";
                return Redirect("/cart");
            }
        }
    }
}