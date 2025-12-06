using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Data;
using EcommerceFixed.Helpers;
using EcommerceFixed.Models;

namespace EcommerceFixed.Pages.admin.categories
{
    public class IndexModel : PageModel
    {
        private readonly EcommerceFixed.Data.ApplicationDbContext _context;

        public IndexModel(EcommerceFixed.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; }


        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Categories = await _context.Categories.ToListAsync();
            }
        }
    }
}
