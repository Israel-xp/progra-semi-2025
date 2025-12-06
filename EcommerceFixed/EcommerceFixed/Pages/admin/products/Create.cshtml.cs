using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceFixed.Data;
using EcommerceFixed.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceFixed.Pages.admin.products
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Product Product { get; set; } = new Product();

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        // Lista de categorías para el select
        public List<Category> Categories { get; set; } = new();

        public void OnGet()
        {
            Categories = _context.Categories.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // 1. Guardar Imagen Principal
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }
                    Product.ImageLocation = "/uploads/" + uniqueFileName;
                }
                else
                {
                    // Imagen por defecto si no suben nada
                    Product.ImageLocation = "https://via.placeholder.com/400x400?text=Sin+Imagen";
                }

                // 2. Configurar Valores por Defecto
                Product.DateCreated = DateTime.Now;

                if (string.IsNullOrEmpty(Product.SKU))
                    Product.SKU = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                // ✅ LÓGICA DE TALLAS INTELIGENTE
                // Si el admin no escribió tallas específicas, asignamos unas por defecto según el tipo
                if (string.IsNullOrEmpty(Product.AvailableSizes))
                {
                    if (Product.ClothingType == "Zapatos")
                        Product.AvailableSizes = "38,39,40,41,42"; // Números para calzado
                    else if (Product.ClothingType == "Accesorio")
                        Product.AvailableSizes = "Única"; // Talla única para accesorios
                    else
                        Product.AvailableSizes = "XS,S,M,L,XL"; // Letras para ropa
                }

                // 3. Guardar en Base de Datos
                _context.Products.Add(Product);
                await _context.SaveChangesAsync();

                TempData["success"] = $"Producto \"{Product.Name}\" creado exitosamente!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                TempData["error"] = "Error al crear el producto: " + ex.Message;
                Categories = _context.Categories.ToList();
                return Page();
            }
        }
    }
}