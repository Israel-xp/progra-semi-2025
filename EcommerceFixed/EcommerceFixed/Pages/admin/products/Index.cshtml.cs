using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Data;
using EcommerceFixed.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceFixed.Pages.admin.products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            // Incluimos Category para que el nombre se muestre correctamente en la tabla
            Products = await _context.Products
                                     .Include(p => p.Category)
                                     .ToListAsync();

            Console.WriteLine($"📦 Productos cargados: {Products.Count}");
        }
    }
}
