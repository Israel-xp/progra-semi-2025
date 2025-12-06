using EcommerceFixed.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceFixed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IIAModaService _iaService;

        public ChatController(IIAModaService iaService)
        {
            _iaService = iaService;
        }

        [HttpPost("preguntar")]
        public async Task<IActionResult> Preguntar([FromBody] ChatRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Message))
            {
                return BadRequest(new { reply = "Por favor escribe algo." });
            }

            // Pasamos la petición completa (Mensaje + Contexto) al servicio
            var resultado = await _iaService.AnalizarPedido(request);

            return Ok(new
            {
                reply = resultado.TextoRespuesta,
                products = resultado.Productos
            });
        }
    }

    // DTO actualizado para recibir contexto
    public class ChatRequest
    {
        public string Message { get; set; }
        public int? CurrentProductId { get; set; }
        public string? CurrentCategory { get; set; } // Ej: "Zapatos", "Pantalón"
    }
}