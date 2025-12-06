using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Models;

namespace EcommerceFixed.Pages.admin.categories
{
    public class DetailsModel : PageModel
    {
        private readonly EcommerceFixed.Data.ApplicationDbContext _context;

        public DetailsModel(EcommerceFixed.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
