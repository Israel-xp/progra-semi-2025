using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Data;
using EcommerceFixed.Models;

namespace EcommerceFixed.Pages.myorders
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Order> Orders { get; set; } = new List<Order>();

        public async Task OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated) return;

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return;

            if (_context.Orders != null)
            {
                Orders = await _context.Orders
                    .OrderByDescending(o => o.DateOrdered)
                    .Where(o => o.Email == user.Email) // Usar el email del usuario
                    .ToListAsync();
            }
        }
    }
}