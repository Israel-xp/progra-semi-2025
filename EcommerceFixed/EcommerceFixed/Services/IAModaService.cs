using EcommerceFixed.Controllers; // Para usar ChatRequest
using EcommerceFixed.Data;
using EcommerceFixed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceFixed.Services
{
    public interface IIAModaService
    {
        Task<RespuestaBot> AnalizarPedido(ChatRequest request);
    }

    public class RespuestaBot
    {
        public string TextoRespuesta { get; set; }
        public List<ProductoRecomendado> Productos { get; set; } = new List<ProductoRecomendado>();
    }

    public class ProductoRecomendado
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageLocation { get; set; }
        public string Reason { get; set; }
    }

    public class IAModaService : IIAModaService
    {
        private readonly ApplicationDbContext _context;

        public IAModaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RespuestaBot> AnalizarPedido(ChatRequest request)
        {
            var respuesta = new RespuestaBot();
            string msg = request.Message.ToLower().Trim();

            // 1. DETECTAR INTENCIÓN
            bool quiereOutfit = msg.Contains("outfit") || msg.Contains("set") || msg.Contains("armame") || msg.Contains("look completo");
            bool quiereCombinar = msg.Contains("combinar") || msg.Contains("queda bien") || msg.Contains("accesorios");

            // 2. DETECTAR ESTILO (VIBE)
            string vibe = DetectarEstilo(msg);

            // 3. LÓGICA: OUTFIT COMPLETO
            if (quiereOutfit)
            {
                return await GenerarOutfitCompleto(vibe);
            }

            // 4. LÓGICA: COMBINAR LO QUE VEO
            if (quiereCombinar && request.CurrentProductId.HasValue)
            {
                return await BuscarComplementos(request.CurrentProductId, request.CurrentCategory, vibe);
            }

            // 5. BÚSQUEDA NORMAL
            return await BusquedaNormal(msg, vibe);
        }

        // --- MOTORES DE LÓGICA ---

        private async Task<RespuestaBot> GenerarOutfitCompleto(string vibe)
        {
            if (string.IsNullOrEmpty(vibe)) vibe = "Casual"; // Default

            var respuesta = new RespuestaBot();
            respuesta.TextoRespuesta = $"¡Claro que sí! Aquí tienes un **Total Look {vibe}** que he diseñado para ti:";

            // Buscamos 1 pieza de cada tipo (Top, Bottom, Zapatos)
            var top = await _context.Products
                .Where(p => (p.ClothingType == "Camiseta" || p.ClothingType == "Chaqueta" || p.ClothingType == "Blusa") && (p.Style.Contains(vibe) || p.Tags.Contains(vibe)))
                .OrderBy(r => Guid.NewGuid()).FirstOrDefaultAsync();

            var bottom = await _context.Products
                .Where(p => (p.ClothingType == "Pantalón" || p.ClothingType == "Falda" || p.ClothingType == "Shorts") && (p.Style.Contains(vibe) || p.Tags.Contains(vibe)))
                .OrderBy(r => Guid.NewGuid()).FirstOrDefaultAsync();

            var shoes = await _context.Products
                .Where(p => p.ClothingType == "Zapatos" && (p.Style.Contains(vibe) || p.Tags.Contains(vibe)))
                .OrderBy(r => Guid.NewGuid()).FirstOrDefaultAsync();

            if (top != null) respuesta.Productos.Add(Mapear(top));
            if (bottom != null) respuesta.Productos.Add(Mapear(bottom));
            if (shoes != null) respuesta.Productos.Add(Mapear(shoes));

            if (respuesta.Productos.Count == 0) respuesta.TextoRespuesta = "No pude armar un outfit completo con el stock actual. 😓 Intenta otro estilo.";

            return respuesta;
        }

        private async Task<RespuestaBot> BuscarComplementos(int? currentId, string currentCat, string vibe)
        {
            var respuesta = new RespuestaBot();
            respuesta.TextoRespuesta = "Para combinar con lo que estás viendo, te sugiero estas opciones:";

            var query = _context.Products.AsQueryable();

            // EXCLUSIÓN: No mostrar la misma categoría que ya ve (si ve zapatos, no mostrar zapatos)
            if (!string.IsNullOrEmpty(currentCat))
            {
                query = query.Where(p => p.ClothingType != currentCat);
            }

            // EXCLUSIÓN: No mostrar el mismo producto
            if (currentId.HasValue)
            {
                query = query.Where(p => p.Id != currentId.Value);
            }

            // Filtrar por estilo si existe, si no, buscar básicos o compatibles
            if (!string.IsNullOrEmpty(vibe))
            {
                query = query.Where(p => p.Style.Contains(vibe) || p.Tags.Contains(vibe));
            }
            else
            {
                // Si no hay estilo, buscar colores neutros o accesorios
                query = query.Where(p => p.ClothingType == "Accesorio" || p.Color == "Negro" || p.Color == "Blanco");
            }

            var sugerencias = await query.Take(3).ToListAsync();

            if (sugerencias.Any())
                respuesta.Productos = sugerencias.Select(p => Mapear(p)).ToList();
            else
                respuesta.TextoRespuesta = "No encontré combinaciones perfectas en este momento.";

            return respuesta;
        }

        private async Task<RespuestaBot> BusquedaNormal(string msg, string vibe)
        {
            var respuesta = new RespuestaBot();
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(vibe))
            {
                query = query.Where(p => p.Style.Contains(vibe) || p.Tags.Contains(vibe) || p.Color.Contains(vibe));
                respuesta.TextoRespuesta = $"Aquí tienes opciones estilo **{vibe}**:";
            }
            else
            {
                query = query.Where(p => p.Name.Contains(msg) || p.Tags.Contains(msg));
                respuesta.TextoRespuesta = "Encontré esto en el catálogo:";
            }

            var listado = await query.Take(4).ToListAsync();

            if (listado.Count == 0)
                respuesta.TextoRespuesta = "No encontré nada. Intenta con 'Outfit Dark', 'Verano' o 'Combinar'.";
            else
                respuesta.Productos = listado.Select(p => Mapear(p)).ToList();

            return respuesta;
        }

        // Helpers
        private string DetectarEstilo(string msg)
        {
            if (msg.Contains("dark") || msg.Contains("rock") || msg.Contains("negro")) return "Gótico";
            if (msg.Contains("aesthetic") || msg.Contains("rosa") || msg.Contains("soft")) return "Casual";
            if (msg.Contains("formal") || msg.Contains("oficina")) return "Formal";
            if (msg.Contains("urbano") || msg.Contains("calle")) return "Urbano";
            if (msg.Contains("verano") || msg.Contains("playa")) return "Bohemio";
            return "";
        }

        private ProductoRecomendado Mapear(Product p)
        {
            return new ProductoRecomendado
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageLocation = !string.IsNullOrEmpty(p.ImageLocation) ? p.ImageLocation : "https://via.placeholder.com/150"
            };
        }
    }
}