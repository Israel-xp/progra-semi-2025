using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceFixed.Data;
using EcommerceFixed.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceFixed.Pages.admin.products
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public EditModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        [BindProperty]
        public IFormFile? ImageFile { get; set; } // Para cambiar la imagen principal

        // ✅ NUEVO: Para agregar fotos a la galería
        [BindProperty]
        public List<IFormFile> ExtraImages { get; set; } = new List<IFormFile>();

        public List<Category> Categories { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null) return NotFound();

            // Cargar producto con sus imágenes de galería
            var product = await _context.Products
                .Include(p => p.Images) // Importante para ver la galería actual
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null) return NotFound();

            Product = product;
            Categories = _context.Categories.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var existingProduct = await _context.Products
                    .Include(p => p.Images)
                    .FirstOrDefaultAsync(p => p.Id == Product.Id);

                if (existingProduct == null)
                {
                    TempData["error"] = "Producto no encontrado.";
                    return RedirectToPage("./Index");
                }

                // 1. Actualizar Datos Básicos
                existingProduct.Name = Product.Name;
                existingProduct.Desc = Product.Desc;
                existingProduct.SKU = Product.SKU;
                existingProduct.Quantity = Product.Quantity;
                existingProduct.Price = Product.Price;
                existingProduct.Discount = Product.Discount;
                existingProduct.CategoryId = Product.CategoryId;
                existingProduct.IsFeatured = Product.IsFeatured;
                existingProduct.Gender = Product.Gender;

                // 2. Actualizar Datos de IA/Estilo
                existingProduct.ClothingType = Product.ClothingType;
                existingProduct.Style = Product.Style;
                existingProduct.Season = Product.Season;
                existingProduct.Occasion = Product.Occasion;
                existingProduct.Color = Product.Color;
                existingProduct.Material = Product.Material;
                existingProduct.Tags = Product.Tags;
                existingProduct.FormalityLevel = Product.FormalityLevel;
                existingProduct.MinTemperature = Product.MinTemperature;
                existingProduct.MaxTemperature = Product.MaxTemperature;
                existingProduct.CompatibleWith = Product.CompatibleWith;

                // 3. ✅ Actualizar Tallas Disponibles
                // Si el usuario lo dejó vacío, mantenemos el valor anterior o ponemos default
                if (!string.IsNullOrEmpty(Product.AvailableSizes))
                {
                    existingProduct.AvailableSizes = Product.AvailableSizes;
                }
                else if (string.IsNullOrEmpty(existingProduct.AvailableSizes))
                {
                    existingProduct.AvailableSizes = existingProduct.ClothingType == "Zapatos" ? "38,39,40,41" : "S,M,L,XL";
                }

                // 4. Actualizar Imagen Principal (Solo si subió una nueva)
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    existingProduct.ImageLocation = await SaveFile(ImageFile, "uploads");
                }

                // 5. ✅ Agregar Imágenes a la Galería (Sin borrar las anteriores)
                if (ExtraImages != null && ExtraImages.Count > 0)
                {
                    foreach (var file in ExtraImages)
                    {
                        if (file.Length > 0)
                        {
                            var path = await SaveFile(file, "uploads/gallery");
                            var newImg = new ProductImage { ProductId = existingProduct.Id, ImageUrl = path };
                            _context.ProductImages.Add(newImg);
                        }
                    }
                }

                await _context.SaveChangesAsync();

                TempData["success"] = $"Producto \"{existingProduct.Name}\" actualizado correctamente.";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error al actualizar: " + ex.Message;
                Categories = _context.Categories.ToList();
                return Page();
            }
        }

        // Helper para guardar archivos
        private async Task<string> SaveFile(IFormFile file, string folderName)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, folderName);
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return "/" + folderName + "/" + uniqueFileName;
        }
    }
}