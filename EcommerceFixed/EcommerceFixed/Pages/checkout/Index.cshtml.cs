using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using EcommerceFixed.Data;
using EcommerceFixed.Helpers;
using EcommerceFixed.Models;

namespace EcommerceFixed.Pages.checkout
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public List<Product> Products { get; set; } = new List<Product>();
        public decimal CartTotal { get; private set; }

        [BindProperty]
        public Order Order { get; set; }

        public decimal CartTotalAfterGst
        {
            get
            {
                return CartTotal * 1.05m;
            }
        }

        public IndexModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void OnGet()
        {
            //redirect user to login if they are not logged in
            if (User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("/Identity/Account/Login");
                return;
            }

            // CORREGIDO: Usar User directamente en lugar de user.Id
            Products = CartHelper.GetGroupedCartItemsDb(User, _context);
            CartTotal = CartHelper.GetCartTotalDb(User, _context);
        }

        public async Task<IActionResult> OnPostCheckout()
        {
            // CORREGIDO: Usar User directamente en lugar de user.Id
            Products = CartHelper.GetGroupedCartItemsDb(User, _context);
            CartTotal = CartHelper.GetCartTotalDb(User, _context);

            if (!ModelState.IsValid)
            {
                TempData["error"] = "Failed to submit.";
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            Order.Email = user.Email;
            Order.ProductDataAsJson = JsonConvert.SerializeObject(Products);
            Order.DateOrdered = DateTime.UtcNow;
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            // CORREGIDO: Usar User directamente en lugar de user.Id
            CartHelper.ClearCartDb(User, _context);

            TempData["success"] = "Your order has been placed!";
            return Redirect("/myorders");
        }
    }
}